using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FincoreCoreMvc.Models
{
    public class RolePermissionModule
    {
        [Key]
        public int role_permission_module_id { get; set; }

        [ForeignKey("role_id")]
        public int ?  role_id { get; set; }
        public Role role { get; set; }


        [ForeignKey("permission_id")]
        public int ? permission_id { get; set; }
        public Permissions permissions { get; set; }
        [ForeignKey("module_id")]
        public int ? module_id { get; set; }
        public Module module { get; set; }
    }
}
