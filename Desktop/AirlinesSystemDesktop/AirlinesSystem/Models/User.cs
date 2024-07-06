using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirlinesSystem.Models;

[Table(nameof(User))]
public class User
{
    [Key]
    public int ID { get; set; }

    [Required]
    [StringLength(50)]
    public string UserName { get; set; }

    [Required]
    [StringLength(100)]
    public string Password { get; set; }

    [Required]
    [StringLength(100)]
    public string Email { get; set; }

    public int? EmployeeID { get; set; }

    [ForeignKey("EmployeeID")]
    public virtual Employee Employee { get; set; }

    public User()
    {
        UserName = string.Empty;
        Password = string.Empty;
        Email = string.Empty;
        Employee = new();
    }
}
