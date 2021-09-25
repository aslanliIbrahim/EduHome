using EduHome.DAL;
using EduHome.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Web;
using Microsoft.AspNet.Identity;

namespace EduHome.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class BlogController : Controller
    {
        public AppDbContext _context { get; }
        private readonly Microsoft.AspNetCore.Identity.UserManager<AppUser> _userManager;
        public IWebHostEnvironment _env { get; }
        public BlogController(AppDbContext context, IWebHostEnvironment env, Microsoft.AspNetCore.Identity.UserManager<AppUser> userManager)
        {
            _context = context;
            _env = env;
            _userManager = userManager;
            
        }
        public IActionResult Index()
        {
            IEnumerable<Blog> blogs = _context.Blogs.ToList();
            return View(blogs);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create (Blog blog)
        {
            if (ModelState["Photo"].ValidationState == ModelValidationState.Invalid)
            {
                return NotFound();
            }
            if (!blog.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("photos", "Please enter only image here...");
                return View();
            }
            if (blog.Photo.Length/1024>3000)
            {
                ModelState.AddModelError("photo", "you can only enter must be less than 200kb");
                return View();
            }
            string FileName = Guid.NewGuid().ToString() + blog.Photo.FileName;
            string ReslutPath = Path.Combine(_env.WebRootPath, "img", "slider", FileName);
            using (FileStream fileStream = new FileStream(ReslutPath, FileMode.Create))
            {
                await blog.Photo.CopyToAsync(fileStream);
            }
             blog.Image = FileName;
            var user = await _userManager.FindByIdAsync(User.Identity.GetUserId());
            blog.AppUser = user;
            _context.Blogs.Add(blog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();
            var blog = await _context.Blogs.FirstOrDefaultAsync(bl => bl.Id == id);
            if (blog == null) return NotFound();
            return View(blog);
           
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Update(Blog blog, int? id)
        {
            //if (!ModelState.IsValid ) return View();
            if (ModelState["Title"].ValidationState == ModelValidationState.Invalid)
            {
               
                return View();
            }
            if (ModelState["Content"].ValidationState == ModelValidationState.Invalid)
            {
                return View();
            }
            if (id != blog.Id) return BadRequest();
            var blogdb = _context.Blogs.FirstOrDefault(bl => bl.Id == id);
            if (blogdb == null) return NotFound();
            blogdb.Image = blog.Image;
            blogdb.Title = blog.Title;
            blogdb.Content = blog.Content;
            blogdb.DateTime = blog.DateTime;
           
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int? id)
        {
            var blog = _context.Blogs.FirstOrDefault(sl => sl.Id == id);
            _context.Blogs.Remove(blog);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
