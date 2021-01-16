namespace AdminProject.CommonLayer.Infrastructure
{
    public static class KnownAppSettingsKeys
    {
        public const string AuthenticationMode = "AuthenticationMode";

        public const string Authentication2FAMode = "Authentication2FAMode";

        public const string CpaSsoClientId = "cpa.sso.clientId";

        public const string CpaIppUrl = "cpa.ipp.url";

        public const string CpaApiUrl = "cpa.api.url";

        public const string SessionCookieName = "SessionCookieName";

        public const string SessionCookiePath = "SessionCookiePath";

        public const string SessionCookieDomain = "SessionCookieDomain";

        public const string ParentPath = "ParentPath";

        public const string SignInUrl = "SignInUrl";

        public const string ContactUsEmailAddress = "ContactUsEmailAddress";

        public const string InprotechWikiLink = "InprotechWikiLink";

        public const string ProductImprovement = "ProductImprovement";
    }

    public static class KnownConnectionStrings
    {
        public const string Inprotech = "Inprotech";
    }

    public class KnownSetupSettingKeys
    {
        public const string ConfigGroup = "Inprotech.Server";
        public const string ConfigKey = "Setup";
        public const string CookieConsentBannerHook = "CookieConsentBannerHook";
        public const string CookieDeclarationHook = "CookieDeclarationHook";
        public const string CookieResetConsentHook = "CookieResetConsentHook";
        public const string CookieConsentVerificationHook = "CookieConsentVerificationHook";
        public const string PreferenceConsentVerificationHook = "PreferenceConsentVerificationHook";
        public static string ConfigurationKey => $"{ConfigGroup}.{ConfigKey}";
    }

}
