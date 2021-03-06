using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace apidemo.Models
{
    public partial class Menu
    {
        public Menu()
        {
            InverseParentMenu = new HashSet<Menu>();
            RoleAuthorize = new HashSet<RoleAuthorize>();
        }

        public Guid MenuId { get; set; }
        public Guid? ParentMenuId { get; set; }
        public string Url { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int OrderNo { get; set; }
        public string Memo { get; set; }
        public string CreateEmployee { get; set; }
        public string CreateDepartment { get; set; }
        public DateTime CreateDateTime { get; set; }
        public string ModifyEmployee { get; set; }
        public string ModifyDepartment { get; set; }
        public DateTime ModifyDateTime { get; set; }

        public virtual Menu ParentMenu { get; set; }
        public virtual ICollection<Menu> InverseParentMenu { get; set; }
        public virtual ICollection<RoleAuthorize> RoleAuthorize { get; set; }
    }
}
