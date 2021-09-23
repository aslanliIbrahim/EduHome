using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required]
        public string Image { get; set; }
        [Required,StringLength(maximumLength:255)]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
        [Required]
        public string CourseDescription { get; set; }
        [Required]
        public string AboutCourse { get; set; }
        [Required]
        public string HowToApply { get; set; }
        [Required]
        public string Certification { get; set; }
        [Required]
        public DateTime  StartDate{ get; set; }
        [Required,StringLength(maximumLength:255)]
        public string Duration { get; set; }
        [Required,StringLength(maximumLength:255)]
        public string ClassDuration { get; set; }
        [Required]
        public string SkillLevel { get; set; }
        [Required]
        public string Language { get; set; }
        [Required]
        public int StudentCount { get; set; }
        [Required, StringLength(maximumLength:255)]
        public string Assesments { get; set; }
        [Required]
        public int Cost { get; set; }
    }
}
