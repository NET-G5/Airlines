using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AirlinesSystem.Models;

[Table(nameof(From))]
public class From
{
    [Key]
    public int ID { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    public int? CapitalID { get; set; }

    [ForeignKey("CapitalID")]
    public virtual Capital Capital { get; set; }

    public From()
    {
        Name = string.Empty;
        Capital = new();
    }
}
