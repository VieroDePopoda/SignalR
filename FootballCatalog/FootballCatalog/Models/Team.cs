using System.ComponentModel.DataAnnotations;

namespace FootballCatalog.Models
{
    public class Team : BaseModel
    {
        [Required]
        [Display(Name = "�������� �������")]
        public string Name { get; set; }
    }
}
