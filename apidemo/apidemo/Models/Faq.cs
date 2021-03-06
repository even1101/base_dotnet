using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace apidemo.Models
{
    public partial class Faq
    {
        public Guid FaqId { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public Guid FontColorId { get; set; }
        public bool IsPublic { get; set; }
        public bool IsCancel { get; set; }
        public int OrderNo { get; set; }
        public string CreateEmployee { get; set; }
        public string CreateDepartment { get; set; }
        public DateTime CreateDateTime { get; set; }
        public string ModifyEmployee { get; set; }
        public string ModifyDepartment { get; set; }
        public DateTime ModifyDateTime { get; set; }

        public virtual CodeTable FontColor { get; set; }
    }
}
