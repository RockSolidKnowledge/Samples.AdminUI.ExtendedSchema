using System.Collections.Generic;
using IdentityExpress.Identity;

namespace Rsk.Samples.AdminUI.ExtendedSchema
{
    public class ExtendedUser : IdentityExpressUser
    {
        public int? DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }

    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<ExtendedUser> Users { get; set; }
    }
}