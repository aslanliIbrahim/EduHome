using EduHome.DAL;
using EduHome.Models;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Controllers
{
    public class EventController : Controller
    {
        private readonly AppDbContext _context;
        public EventController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            EventVM eventVM = new EventVM
            {
                Events = _context.Events.ToList(),
                Blogs = _context.Blogs.OrderByDescending(b => b.Id).Take(3).ToList(),
            };
            return View(eventVM);
        }
        public IActionResult Details(int? id)
        
        {
            if (id == null) return NotFound();
            EventVM eventVM = new EventVM
            {
                Event = _context.Events.Include(m=>m.Spekears).FirstOrDefault(m=>m.Id == id),
                Blogs = _context.Blogs.OrderByDescending(b => b.Id).Take(3).ToList()
                
            };
            //var post = await _context.Events.Include(e => e.Spekears).FirstOrDefaultAsync(ev=>ev.Id == id);
            return View(eventVM);
        }
    }
}
