using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace apidemo.Models
{
    public partial class Department
    {
        public Department()
        {
            AnnouncementTarget = new HashSet<AnnouncementTarget>();
            DepartmentManager = new HashSet<DepartmentManager>();
            Employee = new HashSet<Employee>();
            InverseMergeDepartment = new HashSet<Department>();
            InverseParentDepartment = new HashSet<Department>();
            VisitTarget = new HashSet<VisitTarget>();
        }

        public Guid DepartmentId { get; set; }
        public Guid? ParentDepartmentId { get; set; }
        public Guid? MergeDepartmentId { get; set; }
        public Guid DepartmentTypeId { get; set; }
        public Guid? GeographyAreaId { get; set; }
        public Guid? ManageAreaId { get; set; }
        public Guid DepartmentTeamId { get; set; }
        public string DepartmentNo { get; set; }
        public string Name { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime? IneffectiveDate { get; set; }
        public int OrderNo { get; set; }
        public bool IsDisplay { get; set; }
        public bool IsEnable { get; set; }
        public string CreateEmployee { get; set; }
        public string CreateDepartment { get; set; }
        public DateTime CreateDateTime { get; set; }
        public string ModifyEmployee { get; set; }
        public string ModifyDepartment { get; set; }
        public DateTime ModifyDateTime { get; set; }

        public virtual CodeTable DepartmentTeam { get; set; }
        public virtual CodeTable DepartmentType { get; set; }
        public virtual CodeTable GeographyArea { get; set; }
        public virtual CodeTable ManageArea { get; set; }
        public virtual Department MergeDepartment { get; set; }
        public virtual Department ParentDepartment { get; set; }
        public virtual ICollection<AnnouncementTarget> AnnouncementTarget { get; set; }
        public virtual ICollection<DepartmentManager> DepartmentManager { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }
        public virtual ICollection<Department> InverseMergeDepartment { get; set; }
        public virtual ICollection<Department> InverseParentDepartment { get; set; }
        public virtual ICollection<VisitTarget> VisitTarget { get; set; }
    }
}
