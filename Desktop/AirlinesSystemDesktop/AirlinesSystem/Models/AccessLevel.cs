using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlinesSystem.Models;

[Table(nameof(AccessLevel))]
public class AccessLevel
{
    [Key]
    public long AccessLevelID { get; set; }
    [Required]
    [StringLength(50)]
    public string AccessLevelName { get; set; }
    [StringLength(100)]
    public string Description { get; set; }

    public ICollection<Employee> Employees { get; set; }

    public AccessLevel()
    {
        AccessLevelName = string.Empty;
        Description = string.Empty;
        Employees = new List<Employee>();
    }
}
