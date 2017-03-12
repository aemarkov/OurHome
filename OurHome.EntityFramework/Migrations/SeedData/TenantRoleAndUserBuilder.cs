using System.Linq;
using Abp.Authorization;
using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using Abp.MultiTenancy;
using Microsoft.AspNet.Identity;
using OurHome.Authorization;
using OurHome.Authorization.Roles;
using OurHome.EntityFramework;
using OurHome.Users;

namespace OurHome.Migrations.SeedData
{
    public class TenantRoleAndUserBuilder
    {
        private readonly OurHomeDbContext _context;
        private readonly int _tenantId;

        public TenantRoleAndUserBuilder(OurHomeDbContext context, int tenantId)
        {
            _context = context;
            _tenantId = tenantId;
        }

        public void Create()
        {
            CreateRolesAndUsers();
        }

        private void CreateRolesAndUsers()
        {
            //Создаем роли
            
            //Админ
            var adminRole = CreateRoleIfNotExists(StaticRoleNames.Tenants.Admin);

            GrantPermission(_context, PermissionNames.Pages, adminRole.Id, _tenantId);
            GrantPermission(_context, PermissionNames.Admininstration, adminRole.Id, _tenantId);

            //Пользователь
            var userRole = CreateRoleIfNotExists(StaticRoleNames.Tenants.User);

            GrantPermission(_context, PermissionNames.Pages, userRole.Id, _tenantId);
            GrantPermission(_context, PermissionNames.User, userRole.Id, _tenantId);

            //Создаем пользователей
            //Админ
            var adminUser = _context.Users.FirstOrDefault(u => u.TenantId == _tenantId && u.UserName == User.AdminUserName);
            if (adminUser == null)
            {
                adminUser = User.CreateTenantAdminUser(_tenantId, "admin@ourhome", "admin");
                adminUser.IsEmailConfirmed = true;
                adminUser.IsActive = true;

                _context.Users.Add(adminUser);
                _context.SaveChanges();

                //Assign Admin role to admin user
                _context.UserRoles.Add(new UserRole(_tenantId, adminUser.Id, adminRole.Id));
                _context.SaveChanges();
            }

            //Пользователь
            var user = _context.Users.FirstOrDefault(u => u.TenantId == _tenantId && u.UserName == "User");
            if (user == null)
            {
                user = new User
                {
                    TenantId = _tenantId,
                    UserName = "user",
                    Name = "Иван",
                    Surname = "Иванов",
                    EmailAddress = "user@ourhome",
                    Password = new PasswordHasher().HashPassword("user")
                };

                user.IsEmailConfirmed = true;
                user.IsActive = true;

                _context.Users.Add(user);
                _context.SaveChanges();

                //Assign Admin role to admin user
                _context.UserRoles.Add(new UserRole(_tenantId, user.Id, userRole.Id));
                _context.SaveChanges();
            }
        }

        //Добавляет разрешение в роль
        private void GrantPermission(OurHomeDbContext context, string permission, int roleId, int tenantId)
        {
            if (!context.Permissions.OfType<RolePermissionSetting>().Any(x => x.RoleId == roleId && x.TenantId == tenantId && x.Name == permission && x.IsGranted))
            {
                context.Permissions.Add(new RolePermissionSetting()
                {
                    Name = permission,
                    IsGranted = true,
                    RoleId = roleId,
                    TenantId = tenantId
                });
            }
        }

        private Role CreateRoleIfNotExists(string roleName)
        {
            var role = _context.Roles.FirstOrDefault(r => r.TenantId == _tenantId && r.Name == roleName);
            if (role == null)
            {
                role = _context.Roles.Add(new Role(_tenantId, roleName, roleName)
                {
                    IsStatic = true
                });

                _context.SaveChanges();
            }

            return role;
        }
    }
}