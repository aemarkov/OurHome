using System.Threading.Tasks;
using Abp.Application.Services;
using OurHome.Roles.Dto;

namespace OurHome.Roles
{
    public interface IRoleAppService : IApplicationService
    {
        Task UpdateRolePermissions(UpdateRolePermissionsInput input);
    }
}
