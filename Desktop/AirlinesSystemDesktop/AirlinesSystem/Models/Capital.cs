using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlinesSystem.Models;

[Table(nameof(Capital))]
public class Capital
{
    [Key]
    public int ID { get; set; }

    [Required]
    [StringLength(100)]
    public string CapitalName { get; set; }

    [Required]
    [StringLength(100)]
    public string Country { get; set; }

    public Capital()
    {
        CapitalName = string.Empty;
        Country = string.Empty;
    }
}
