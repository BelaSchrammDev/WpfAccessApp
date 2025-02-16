using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp1.Data.Entitys
{
    [Table("VehicleTypes")]
    public class VehicleType
    {
        [Key]
        public int Id { get; set; }

        public string Type { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
    }
}
