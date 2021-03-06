using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace apidemo.Models
{
    public partial class UserLog
    {
        public Guid UserLogId { get; set; }
        public string EmployeeNo { get; set; }
        public string EmployeeName { get; set; }
        public string DepartmentNo { get; set; }
        public string DepartmentName { get; set; }
        public string MenuCode { get; set; }
        public string MenuName { get; set; }
        public string MenuAuthorityCode { get; set; }
        public string MenuAuthorityName { get; set; }
        public string Memo { get; set; }
        public bool IsSuccess { get; set; }
        public DateTime LogDateTime { get; set; }
        public string SourceIp { get; set; }
    }
}
