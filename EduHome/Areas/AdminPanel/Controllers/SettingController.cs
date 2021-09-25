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
    public class SettingController : Controller
    {
        public AppDbContext _context { get; }
        public IWebHostEnvironment _env { get; }
        public SettingController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            IEnumerable<Setting> settings = _context.Settings.ToList();
            return View(settings);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(Setting setting)
        {
            if (ModelState["Photo"].ValidationState == ModelValidationState.Invalid)
            {
                return View();
            }
            if (!setting.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("photo","please enter only must be image...");
                return View();
            }
            if (setting.Photo.Length/1024 > 5000)
            {
                ModelState.AddModelError("photo", "please enter image where less then 5000kb");
                return View();
            }
            if (ModelState["Email"].ValidationState == ModelValidationState.Invalid)
            {
                ModelState.AddModelError("email", "please enter email...");
            }
            string filename = Guid.NewGuid().ToString() + setting.Photo.FileName;
            string resulpath = Path.Combine(_env.WebRootPath, "img", "logo", filename);
            using (FileStream filestream = new FileStream(resulpath, FileMode.Create))
            {
                await setting.Photo.CopyToAsync(filestream);
            }
            
            setting.Image = filename;
            _context.Settings.Add(setting);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();
            var setting = await _context.Settings.FirstOrDefaultAsync(st => st.Id == id);
            if (setting == null) return NotFound();
            return View(setting);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Update(Setting setting, int? id)
        {
            if (id == null) return NotFound();
            if (ModelState["Email"].ValidationState == ModelValidationState.Invalid)
            {
                return View();
            }
            if (ModelState["PhoneNumber"].ValidationState == ModelValidationState.Invalid)
            {
                return View();
            }
            if (ModelState["Adress"].ValidationState == ModelValidationState.Invalid)
            {
                return View();
            }
            if (ModelState["Video"].ValidationState == ModelValidationState.Invalid)
            {
                return View();
            }
            if (id != setting.Id) return BadRequest();
            var settingDb = await _context.Settings.FirstOrDefaultAsync(sd=>sd.Id == id);
            if (settingDb == null) return NotFound();
            settingDb.Image = setting.Image;
            settingDb.PhoneNumber = setting.PhoneNumber;
            settingDb.Video = setting.Video;
            settingDb.Email = setting.Email;
            settingDb.Adress = setting.Adress;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            var setting = _context.Settings.FirstOrDefault(st=>st.Id == id);
            _context.Settings.Remove(setting);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


    }
}
