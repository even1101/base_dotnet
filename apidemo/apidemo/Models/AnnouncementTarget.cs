using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace apidemo.Models
{
    public partial class AnnouncementTarget
    {
        public Guid AnnouncementTargetId { get; set; }
        public Guid AnnouncementId { get; set; }
        public Guid? DepartmentId { get; set; }
        public Guid? EmployeeId { get; set; }

        public virtual Announcement Announcement { get; set; }
        public virtual Department Department { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
