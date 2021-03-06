using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace apidemo.Models
{
    public partial class Role
    {
        public Role()
        {
            RoleAuthorize = new HashSet<RoleAuthorize>();
            RoleFlow = new HashSet<RoleFlow>();
        }

        public Guid RoleId { get; set; }
        public string InfoNo { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Memo { get; set; }
        public int OrderNo { get; set; }
        public string CreateEmployee { get; set; }
        public string CreateDepartment { get; set; }
        public DateTime CreateDateTime { get; set; }
        public string ModifyEmployee { get; set; }
        public string ModifyDepartment { get; set; }
        public DateTime ModifyDateTime { get; set; }

        public virtual ICollection<RoleAuthorize> RoleAuthorize { get; set; }
        public virtual ICollection<RoleFlow> RoleFlow { get; set; }
    }
}
