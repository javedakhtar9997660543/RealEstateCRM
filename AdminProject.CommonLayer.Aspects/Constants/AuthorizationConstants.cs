namespace AdminProject.CommonLayer.Aspects.Constants
{
    public class AuthorizationConstants
    {
        public static class Roles
        {
            public const string ADMINISTRATORS = "Admin";
        }

        // TODO: Don't use this in production
        public const string DEFAULT_PASSWORD = "Pass@word1";

        // TODO: Change this to an environment variable
        public const string JwtSecretKey = "xecretKeywqe123janedreamwedds";
    }
}
