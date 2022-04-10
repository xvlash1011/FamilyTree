using GiaPhaApi.Data.Tables;
using System.Threading.Tasks;

namespace GiaPhaApi.Data.Services
{
    public class RelationService
    {
        private readonly GiaPhaApiDbContext context;

        public RelationService(GiaPhaApiDbContext context)
        {
            this.context = context;
        }

        public async Task<Relation> Create(Relation relation)
        {
            this.context.Relations.Add(relation);
            await context.SaveChangesAsync();
            return relation;
        }

        public async Task<Relation> Get(long id)
        {
            return await this.context.Relations.FindAsync(id);
        }

        public async Task Edit(Relation value)
        {
            var relation = await this.context.Relations.FindAsync(value.Id);
            relation.Name = value.Name;
            await context.SaveChangesAsync();
        }
    }
}
