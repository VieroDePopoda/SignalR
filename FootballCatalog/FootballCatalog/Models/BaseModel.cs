using System;
using System.ComponentModel.DataAnnotations;

namespace FootballCatalog.Models
{
    public class BaseModel
    {
        [Key]
        public Guid Id { get; set; }
        public bool IsDelete { get; set; }
    }
}
