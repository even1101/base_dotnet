using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace apidemo.Models
{
    public partial class Announcement
    {
        public Announcement()
        {
            AnnouncementTarget = new HashSet<AnnouncementTarget>();
        }

        public Guid AnnouncementId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public Guid StressTypeId { get; set; }
        public Guid? MarqueeId { get; set; }
        public bool IsPublic { get; set; }
        public string CreateEmployee { get; set; }
        public string CreateDepartment { get; set; }
        public DateTime CreateDateTime { get; set; }
        public string ModifyEmployee { get; set; }
        public string ModifyDepartment { get; set; }
        public DateTime ModifyDateTime { get; set; }

        public virtual Marquee Marquee { get; set; }
        public virtual CodeTable StressType { get; set; }
        public virtual ICollection<AnnouncementTarget> AnnouncementTarget { get; set; }
    }
}
