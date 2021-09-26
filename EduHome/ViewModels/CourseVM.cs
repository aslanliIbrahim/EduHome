using EduHome.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.ViewModels
{
    public class CourseVM
    {
        public List<Course> Courses { get; set; }
        public List<Blog> Blogs { get; set; }
        public Course Course { get; set; }
        [Required]
        public string Search { get; set; }
    }
}
