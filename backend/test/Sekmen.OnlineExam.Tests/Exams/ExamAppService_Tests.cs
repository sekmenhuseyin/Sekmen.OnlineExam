﻿using Microsoft.EntityFrameworkCore;
using Sekmen.OnlineExam.Exams;
using Sekmen.OnlineExam.Exams.Dto;
using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace Sekmen.OnlineExam.Tests.Exams
{
    public class ExamAppService_Tests : OnlineExamTestBase
    {
        private readonly IExamAppService _examAppService;

        public ExamAppService_Tests()
        {
            _examAppService = Resolve<IExamAppService>();
        }

        [Fact]
        public void GetExams_Test()
        {
            // Act
            var output = _examAppService.GetAll(new PagedExamResultRequestDto());

            // Assert
            output.Items.Count.ShouldBeGreaterThan(0);
        }

        [Fact]
        public async Task CreateExams_TestAsync()
        {
            // Act
            _examAppService.Create(new CreateUpdateExamDto
            {
                Name = "test",
                Description = "test",
                Duration = 10
            });

            // Assert
            await UsingDbContextAsync(async context =>
            {
                var johnNashUser = await context.Exams.FirstOrDefaultAsync(u => u.Name == "test");
                johnNashUser.ShouldNotBeNull();
            });
        }
    }
}
