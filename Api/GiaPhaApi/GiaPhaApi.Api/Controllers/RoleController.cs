using Microsoft.AspNetCore.Mvc;
using GiaPhaApi.Data.Services;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace GiaPhaApi.Api.Controllers
{
    [ApiController]
    [Route("role")]
    public class RoleController : ControllerBase
    {
        private readonly RoleService roleService;

        public RoleController(RoleService roleService)
        {
            this.roleService = roleService;
        }

        [HttpPost]
        [Route("setRole")]
        public async Task<RoleResponse> Register(RoleParams args)
        {
            var newRole = new Data.Tables.Role
            {
                Name = args.Name
            };

            await this.roleService.Create(newRole);

            return new RoleResponse
            {
                Id = newRole.Id
            };
        }

        [HttpGet]
        [Route("get")]
        public async Task<GetRoleResponse> Get(long id)
        {
            var value = await this.roleService.Get(id);
            return new GetRoleResponse
            {
                Id = value.Id,
                Name = value.Name
            };
        }
    }

    public class GetRoleResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }

    public class RoleResponse
    {
        public long Id { get; set; }
    }

    public class RoleParams
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}
