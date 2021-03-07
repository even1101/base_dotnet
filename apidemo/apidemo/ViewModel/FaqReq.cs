using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apidemo.ViewModel
{
    public class FaqReq
    {
        /// <summary>
        /// 主旨
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// 內容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 是否公開
        /// </summary>
        public bool? IsPublic { get; set; }
        /// <summary>
        /// 取得幾筆
        /// </summary>
        public int? Top { get; set; }
        /// <summary>
        /// 跳過幾筆
        /// </summary>
        public int? Skip { get; set; }
    }
}
