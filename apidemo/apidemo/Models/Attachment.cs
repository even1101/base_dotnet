using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace apidemo.Models
{
    public partial class Attachment
    {
        public Guid AttachmentId { get; set; }
        public Guid AttachmentTypeId { get; set; }
        public Guid ReferenceId { get; set; }
        public string OriginalName { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public string FileDescription { get; set; }
        public string CreateEmployee { get; set; }
        public string CreateDepartment { get; set; }
        public DateTime CreateDateTime { get; set; }
        public string ModifyEmployee { get; set; }
        public string ModifyDepartment { get; set; }
        public DateTime ModifyDateTime { get; set; }

        public virtual CodeTable AttachmentType { get; set; }
    }
}
