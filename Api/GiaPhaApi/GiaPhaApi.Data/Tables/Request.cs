using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace GiaPhaApi.Data.Tables
{
  public class Request
  {
    [Key]
    public long Id { get; set; }

    [StringLength(255)]
    public string Reason { get; set; }
    public string Data { get; set; }
    public string Condition { get; set; }
    public string TimeInit { get; set; }
    public string TimeDone { get; set; }

        [ForeignKey("User")]
    public long UserId { get; set; }

    public virtual User User { get; set; }
  }
}
