using EduHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.ViewModels
{
    public class ContactVM
    {
        public Contact contacts { get; set; }
        public List<Slide> Slides { get; set; }
        public Setting Settings { get; set; }
        public AboutUs about { get; set; }
    }
}
