using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public string Adress { get; set; }
        [Required, StringLength(255)]
        public string Video { get; set; }
        [Required, StringLength(20)]
        public string DateTime { get; set; }
        [Required,StringLength(255)]
        public string Letter { get; set; }
    }
}
