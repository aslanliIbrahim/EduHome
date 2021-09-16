﻿using EduHome.DAL;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Controllers
{
    public class HomeController : Controller
    {
        public AppDbContext _context { get; }
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult>  Index()
        {
            HomeVM homevm = new HomeVM
            {
                Slides = await _context.Slides.ToListAsync(),
                Settings = _context.Settings.FirstOrDefault(),
                about = _context.about.FirstOrDefault()
               
            };
           
            return View();
        }
    }
}
