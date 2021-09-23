using EduHome.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.ViewModels
{
    public class AboutVM
    {
        public AboutUs AboutUs { get; set; }
        public Setting Settings { get; set; }
        
        public List<Teacher> Teachers { get; set; }
        public  List<NoticeBoard> NoticeBoards { get; set; }
    }
}
