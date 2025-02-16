using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfApp1.Data.Entitys
{
    [Table("Vehicles")]
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }

        public required string Description { get; set; }

        public DateTime Purchased { get; set; }

        [ForeignKey("VehicleType")]
        public int VehicleTypeId { get; set; }

        public virtual required string VehicleType { get; set; }
    }
}
