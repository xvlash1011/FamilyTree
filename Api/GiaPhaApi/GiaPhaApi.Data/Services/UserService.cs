using GiaPhaApi.Data.Tables;
using System.Threading.Tasks;

namespace GiaPhaApi.Data.Services
{
    public class UserService
    {
        private readonly GiaPhaApiDbContext context;

        public UserService(GiaPhaApiDbContext context)
        {
            this.context = context;
        }

        public async Task<User> Create(User user)
        {
            this.context.Users.Add(user);
            await context.SaveChangesAsync();
            return user;
        }

        public async Task<User> Get(long id)
        {
            return await this.context.Users.FindAsync(id);
        }

        public async Task Edit(User value)
        {
            var user = await this.context.Users.FindAsync(value.Id);
            user.UserId = value.UserId;
            user.UserName = value.UserName;
            user.Password = value.Password;
            user.Role = value.Role;
            await context.SaveChangesAsync();
        }
    }
}
