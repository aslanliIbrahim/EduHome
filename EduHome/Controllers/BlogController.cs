using EduHome.DAL;
using EduHome.Models;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using X.Pagedlist;
using PagedList.Mvc;
using PagedList;

namespace EduHome.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;
        public BlogController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(string search,int? i)
        {
            List<Blog> blogs = _context.Blogs.ToList();
            return View(blogs.OrderByDescending(b=>b.Id).ToList().ToPagedList(i ?? 1,9));
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return View();
            var post = await _context.Blogs.Include(p => p.AppUser).FirstOrDefaultAsync();
            return View(post);
        }
    }
}
