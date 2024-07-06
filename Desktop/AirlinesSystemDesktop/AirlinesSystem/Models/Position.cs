using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlinesSystem.Models;

[Table(nameof(Position))]
public class Position
{
    [Key]
    public int ID { get; set; }

    [Required]
    [StringLength(50)]
    public string PositionName { get; set; }

    public Position()
    {
        PositionName = string.Empty;
    }
}
