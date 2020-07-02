using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballCatalog.Models
{
    public class Player : BaseModel
    {
        [Required]
        [Display(Name = "Имя")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Фамилия")]
        public string Surname { get; set; }

        [Required]
        [Display(Name = "Пол")]
        public string Gender { get; set; }

        [Required]
        [Display(Name = "Дата Рождения")]
        public DateTime Birthday { get; set; }

        [Display(Name= "Команда")]
        public Guid TeamId { get; set; }

        [ForeignKey("TeamId")]
        [Display(Name = "Название команды")]
        public Team Team { get; set; }

        [Required]
        [Display(Name = "Страна")]
        public string Country { get; set; }
    }
}
