using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apidemo.Inertface;
using apidemo.Models;
using apidemo.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Logging;

namespace apidemo.Controllers
{
    public class FaqController : Controller
    {
        private readonly ILogger<FaqController> _logger;
        private readonly IFaqService _faqServcie;

        public FaqController(ILogger<FaqController> logger, IFaqService faqServcie)
        {
            _logger = logger;
            _faqServcie = faqServcie;
        }

        #region 首頁Index
        [HttpGet]
        public IActionResult Index()
        {
            var fakeData = new List<Faq>();
            fakeData.Add(new Faq
            {
                FaqId = Guid.NewGuid(),
                IsCancel = true,
                IsPublic = false,
                CreateEmployee = "betty",
                ModifyEmployee = "betty",
                Subject = "主旨",
                Content = "123344556677",
                FontColorId = new Guid("DAD706EA-91AA-4CA5-8058-0F64601C5F25"),
                OrderNo = 1,
                CreateDepartment = "企業金融部",
                ModifyDepartment = "企業金融部",
                CreateDateTime = DateTime.Now,
                ModifyDateTime = DateTime.Now
            });
            return View(fakeData);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] FaqReq req)
        {
            var res = await _faqServcie.GetFaqListAsync(req);
            return Ok(res);
        }
        #endregion

        #region 新增Add
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var faq = new Faq
            {
                FaqId = Guid.NewGuid(),
                FontColorId = new Guid("DAD706EA-91AA-4CA5-8058-0F64601C5F25"),
                CreateDateTime = DateTime.Now,
                ModifyDateTime = DateTime.Now
            };
            ViewBag.SelectList = await GetFontColorSelectList();
            return View(faq);
        }
        [HttpPost]
        public async Task<IActionResult> Add(Faq model)
        {
            model.FaqId = Guid.NewGuid();
            model.FontColorId = new Guid("DAD706EA-91AA-4CA5-8058-0F64601C5F25");
            model.CreateDepartment = "企業金融部";
            model.ModifyDepartment = "企業金融部";
            model.CreateDateTime = DateTime.Now;
            model.ModifyDateTime = DateTime.Now;

            if (!ModelState.IsValid)
            {
                ViewBag.SelectList = await GetFontColorSelectList();
                return View(model);
            }

            await _faqServcie.AddFaqAsync(model);
            return RedirectToAction("Index");
        }
        #endregion

        #region 編輯Edit
        /// <summary>
        /// 查詢指定Faq詳細資料
        /// </summary>
        /// <param name="id">Faq Table Pk</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var res = new Faq {
                FaqId = Guid.NewGuid(),
                IsCancel = true,
                IsPublic = false,
                CreateEmployee = "betty",
                ModifyEmployee = "betty",
                Subject = "主旨",
                Content = "123344556677",
                FontColorId = new Guid("DAD706EA-91AA-4CA5-8058-0F64601C5F25"),
                OrderNo = 1,
                CreateDepartment = "企業金融部",
                ModifyDepartment = "企業金融部",
                CreateDateTime = DateTime.Now,
                ModifyDateTime = DateTime.Now
            };

            ViewBag.SelectList = await GetFontColorSelectList();
            //var res = await _faqServcie.GetFaqByIdAsync(id);
            return View(res);
        }
        /// <summary>
        /// 修改指定Faq 一筆資料
        /// </summary>
        /// <param name="model">修改的Faq資料</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Edit(Faq model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.SelectList = await GetFontColorSelectList();
                return View(model);
            }
            await _faqServcie.EditFaqAsync(model);
            return View(model);
        }
        #endregion
        /// <summary>
        /// 刪除指定Faq資料
        /// </summary>
        /// <param name="id">Faq Table PK</param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Del(Guid id)
        {
            await _faqServcie.DelFaqAsync(id);
            return Ok();
        }


        /// <summary>
        /// 取得FontColor下拉選單
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private async  Task<List<SelectListItem>> GetFontColorSelectList()
        {
            var selectList = new List<SelectListItem>();
            // 加入預設值
            selectList.Add(new SelectListItem
            {
                Text = "請選擇",
                Value = null,
                Selected = true // 預設會選擇這一筆
            });
            selectList.Add(new SelectListItem
            {
                Text = "紅色",
                Value = Guid.NewGuid().ToString(),
                Selected = false
            });

            //var list = await _faqServcie.GetFontColorList();
            //從資料庫抓取相關資料 有資料又進入以下邏輯
            //if (list.Any())
            //{
            //    var res = list.Select(c => new SelectListItem
            //    {
            //        Text = c.Name,
            //        Value = c.CodeTableId.ToString()
            //    });
            //    selectList.AddRange(res);
            //}

            return selectList;
        }
    }
}
