using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp1.Data.Entitys
{
    [Table("Users")]
    public class WPFUser
    {
        [Key]
        public required string Id { get; set; }
        public required string Username { get; set; }
        public required string Useremail { get; set; }
    }
}
