namespace Sekmen.OnlineExam.EntityFrameworkCore.Seed.Host
{
    public class InitialHostDbBuilder
    {
        private readonly OnlineExamDbContext _context;

        public InitialHostDbBuilder(OnlineExamDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            new DefaultEditionCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();
            new DefaultExamCreator(_context).Create();

            _context.SaveChanges();
        }
    }
}
