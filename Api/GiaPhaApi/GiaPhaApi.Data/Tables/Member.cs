using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GiaPhaApi.Data.Tables
{
  public class Member
  {
    [Key]
    public long Id { get; set; }

    [StringLength(255)]
    public string Name { get; set; }
    public bool Sex { get; set; }
    public long Generation { get; set; }
    public string BirthDay { get; set; }
    public string DeadDay { get; set; }
    public bool Status { get; set; }
    public string HomeTown { get; set; }
    public string BestRole { get; set; }
    public string Address { get; set; }
    public long Phone { get; set; }
    public string Picture { get; set; }
    public string Note { get; set; }
    public string AddDate { get; set; }

    [ForeignKey("Role")]
    public long RoleId { get; set; }

    [ForeignKey("Ethnic")]
    public long EthnicId { get; set; }

    public virtual Ethnic Ethnic { get; set; }
    public virtual Role Role { get; set; }
    }
}
