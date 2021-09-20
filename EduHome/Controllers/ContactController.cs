using EduHome.DAL;
using EduHome.Models;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;
        public ContactController(AppDbContext context)
        {
            _context = context;
        }
       
        public async Task<IActionResult> Index()
        {
            ContactVM contactVM = new ContactVM
            {
                Slides = await _context.Slides.ToListAsync(),
                Settings =  _context.Settings.FirstOrDefault(),
                about = _context.about.FirstOrDefault(),
                contacts = _context.contacts.FirstOrDefault(),
                
            };

            return View(contactVM);
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Index(ContactSmsVM contactSmsVM)
        {
            if (!ModelState.IsValid) return View(contactSmsVM);

            Sms contact = new Sms
            {
                Name = contactSmsVM.Name,
                Email = contactSmsVM.Email,
                Subject = contactSmsVM.Subject,
                Message = contactSmsVM.Message,
            };
            await _context.sms.AddAsync(contact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            
        }
    }
}
