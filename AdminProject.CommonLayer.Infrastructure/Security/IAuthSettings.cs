using System;
using System.Linq;

namespace AdminProject.CommonLayer.Infrastructure.Security
{
  public interface IAuthSettings
    {
        int SessionTimeout { get; }
        string SessionCookieName { get; }
        string SessionCookiePath { get; }
        string SessionCookieDomain { get; }
        bool FormsEnabled { get; }
        bool WindowsEnabled { get; }
        bool SsoEnabled { get; }
        bool AdfsEnabled { get; }
        bool Internal2FaEnabled { get; }
        bool External2FaEnabled { get; }
        string SignInUrl { get; }
        bool TwoFactorAuthenticationEnabled(bool isUserExternal);
        bool AuthenticationModeEnabled(string authMode);
        CookieConsentFlags CookieConsentSettings { get; }
    }


    public class AuthSettings : IAuthSettings
    {
        public bool FormsEnabled { get; set; }

        public bool WindowsEnabled { get; set; }

        public bool SsoEnabled { get; set; }

        public bool AdfsEnabled { get; set; }

        public bool Internal2FaEnabled { get; set; }

        public bool External2FaEnabled { get; set; }

        public int SessionTimeout { get; set; }

        public string SessionCookieName { get; set; }

        public string SessionCookiePath { get; set; }

        public string SessionCookieDomain { get; set; }

        public string SignInUrl { get; set; }

        public CookieConsentFlags CookieConsentSettings { get; set; }

        public bool TwoFactorAuthenticationEnabled(bool isUserExternal)
        {
            return isUserExternal ? External2FaEnabled : Internal2FaEnabled;
        }

        public bool AuthenticationModeEnabled(string authMode)
        {
            switch (authMode)
            {
                case AuthenticationModeKeys.Forms:
                    return FormsEnabled;
                case AuthenticationModeKeys.Windows:
                    return WindowsEnabled;
                case AuthenticationModeKeys.Sso:
                    return SsoEnabled;
                case AuthenticationModeKeys.Adfs:
                    return AdfsEnabled;
            }

            return false;
        }
    }

    public static class AuthSettingsExt
    {
        static bool PreventManualLogout(this IAuthSettings settings)
        {
            return settings.WindowsEnabled && !settings.FormsEnabled && !settings.SsoEnabled;
        }
    }

    public class ConfiguredAuthMode
    {
        public ConfiguredAuthMode(string authModes)
        {
            var enabled = (authModes ?? string.Empty).Split(',').Select(x => x.Trim()).ToArray();

            FormsEnabled = enabled.Contains(AuthenticationModeKeys.Forms, StringComparer.InvariantCultureIgnoreCase);

            WindowsEnabled = enabled.Contains(AuthenticationModeKeys.Windows, StringComparer.InvariantCultureIgnoreCase);

            SsoEnabled = enabled.Contains(AuthenticationModeKeys.Sso, StringComparer.InvariantCultureIgnoreCase);

            AdfsEnabled = enabled.Contains(AuthenticationModeKeys.Adfs, StringComparer.InvariantCultureIgnoreCase);
        }

        public bool FormsEnabled { get; }

        public bool WindowsEnabled { get; }

        public bool SsoEnabled { get; }

        public bool AdfsEnabled { get; }
    }

    public static class AuthenticationModeKeys
    {
        public const string Forms = "Forms";
        public const string Windows = "Windows";
        public const string Sso = "Sso";
        public const string Adfs = "Adfs";
    }

    public class ConfiguredTwoFactorAuthMode
    {
        public ConfiguredTwoFactorAuthMode(string authModes)
        {
            var enabled = (authModes ?? string.Empty).Split(',').Select(x => x.Trim()).ToArray();

            InternalEnabled = enabled.Contains(TwoFactorAuthenticationModeKeys.Internal, StringComparer.InvariantCultureIgnoreCase);
            ExternalEnabled = enabled.Contains(TwoFactorAuthenticationModeKeys.External, StringComparer.InvariantCultureIgnoreCase);
        }

        public bool InternalEnabled { get; }

        public bool ExternalEnabled { get; }
    }

    public class CookieConsentFlags
    {
        public bool IsConfigured { get; set; }
        public bool IsResetConfigured { get; set; }
        public bool IsVerificationConfigured { get; set; }
    }

    public static class TwoFactorAuthenticationModeKeys
    {
        public const string Internal = "Internal";
        public const string External = "External";
    }
}
