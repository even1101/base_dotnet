using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apidemo.Inertface;
using apidemo.Models;
using apidemo.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace apidemo.Controllers
{
    [Route("JqFaq/[controller]")]

    public class JqFaqController : Controller
    {
        private readonly ILogger<JqFaqController> _logger;
        private readonly IFaqService _faqServcie;

        public JqFaqController(ILogger<JqFaqController> logger, IFaqService faqServcie)
        {
            _logger = logger;
            _faqServcie = faqServcie;
        }

        #region 首頁
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] FaqReq req)
        {
            var res = await _faqServcie.GetFaqListAsync(req);
            return Ok(res);
        }
        #endregion

        #region 新增
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Faq model)
        {
            await _faqServcie.AddFaqAsync(model);
            return Ok();
        }
        #endregion

        #region 編輯
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetFaqById(Guid id)
        {
            var res = await _faqServcie.GetFaqByIdAsync(id);
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Faq model)
        {
            await _faqServcie.EditFaqAsync(model);
            return Ok();
        }
        #endregion

        [HttpDelete]
        public async Task<IActionResult> Del(Guid id)
        {
            await _faqServcie.DelFaqAsync(id);
            return Ok();
        }
    }
}
