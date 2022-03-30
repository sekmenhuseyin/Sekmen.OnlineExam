using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using Sekmen.OnlineExam.Controllers;
using Sekmen.OnlineExam.Exams;
using System;

namespace Sekmen.OnlineExam.Web.Controllers
{
    public class ExamsController : OnlineExamControllerBase
    {
        private readonly IExamAppService _examAppService;

        public ExamsController(IExamAppService examAppService)
        {
            _examAppService = examAppService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult EditModal(Guid examId)
        {
            var exam = _examAppService.Get(new EntityDto<Guid>(examId));
            return PartialView("_EditModal", exam);
        }
    }
}
