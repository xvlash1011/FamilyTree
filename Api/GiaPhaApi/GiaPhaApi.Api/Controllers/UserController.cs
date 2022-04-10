using Microsoft.AspNetCore.Mvc;
using GiaPhaApi.Data.Services;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GiaPhaApi.Api.Controllers
{
    [ApiController]
    [Route("User")]
    public class UserController : ControllerBase
    {
        private readonly UserService userService;

        public UserController(UserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<RegisterResponse> Register(RegisterParams args)
        {
            var newUser = new Data.Tables.User
            {
                Id = args.Id,
                UserId = args.UserId,
                UserName = args.UserName,
                Password = args.Password,
                Role=   args.Role
            };

            await this.userService.Create(newUser);

            return new RegisterResponse
            {
                Id = newUser.Id,
                UserId = newUser.UserId,
                Role = newUser.Role,
                UserName = newUser.UserName,
                Password=newUser.Password,

            };
        }

        [HttpGet]
        [Route("get")]
        public async Task<GetUserResponse> Get(long id)
        {
            var value = await this.userService.Get(id);
            return new GetUserResponse
            {
                Id=value.Id,
                UserId= value.UserId,
                Role= value.Role,
                UserName=value.UserName,
                Password=value.Password
            };
        }
    }

    public class GetUserResponse
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Role { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class RegisterResponse
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Role { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

    }

    public class RegisterParams
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Role { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
