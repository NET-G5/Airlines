using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace AirlinesSystem.Models
{
    [Table(nameof(To))]
    public class To
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public int? CapitalID { get; set; }

        [ForeignKey("CapitalID")]
        public virtual Capital Capital { get; set; }

        public To()
        {
            Name = string.Empty;
            Capital = new();
        }
    }
}
