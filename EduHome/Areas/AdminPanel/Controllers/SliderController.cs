using EduHome.DAL;
using EduHome.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Areas.AdminPanel.Controllers
{

    [Area("AdminPanel")]
    public class SliderController : Controller
    {
        
        public AppDbContext _context { get; }
        public SliderController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            IEnumerable<Slide> slides = _context.Slides.ToList();
            
            return View(slides);
        }
    }
}
