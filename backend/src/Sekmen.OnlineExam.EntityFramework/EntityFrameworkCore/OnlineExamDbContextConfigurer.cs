using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Sekmen.OnlineExam.EntityFrameworkCore
{
    public static class OnlineExamDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<OnlineExamDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<OnlineExamDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
