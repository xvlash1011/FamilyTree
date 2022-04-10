using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GiaPhaApi.Data.Tables
{
  public class RelationShip
  {
    [Key]
    [Column(Order = 0)]
    [ForeignKey("LeftUser")]
    public long LeftId { get; set; }

    [Key]
    [Column(Order = 1)]
    [ForeignKey("RightUser")]
    public long RightId { get; set; }

    [ForeignKey("Relation")]
    public long RelationId { get; set; }
    public virtual Member LeftUser { get; set; }
    public virtual Member RightUser { get; set; }

    public virtual Relation Relation { get; set; }
  }
}
