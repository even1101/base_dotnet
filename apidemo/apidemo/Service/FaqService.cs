using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apidemo.Inertface;
using apidemo.Models;
using apidemo.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace apidemo.Service
{
    public class FaqService : IFaqService
    {
        //demo使用 通常會在包一層  不會直接使用_context
        private readonly BOTBRMContext _context;
        public FaqService(BOTBRMContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 新增一筆Faq
        /// </summary>
        /// <param name="model">Faq Table裡的欄位</param>
        /// <returns></returns>
        public async Task AddFaqAsync(Faq model)
        {
            _context.Faq.Add(model);
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// 刪除一筆Faq
        /// </summary>
        /// <param name="id">Faq Table的PK(唯一值)</param>
        /// <returns></returns>
        public async Task DelFaqAsync(Guid id)
        {
            var entity = _context.Faq.FirstOrDefault(c => c.FaqId == id);
            if (entity != null)
            {
                _context.Faq.Remove(entity);
                await _context.SaveChangesAsync();
            }
            else {
                throw new Exception($"找不到id為{id}的資料");
            }
        }
        /// <summary>
        /// 修改一筆Faq
        /// </summary>
        /// <param name="model">Faq Table 裡的欄位 PK無法修改</param>
        /// <returns></returns>
        public async Task EditFaqAsync(Faq model)
        {
            _context.Update(model);
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// 取得指定FaqId 唯一值(Pk) 單筆紀錄
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Faq> GetFaqByIdAsync(Guid id)
        {
            var faq = await _context.Faq.FirstOrDefaultAsync(c => c.FaqId == id);
            if (faq == null)
            {
                throw new Exception($"找不到Id為{id}的資料");
            }
            return faq;
        }

        
        /// <summary>
        /// 取得指定查詢條件清單(多筆)分頁
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<List<Faq>> GetFaqListAsync(FaqReq req)
        {
            var query = _context.Faq.Where(c => true);

            if (!string.IsNullOrWhiteSpace(req.Content))
            {
                query = query.Where(c => c.Content.Contains(req.Content));
            }

            if (!string.IsNullOrWhiteSpace(req.Subject))
            {
                query = query.Where(c => c.Subject.Contains(req.Subject));
            }

            if (req.IsPublic.HasValue)
            {
                query = query.Where(c => c.IsPublic == req.IsPublic.Value);
            }

            if (req.Top.HasValue)
            {
                query = query.Take(req.Top.Value);
            }

            if (req.Skip.HasValue)
            {
                query = query.Skip(req.Skip.Value);
            }

            var faqs = await query.OrderBy(o=>o.OrderNo).ToListAsync();

            return faqs;
        }

        /// <summary>
        /// 取得顏色下拉選單
        /// </summary>
        /// <returns></returns>
        public async Task<List<CodeTable>> GetFontColorList()
        {
            var res = await _context.CodeTable
                .Where(c => c.CodeTypeId == Guid.NewGuid())
                .OrderBy(o=>o.OrderNo)
                .ToListAsync();
            return res;
        }
    }
}
