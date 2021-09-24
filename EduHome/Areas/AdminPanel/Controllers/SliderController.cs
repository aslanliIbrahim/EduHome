using EduHome.DAL;
using EduHome.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Areas.AdminPanel.Controllers
{

    [Area("AdminPanel")]
    public class SliderController : Controller
    {
        
        public AppDbContext _context { get; }
        public IWebHostEnvironment _env { get; }
        public SliderController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            IEnumerable<Slide> slides = _context.Slides.ToList();
            
            return View(slides);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create( Slide slide)
        {
            //if (!ModelState.IsValid) return View();
            if (ModelState["Photos"].ValidationState == ModelValidationState.Invalid)
            {
                return View();
            }
            
            if (!slide.Photos.ContentType.Contains("image/"))   
            {
                ModelState.AddModelError("photos", "Please enter only image here...");
                return View();
            }
            if (slide.Photos.Length/1024 > 5000)
            {
                ModelState.AddModelError("photo", "you can only enter must be less than 200kb");
                return View();
            }
            string FileName = Guid.NewGuid().ToString() + slide.Photos.FileName;
            string ReslutPath = Path.Combine(_env.WebRootPath, "img", "slider" ,FileName);
            using (FileStream fileStream = new FileStream(ReslutPath, FileMode.Create))
            {
                await slide.Photos.CopyToAsync(fileStream);
            }
            //Slide newslide = new Slide
            //{
            //    Image = FileName
            //};
            slide.Image = FileName;
            _context.Slides.Add(slide);
           await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();
            var slide = await _context.Slides.FirstOrDefaultAsync(sl=>sl.Id == id);
            if (slide == null) return NotFound();
            return View(slide);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Update(Slide slide, int? id)
        {
            //if (!ModelState.IsValid ) return View();
            if(ModelState["Title"].ValidationState == ModelValidationState.Invalid)
            {
                return View();
            }
            if (ModelState["Description"].ValidationState == ModelValidationState.Invalid)
            {
                return View();
            }
            if (id != slide.Id) return BadRequest();
            var slideDb =  _context.Slides.FirstOrDefault(sl => sl.Id == id);
            if (slideDb == null) return NotFound();
            slideDb.Image = slideDb.Image;
            slideDb.Title = slide.Title;
            slideDb.Description = slide.Description;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            var slider = _context.Slides.FirstOrDefault(sl=>sl.Id == id);
            _context.Slides.Remove(slider);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }


    
}
