using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlinesSystem.Models;

[Table(nameof(Aircraft))]
public class Aircraft
{
    [Key]
    public int ID { get; set; }

    [Required]
    [StringLength(50)]
    public string Model { get; set; }

    [Required]
    [StringLength(50)]
    public string Manufacturer { get; set; }

    [Required]
    public int SeatingCapacity { get; set; }

    public Aircraft()
    {
        Model = string.Empty;
        Manufacturer = string.Empty;
    }
}