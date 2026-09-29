using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FincoreCoreMvc.Data;
using FincoreCoreMvc.Interface;
using FincoreCoreMvc.Models;

namespace FincoreCoreMvc.Service
{
    public class POService : IPOService
    {
        AppDbContext db;

        public POService(AppDbContext db)
        {
            this.db = db;
        }
        public async Task<List<PurchaseOrder>> GetPurchaseOrdersAsync()
        {
            return await db.PurchaseOrders
                .Include(p => p.Items)
                .Where(p => p.IsActive == 1)
                .OrderByDescending(p => p.POId)
                .ToListAsync();
        }
        public async Task<PurchaseOrder?> GetPurchaseOrderByIdAsync(int id)
        {
            return await db.PurchaseOrders
                .Include(p => p.Items)
                .FirstOrDefaultAsync(p => p.POId == id && p.IsActive == 1);
        }
        public async Task<int> AddPurchaseOrderAsync(PurchaseOrder po)
        {
            if (string.IsNullOrWhiteSpace(po.POCode))
            {
                po.POCode = await GeneratePOCodeAsync();
            }

            po.Status = "Draft";
            po.IsActive = 1;
            po.CreatedAt = DateTime.Now;
            po.CreatedBy = 1;

            decimal grandTotal = 0;

            if (po.Items != null && po.Items.Count > 0)
            {
                foreach (var item in po.Items)
                {
                    decimal baseAmount = item.Quantity * item.UnitPrice;
                    decimal taxAmount = baseAmount * (item.TaxPercentage / 100m);
                    decimal lineTotal = baseAmount + taxAmount;

                    item.TaxAmount = Math.Round(taxAmount, 2);
                    item.LineTotal = Math.Round(lineTotal, 2);
                    item.ItemStatus = "Pending";

                    if (string.IsNullOrWhiteSpace(item.UnitOfMaterial))
                    {
                        item.UnitOfMaterial = "Units";
                    }

                    grandTotal += item.LineTotal;
                }
            }

            po.Amount = Math.Round(grandTotal, 2);

            await db.PurchaseOrders.AddAsync(po);
            await db.SaveChangesAsync();

            return po.POId;
        }
        public async Task EditPurchaseOrderAsync(PurchaseOrder po, int id)
        {
            var existingPO = await db.PurchaseOrders
                .Include(p => p.Items)
                .FirstOrDefaultAsync(p => p.POId == id);

            if (existingPO != null && (existingPO.Status == "Draft" || existingPO.Status == "Rejected"))
            {
                existingPO.VendorId = po.VendorId;
                existingPO.QuotationId = po.QuotationId;
                existingPO.OrderDate = po.OrderDate;
                existingPO.ModifiedAt = DateTime.Now;
                db.PurchaseOrderItems.RemoveRange(existingPO.Items);
                existingPO.Items.Clear();

                decimal grandTotal = 0;

                if (po.Items != null)
                {
                    foreach (var item in po.Items)
                    {
                        decimal baseAmount = item.Quantity * item.UnitPrice;
                        decimal taxAmount = baseAmount * (item.TaxPercentage / 100m);
                        decimal lineTotal = baseAmount + taxAmount;

                        item.TaxAmount = Math.Round(taxAmount, 2);
                        item.LineTotal = Math.Round(lineTotal, 2);
                        item.ItemStatus = "Pending";
                        item.POId = existingPO.POId;

                        grandTotal += item.LineTotal;
                        existingPO.Items.Add(item);
                    }
                }

                existingPO.Amount = Math.Round(grandTotal, 2);
                await db.SaveChangesAsync();
            }
        }
        public async Task DeletePurchaseOrderAsync(int id)
        {
            var po = await db.PurchaseOrders.FindAsync(id);
            if (po != null)
            {
                po.IsActive = 0;
                po.ModifiedAt = DateTime.Now;
                await db.SaveChangesAsync();
            }
        }
        public async Task UpdateStatusAsync(int id, string status)
        {
            var po = await db.PurchaseOrders.FindAsync(id);
            if (po != null)
            {
                po.Status = status;
                po.ModifiedAt = DateTime.Now;
                await db.SaveChangesAsync();
            }
        }
        public async Task<string> GeneratePOCodeAsync()
        {
            int currentYear = DateTime.Now.Year;
            int count = await db.PurchaseOrders.CountAsync();
            return $"PO-{currentYear}-{(count + 1):D4}";
        }
    }
}
