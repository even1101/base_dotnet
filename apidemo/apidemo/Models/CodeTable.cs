using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace apidemo.Models
{
    public partial class CodeTable
    {
        public CodeTable()
        {
            Announcement = new HashSet<Announcement>();
            Attachment = new HashSet<Attachment>();
            DepartmentDepartmentTeam = new HashSet<Department>();
            DepartmentDepartmentType = new HashSet<Department>();
            DepartmentGeographyArea = new HashSet<Department>();
            DepartmentManageArea = new HashSet<Department>();
            DepartmentManager = new HashSet<DepartmentManager>();
            Faq = new HashSet<Faq>();
            InverseCodeType = new HashSet<CodeTable>();
            InverseParentCodeTable = new HashSet<CodeTable>();
            MarqueeFontColor = new HashSet<Marquee>();
            MarqueeFontSize = new HashSet<Marquee>();
            RoleFlow = new HashSet<RoleFlow>();
        }

        public Guid CodeTableId { get; set; }
        public Guid? ParentCodeTableId { get; set; }
        public Guid CodeTypeId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Memo { get; set; }
        public bool IsReadOnly { get; set; }
        public int OrderNo { get; set; }
        public string CreateEmployee { get; set; }
        public string CreateDepartment { get; set; }
        public DateTime CreateDateTime { get; set; }
        public string ModifyEmployee { get; set; }
        public string ModifyDepartment { get; set; }
        public DateTime ModifyDateTime { get; set; }
        public string DeleteEmployee { get; set; }
        public string DeleteDepartment { get; set; }
        public DateTime? DeleteDateTime { get; set; }

        public virtual CodeTable CodeType { get; set; }
        public virtual CodeTable ParentCodeTable { get; set; }
        public virtual ICollection<Announcement> Announcement { get; set; }
        public virtual ICollection<Attachment> Attachment { get; set; }
        public virtual ICollection<Department> DepartmentDepartmentTeam { get; set; }
        public virtual ICollection<Department> DepartmentDepartmentType { get; set; }
        public virtual ICollection<Department> DepartmentGeographyArea { get; set; }
        public virtual ICollection<Department> DepartmentManageArea { get; set; }
        public virtual ICollection<DepartmentManager> DepartmentManager { get; set; }
        public virtual ICollection<Faq> Faq { get; set; }
        public virtual ICollection<CodeTable> InverseCodeType { get; set; }
        public virtual ICollection<CodeTable> InverseParentCodeTable { get; set; }
        public virtual ICollection<Marquee> MarqueeFontColor { get; set; }
        public virtual ICollection<Marquee> MarqueeFontSize { get; set; }
        public virtual ICollection<RoleFlow> RoleFlow { get; set; }
    }
}
