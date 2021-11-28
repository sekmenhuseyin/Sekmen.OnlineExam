using Sekmen.OnlineExam.Debugging;

namespace Sekmen.OnlineExam
{
    public class OnlineExamConsts
    {
        public const string LocalizationSourceName = "OnlineExam";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = false;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "6e211ff8d12b443fb9b92870f149313d";
    }
}
