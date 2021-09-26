using EduHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.ViewModels
{
    public class HomeVM
    {
        public List<Slide> Slides { get; set; }
        public Setting Settings { get; set; }
        public AboutUs about { get; set; }
        public List<Sms> sms { get; set; }
        public List<Course> Courses { get; set; }
        public List<Blog> Blogs { get; set; }
        public List<Event> Events { get; set; }
        public List<NoticeBoard> NoticeBoards { get; set; }

    }
}
