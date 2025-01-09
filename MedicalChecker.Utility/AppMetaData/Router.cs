namespace MedicalChecker.Utility.AppMetaData
{
    public static class Router
    {
        public const string root = "Api";
        public const string version = "V1";
        public const string rule = $"{root}/{version}";
        public static class ApplicationUser
        {
            public const string Prefix = $"{rule}/User";
            public const string Create = $"{Prefix}/Create";
            public const string Update = $"{Prefix}/Update";
            public const string GetAll = $"{Prefix}/GetAll";
            public const string ChangePassword = $"{Prefix}/ChangePassword";
            public const string Count = $"{Prefix}/Count";
            public const string GetById = $"{Prefix}/Get/{{userId}}";
            public const string Delete = $"{Prefix}/Delete/{{userId}}";

        }

    }
}
