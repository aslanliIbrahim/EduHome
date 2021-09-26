using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class Blog
    {
        public int Id { get; set; }
        [Required]
        public string Image { get; set; }
        [Required, StringLength(maximumLength:255)]
        public string Title { get; set; }
        [Required, StringLength(maximumLength:500)]
        public string Content { get; set; }
        [Required, DataType(DataType.Date)]
        public DateTime DateTime { get; set; }
        public AppUser AppUser { get; set; }
        public string AppUserId { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        [Required,StringLength(maximumLength:255)]
        public string Writer { get; set; }
    }
}
