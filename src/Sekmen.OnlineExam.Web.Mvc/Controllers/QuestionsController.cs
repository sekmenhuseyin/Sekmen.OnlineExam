using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using Sekmen.OnlineExam.Controllers;
using Sekmen.OnlineExam.ExamsQuestions;
using System;

namespace Sekmen.OnlineExam.Web.Controllers
{
    public class QuestionsController : OnlineExamControllerBase
    {
        private readonly IQuestionAppService _questionAppService;

        public QuestionsController(IQuestionAppService questionAppService)
        {
            _questionAppService = questionAppService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult EditModal(Guid questionId)
        {
            var question = _questionAppService.Get(new EntityDto<Guid>(questionId));
            return PartialView("_EditModal", question);
        }
    }
}
