using GiaPhaApi.Data.Tables;
using System.Threading.Tasks;

namespace GiaPhaApi.Data.Services
{
  public class EthnicService
  {
    private readonly GiaPhaApiDbContext context;

    public EthnicService(GiaPhaApiDbContext context)
    {
      this.context = context;
    }

    public async Task<Ethnic> Create(Ethnic ethnic)
    {
      this.context.Ethnics.Add(ethnic);
      await context.SaveChangesAsync();
      return ethnic;
    }

    public async Task<Ethnic> Get(long id)
    {
      return await this.context.Ethnics.FindAsync(id);
    }

    public async Task Edit(Ethnic value)
    {
      var ethnic = await this.context.Ethnics.FindAsync(value.Id);
      ethnic.Name = value.Name;
      await context.SaveChangesAsync();
    }
  }
}
