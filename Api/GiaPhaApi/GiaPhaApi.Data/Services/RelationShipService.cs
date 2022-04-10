using GiaPhaApi.Data.Tables;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace GiaPhaApi.Data.Services
{
    public class RelationShipService
    {
        private readonly GiaPhaApiDbContext context;

        public RelationShipService(GiaPhaApiDbContext context)
        {
            this.context = context;
        }

        public async Task Add(RelationShip value)
        {
            this.context.RelationShips.Add(value);
            await context.SaveChangesAsync();
        }

        public async Task Remove(RelationShip value)
        {
            var relationShip = context.RelationShips.AsNoTracking()
                .Where(e => e.LeftId == value.LeftId && e.RightId == value.RightId)
                .FirstOrDefault();

            context.Entry(relationShip).State = System.Data.Entity.EntityState.Deleted;
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<RelationShip>> GetAllOf(long id)
        {
            return await this.context.RelationShips.AsNoTracking()
                .Where(e => e.LeftId == id)
                .ToArrayAsync();
        }
    }
}
