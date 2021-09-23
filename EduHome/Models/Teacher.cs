using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class Teacher
    {
        
        public int Id { get; set; }
        [Required]
        public string Image { get; set; }
        [Required,StringLength(maximumLength:50)]
        public string Name { get; set; }
        [Required,StringLength(maximumLength:100)]
        public string Surname { get; set; }
        [Required,StringLength(maximumLength:50)]
        public string Position { get; set; }
        [NotMapped]
        public IFormFile Photos { get; set; }
        [Required]
        public string AboutMe { get; set; }
        [Required]
        public string Degree { get; set; }
        [Required]
        public string Experience { get; set; }
        [Required]
        public string Hobbies { get; set; }
        [Required]
        public string Faculty { get; set; }
       
        public string Mail { get; set; }
        [Required]
        public int PhoneNumber { get; set; }
        [Required, StringLength(maximumLength: 60)]
        public string Skype { get; set; }

        public List<TeacherSkill> TeacherSkills { get; set; }

    }
}
