using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class Setting
    {
        public int Id { get; set; }
        public string Image { get; set; }
        [Required, StringLength(255)]
        public string  Email { get; set; }
        [Required,StringLength(50)]
        public string PhoneNumber { get; set; }
        [Required]
        public string Adress { get; set; }
        [Required, StringLength(255)]
        public string Video { get; set; }
        [Required, NotMapped]
        public IFormFile Photo { get; set; }
        
    }
}
