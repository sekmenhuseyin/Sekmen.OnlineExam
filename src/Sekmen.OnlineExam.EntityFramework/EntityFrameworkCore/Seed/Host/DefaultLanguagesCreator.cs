using Abp.Localization;
using Abp.MultiTenancy;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Sekmen.OnlineExam.EntityFrameworkCore.Seed.Host
{
    public class DefaultLanguagesCreator
    {
        public static List<ApplicationLanguage> InitialLanguages => GetInitialLanguages();

        private readonly OnlineExamDbContext _context;

        private static List<ApplicationLanguage> GetInitialLanguages()
        {
            var tenantId = OnlineExamConsts.MultiTenancyEnabled ? null : (int?)MultiTenancyConsts.DefaultTenantId;
            return new List<ApplicationLanguage>
            {
                new ApplicationLanguage(tenantId, "en", "English", "famfamfam-flags us"),
                new ApplicationLanguage(tenantId, "de", "German", "famfamfam-flags de"),
                new ApplicationLanguage(tenantId, "it", "Italiano", "famfamfam-flags it"),
                new ApplicationLanguage(tenantId, "fr", "Français", "famfamfam-flags fr"),
                new ApplicationLanguage(tenantId, "pt-BR", "Português", "famfamfam-flags br"),
                new ApplicationLanguage(tenantId, "tr", "Türkçe", "famfamfam-flags tr"),
                new ApplicationLanguage(tenantId, "es", "Español", "famfamfam-flags es"),
                new ApplicationLanguage(tenantId, "nl", "Nederlands", "famfamfam-flags nl")
            };
        }

        public DefaultLanguagesCreator(OnlineExamDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateLanguages();
        }

        private void CreateLanguages()
        {
            foreach (var language in InitialLanguages)
            {
                AddLanguageIfNotExists(language);
            }
        }

        private void AddLanguageIfNotExists(ApplicationLanguage language)
        {
            if (_context.Languages.IgnoreQueryFilters().Any(l => l.TenantId == language.TenantId && l.Name == language.Name))
            {
                return;
            }

            _context.Languages.Add(language);
            _context.SaveChanges();
        }
    }
}
