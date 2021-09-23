using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class NoticeBoard
    {
        public int Id { get; set; }
        [Required, DataType(DataType.Date)]
        public DateTime DateTime { get; set; }
        [Required]
        public string Title { get; set; }
    }
}
