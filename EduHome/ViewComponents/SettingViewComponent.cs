using EduHome.DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.ViewComponents
{
    public class SettingViewComponent: ViewComponent
    {
        public AppDbContext _context { get; }
        public SettingViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = _context.Settings;
            return View(await Task.FromResult(model));
        }

    }
}
