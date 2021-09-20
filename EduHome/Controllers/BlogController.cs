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
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;
        public BlogController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Blog> blogs = _context.Blogs.Include(B=>B.AppUser).ToList();
            

            return View(blogs);
        }
        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return View();
            var post = await _context.Blogs.Include(p => p.AppUser).FirstOrDefaultAsync();

            
            return View(post);
        }
    }
}
