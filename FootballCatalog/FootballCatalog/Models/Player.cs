using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballCatalog.Models
{
    public class Player : BaseModel
    {
        [Required]
        [Display(Name = "���")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "�������")]
        public string Surname { get; set; }

        [Required]
        [Display(Name = "���")]
        public string Gender { get; set; }

        [Required]
        [Display(Name = "���� ��������")]
        public DateTime Birthday { get; set; }

        [Display(Name= "�������")]
        public Guid TeamId { get; set; }

        [ForeignKey("TeamId")]
        [Display(Name = "�������� �������")]
        public Team Team { get; set; }

        [Required]
        [Display(Name = "������")]
        public string Country { get; set; }
    }
}
