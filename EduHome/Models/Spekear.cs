using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class Spekear
    {
        public int Id { get; set; }
        [Required, StringLength(maximumLength: 100)]
        public string Name { get; set; }
        [Required, StringLength(maximumLength: 50)]
        public string Surname { get; set; }
        [Required]
        public string Image { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        [Required, StringLength(maximumLength: 100)]
        public string Position { get; set; }

        public Event Event { get; set; }
        public  int EventId { get; set; }
    }
}
