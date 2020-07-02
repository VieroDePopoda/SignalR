using System.ComponentModel.DataAnnotations;

namespace FootballCatalog.Models
{
    public class Team : BaseModel
    {
        [Required]
        [Display(Name = "Название команды")]
        public string Name { get; set; }
    }
}
