using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class AboutUs
    {
        public int Id { get; set; }
        [Required, StringLength(500)]
        public string about { get; set; }
        [Required,StringLength(500)]
        public string StudentLetter { get; set; }
    }
}
