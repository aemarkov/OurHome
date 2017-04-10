using System;
using System.ComponentModel.DataAnnotations;
using Abp.Authorization.Users;
using Abp.Extensions;
using Microsoft.AspNet.Identity;

namespace OurHome.Users
{
    public class User : AbpUser<User>
    {
        #region VALIDATION
        public const int MaxMiddlenameLength = 32;
        #endregion

        #region PROPERTIES

        [MaxLength(MaxMiddlenameLength)]
        public string Middlename { get; set; }

        public override string FullName => $"{Surname} {Name} {Middlename}";  

        #endregion

        public const string DefaultPassword = "123qwe";

        public static string CreateRandomPassword()
        {
            return Guid.NewGuid().ToString("N").Truncate(16);
        }

        public static User CreateTenantAdminUser(int tenantId, string emailAddress, string password)
        {
            return new User
            {
                TenantId = tenantId,
                UserName = AdminUserName,
                Name = AdminUserName,
                Surname = AdminUserName,
                EmailAddress = emailAddress,
                Password = new PasswordHasher().HashPassword(password)
            };
        }
    }
}