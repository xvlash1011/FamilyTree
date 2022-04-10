using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GiaPhaApi.Data.Tables
{
    public class User
    {
        [Key]
        public long Id { get; set; }

        [ForeignKey("Member")]
        public long UserId { get; set; }

        [StringLength(10)]
        public string Role { get; set; }

        [StringLength(10)]
        public string UserName { get; set; }

        [StringLength(16)]
        public string Password { get; set; }

        public virtual Member Member { get; set; }
        
  }
}
