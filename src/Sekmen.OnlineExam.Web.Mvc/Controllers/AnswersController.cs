using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc;
using Sekmen.OnlineExam.Controllers;
using Sekmen.OnlineExam.ExamsQuestionsAnswers;
using System;

namespace Sekmen.OnlineExam.Web.Controllers
{
    public class AnswersController : OnlineExamControllerBase
    {
        private readonly IAnswerAppService _answerAppService;

        public AnswersController(IAnswerAppService answerAppService)
        {
            _answerAppService = answerAppService;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult EditModal(Guid questionId)
        {
            var question = _answerAppService.Get(new EntityDto<Guid>(questionId));
            return PartialView("_EditModal", question);
        }
    }
}
