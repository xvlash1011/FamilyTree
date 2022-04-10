using GiaPhaApi.Data.Tables;
using System.Threading.Tasks;

namespace GiaPhaApi.Data.Services
{
    public class RoleService
    {
        private readonly GiaPhaApiDbContext context;

        public RoleService(GiaPhaApiDbContext context)
        {
            this.context = context;
        }

        public async Task<Role> Create(Role role)
        {
            this.context.Roles.Add(role);
            await context.SaveChangesAsync();
            return role;
        }

        public async Task<Role> Get(long id)
        {
            return await this.context.Roles.FindAsync(id);
        }

        public async Task Edit(Role value)
        {
            var role = await this.context.Roles.FindAsync(value.Id);
            role.Name = value.Name;
            await context.SaveChangesAsync();
        }
    }
}
