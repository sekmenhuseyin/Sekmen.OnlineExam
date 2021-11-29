using Sekmen.OnlineExam.Exams;
using Sekmen.OnlineExam.Exams.Dto;
using Sekmen.OnlineExam.ExamsQuestions;
using Sekmen.OnlineExam.ExamsQuestions.Dto;
using Sekmen.OnlineExam.ExamsQuestionsAnswers;
using Sekmen.OnlineExam.ExamsQuestionsAnswers.Dto;
using Shouldly;
using System.Linq;
using Xunit;

namespace Sekmen.OnlineExam.Tests.Exams
{
    public class AnswerAppService_Tests : OnlineExamTestBase
    {
        private readonly IExamAppService _examAppService;
        private readonly IQuestionAppService _questionAppService;
        private readonly IAnswerAppService _answerAppService;

        public AnswerAppService_Tests()
        {
            _examAppService = Resolve<IExamAppService>();
            _questionAppService = Resolve<IQuestionAppService>();
            _answerAppService = Resolve<IAnswerAppService>();
        }

        [Fact]
        public void GetAnswers_Test()
        {
            // Act
            var exam = _examAppService.GetAll(new PagedExamResultRequestDto()).Items.First();
            var question = _questionAppService.GetAll(new PagedQuestionResultRequestDto { ExamId = exam.Id }).Items.First();
            var output = _answerAppService.GetAll(new PagedAnswerResultRequestDto { QuestionId = question.Id });

            // Assert
            output.Items.Count.ShouldBeGreaterThan(0);
        }
    }
}
