using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace apidemo.Models
{
    public partial class Employee
    {
        public Employee()
        {
            AnnouncementTarget = new HashSet<AnnouncementTarget>();
            DepartmentManager = new HashSet<DepartmentManager>();
        }

        public Guid EmployeeId { get; set; }
        public Guid DepartmentId { get; set; }
        public string Account { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime? IneffectiveDate { get; set; }
        public bool IsEnable { get; set; }
        public string CreateEmployee { get; set; }
        public string CreateDepartment { get; set; }
        public DateTime CreateDateTime { get; set; }
        public string ModifyEmployee { get; set; }
        public string ModifyDepartment { get; set; }
        public DateTime ModifyDateTime { get; set; }

        public virtual Department Department { get; set; }
        public virtual ICollection<AnnouncementTarget> AnnouncementTarget { get; set; }
        public virtual ICollection<DepartmentManager> DepartmentManager { get; set; }
    }
}
