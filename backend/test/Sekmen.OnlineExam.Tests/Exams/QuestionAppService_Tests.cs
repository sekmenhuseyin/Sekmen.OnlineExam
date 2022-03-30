using Sekmen.OnlineExam.Exams;
using Sekmen.OnlineExam.Exams.Dto;
using Sekmen.OnlineExam.ExamsQuestions;
using Sekmen.OnlineExam.ExamsQuestions.Dto;
using Shouldly;
using System.Linq;
using Xunit;

namespace Sekmen.OnlineExam.Tests.Exams
{
    public class QuestionAppService_Tests : OnlineExamTestBase
    {
        private readonly IExamAppService _examAppService;
        private readonly IQuestionAppService _questionAppService;

        public QuestionAppService_Tests()
        {
            _examAppService = Resolve<IExamAppService>();
            _questionAppService = Resolve<IQuestionAppService>();
        }

        [Fact]
        public void GetExams_Test()
        {
            // Act
            var exam = _examAppService.GetAll(new PagedExamResultRequestDto()).Items.First();
            var output = _questionAppService.GetAll(new PagedQuestionResultRequestDto { ExamId = exam.Id });

            // Assert
            output.Items.Count.ShouldBeGreaterThan(0);
        }
    }
}
