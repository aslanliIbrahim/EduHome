using EduHome.DAL;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Controllers
{
    public class AboutController : Controller
    {
        private readonly AppDbContext _contex;
        public AboutController(AppDbContext context)
        {
            _contex = context;
        }
        public IActionResult Index()
        {
            AboutVM aboutVM = new AboutVM
            {
                AboutUs = _contex.about.FirstOrDefault(),
                Settings = _contex.Settings.FirstOrDefault(),
                Teachers = _contex.Teachers.ToList(),
                NoticeBoards = _contex.NoticeBoards.ToList()
            };
            return View(aboutVM);
        }
    }
}
