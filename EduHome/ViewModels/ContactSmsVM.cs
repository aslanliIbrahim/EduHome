using EduHome.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.ViewModels
{
    public class ContactSmsVM
    {
        [Required, StringLength(maximumLength: 20)]
        public string Name { get; set; }
        [Required,DataType(DataType.EmailAddress)]
        public string Email { get; set; } 
        [Required, StringLength(255)]
        public string Subject { get; set; }
        [Required, StringLength(maximumLength: 500)]
        public string Message { get; set; }
        public Contact Contact { get; set; }
        
    }
}
