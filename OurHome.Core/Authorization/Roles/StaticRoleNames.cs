namespace OurHome.Authorization.Roles
{
    public static class StaticRoleNames
    {
        public static class Host
        {
            public const string Admin = "Admin";
        }

        public static class Tenants
        {
            /// <summary>
            /// Администратор с полным доступом
            /// </summary>
            public const string Admin = "Admin";

            /// <summary>
            /// Пользователь системы
            /// </summary>
            public const string User = "user";
        }
    }
}