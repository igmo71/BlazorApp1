using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BlazorApp1.Server.Data;
using BlazorApp1.Shared;

namespace BlazorApp1.Server.Pages.Weather
{
    public class DeleteModel : PageModel
    {
        private readonly BlazorApp1.Server.Data.ApplicationDbContext _context;

        public DeleteModel(BlazorApp1.Server.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public WeatherForecast WeatherForecast { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            WeatherForecast = await _context.WeatherForecast.FirstOrDefaultAsync(m => m.Id == id);

            if (WeatherForecast == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            WeatherForecast = await _context.WeatherForecast.FindAsync(id);

            if (WeatherForecast != null)
            {
                _context.WeatherForecast.Remove(WeatherForecast);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
