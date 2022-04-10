using System.ComponentModel.DataAnnotations;

namespace GiaPhaApi.Data.Tables
{
  public class Relation
  {
    [Key]
    public long Id { get; set; }

    [Required]
    [StringLength(255)]
    public string Name { get; set; }
  }
}
