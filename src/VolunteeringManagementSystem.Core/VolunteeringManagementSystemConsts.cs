using VolunteeringManagementSystem.Debugging;

namespace VolunteeringManagementSystem
{
    public class VolunteeringManagementSystemConsts
    {
        public const string LocalizationSourceName = "VolunteeringManagementSystem";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "cd4e9fe7104e448eb8dd8fba2273ade0";
    }
}
