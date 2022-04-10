using GiaPhaApi.Data.Tables;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace GiaPhaApi.Data
{
  public class GiaPhaApiDbContext : DbContext
  {
    public DbSet<User> Users { get; set; }
    public DbSet<Relation> Relations { get; set; }
    public DbSet<Ethnic> Ethnics { get; set; }
    public DbSet<Member> Members { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<RelationShip> RelationShips { get; set; }
    public DbSet<Request> Requests { get; set; }

    public GiaPhaApiDbContext() : base($"Server=DESKTOP-POKSIMK;Database=GIAPHA;User Id=sa;Password=123;") { }
    public GiaPhaApiDbContext(string connectionString) : base(connectionString) { }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
      modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
      modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

    }
  }
}
