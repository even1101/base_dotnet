using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apidemo.Models;
using apidemo.ViewModel;

namespace apidemo.Inertface
{
    public interface IFaqService
    {
        /// <summary>
        /// 取得指定查詢條件清單(多筆)分頁
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public Task<List<Faq>> GetFaqListAsync(FaqReq req);
        /// <summary>
        /// 取得指定FaqId 唯一值(Pk) 單筆紀錄
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Faq> GetFaqByIdAsync(Guid id);
        /// <summary>
        /// 新增一筆Faq
        /// </summary>
        /// <param name="model">Faq Table裡的欄位</param>
        /// <returns></returns>
        public Task AddFaqAsync(Faq model);
        /// <summary>
        /// 修改一筆Faq
        /// </summary>
        /// <param name="model">Faq Table 裡的欄位 PK無法修改</param>
        /// <returns></returns>
        public Task EditFaqAsync(Faq model);
        /// <summary>
        /// 刪除一筆Faq
        /// </summary>
        /// <param name="id">Faq Table的PK(唯一值)</param>
        /// <returns></returns>
        public Task DelFaqAsync(Guid id);
        /// <summary>
        /// 取得顏色下拉選單
        /// </summary>
        /// <returns></returns>
        public Task<List<CodeTable>> GetFontColorList();

    }
}
