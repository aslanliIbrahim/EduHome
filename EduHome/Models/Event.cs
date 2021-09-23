using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class Event
    {
        
        public int Id { get; set; }
        [Required]
        public string  Image { get; set; }
        [Required,StringLength(maximumLength:255)]
        public string Title { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public TimeSpan StartTime { get; set; }
        [Required]
        public TimeSpan EndTime { get; set; }
        
        [Required,StringLength(maximumLength:255)]
        public string Place { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        [Required]
        public string AboutMe { get; set; }
        public List<Spekear> Spekears { get; set; }
       

    }
}
