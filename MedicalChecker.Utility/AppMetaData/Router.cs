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
            public const string GetUserRequests = $"{Prefix}/GetUserRequests";
            public const string Delete = $"{Prefix}/Delete/{{userId}}";

        }

        public static class Request
        {
            public const string Prefix = $"{rule}/Request";
            public const string Create = $"{Prefix}/Create";
            public const string GetAll = $"{Prefix}/GetAll";
            public const string Count = $"{Prefix}/Count";
            public const string GetById = $"{Prefix}/Get/{{id}}";
            public const string Download = $"{Prefix}/Download/{{id}}";
            public const string Delete = $"{Prefix}/Delete/{{requestId}}";
            public const string UpdateStatus = $"{Prefix}/UpdateStatus";

        }

    }
}
