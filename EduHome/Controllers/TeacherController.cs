using EduHome.DAL;
using EduHome.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Controllers
{
    public class TeacherController : Controller
    {
        private readonly AppDbContext _context;
        public TeacherController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Teacher> teachers = _context.Teachers.ToList();

            return View(teachers);
        }
        public async Task<IActionResult> TeacherDetail(int? id)
        {
            if (id == null) return View();

            var post = await _context.Teachers.Include(t => t.TeacherSkills).ThenInclude(ts=>ts.Skill).FirstOrDefaultAsync(tn=>tn.Id == id);
            var photo = post.Image;
            if (post == null) return NotFound();

            return View(post);
        }
    }
}
