using EduHome.DAL;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Controllers
{
    public class CourseController : Controller
    {
        private readonly AppDbContext _context;
        public CourseController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            CourseVM courseVM = new CourseVM
            {
                Courses = _context.Courses.ToList(),
                Blogs = _context.Blogs.OrderByDescending(b=>b.Id).Take(3).ToList()
            };
            return View(courseVM);
        }
        public IActionResult Detail(int? id)
        {
            if (id == null) return NotFound();
            CourseVM courseVM = new CourseVM
            {
                Course = _context.Courses.FirstOrDefault(c=>c.Id == id),
                Blogs = _context.Blogs.Include(b=>b.AppUser).OrderByDescending(b => b.Id).Take(3).ToList()
            };

            return View(courseVM);
        }
        [HttpPost]
        public IActionResult Search(CourseVM coursevm)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            coursevm.Courses = _context.Courses.Where(cr => cr.Title.Contains(coursevm.Search)).ToList();
            return View(nameof(Index),coursevm);
        }

    }
}
