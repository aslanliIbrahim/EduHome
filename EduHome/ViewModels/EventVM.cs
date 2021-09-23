using EduHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.ViewModels
{
    public class EventVM
    {
        public List<Event> Events { get; set; }
        public List<Blog> Blogs { get; set; }
        public Event Event { get; set; }
    }
}
