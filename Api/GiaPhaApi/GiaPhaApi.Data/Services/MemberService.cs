using GiaPhaApi.Data.Tables;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace GiaPhaApi.Data.Services
{
  public class MemberService
  {
    private readonly GiaPhaApiDbContext context;

    public MemberService(GiaPhaApiDbContext context)
    {
      this.context = context;
    }

    public async Task<Member> Create(Member member)
    {
      this.context.Members.Add(member);
      await context.SaveChangesAsync();
      return member;
    }

    public async Task<Member> Get(long id)
    {
      return await this.context.Members.FindAsync(id);
    }

    public async Task Edit(Member value)
    {
      var member = await this.context.Members.FindAsync(value.Id);
      member.Name = value.Name;
      member.Sex = value.Sex;
      member.Generation = value.Generation;
      member.BirthDay = value.BirthDay;
      member.DeadDay = value.DeadDay;
      member.Status = value.Status;
      member.HomeTown = value.HomeTown;
      member.BestRole = value.BestRole;
      member.Address = value.Address;
      member.Phone = value.Phone;
      member.Picture = value.Picture;
      member.Note = value.Note;
      member.AddDate = value.AddDate;
      member.RoleId = value.RoleId;
      member.EthnicId = value.EthnicId;
      await context.SaveChangesAsync();
    }
  }
}
