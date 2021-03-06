using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace apidemo.Models
{
    public partial class RoleFlow
    {
        public Guid RoleFlowId { get; set; }
        public Guid RoleId { get; set; }
        public Guid DataPermissionId { get; set; }
        public bool IsEditable { get; set; }
        public bool IsReviewable { get; set; }
        public bool IsApprovable { get; set; }
        public bool IsMaintainable { get; set; }
        public string CreateEmployee { get; set; }
        public string CreateDepartment { get; set; }
        public DateTime CreateDateTime { get; set; }
        public string ModifyEmployee { get; set; }
        public string ModifyDepartment { get; set; }
        public DateTime ModifyDateTime { get; set; }

        public virtual CodeTable DataPermission { get; set; }
        public virtual Role Role { get; set; }
    }
}
