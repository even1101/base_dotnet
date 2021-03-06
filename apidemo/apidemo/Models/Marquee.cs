using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace apidemo.Models
{
    public partial class Marquee
    {
        public Marquee()
        {
            Announcement = new HashSet<Announcement>();
        }

        public Guid MarqueeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Subject { get; set; }
        public string Url { get; set; }
        public Guid FontColorId { get; set; }
        public Guid FontSizeId { get; set; }
        public bool IsEnable { get; set; }
        public string CreateEmployee { get; set; }
        public string CreateDepartment { get; set; }
        public DateTime CreateDateTime { get; set; }
        public string ModifyEmployee { get; set; }
        public string ModifyDepartment { get; set; }
        public DateTime ModifyDateTime { get; set; }

        public virtual CodeTable FontColor { get; set; }
        public virtual CodeTable FontSize { get; set; }
        public virtual ICollection<Announcement> Announcement { get; set; }
    }
}
