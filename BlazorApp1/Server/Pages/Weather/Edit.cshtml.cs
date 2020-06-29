using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BlazorApp1.Server.Data;
using BlazorApp1.Shared;

namespace BlazorApp1.Server.Pages.Weather
{
    public class EditModel : PageModel
    {
        private readonly BlazorApp1.Server.Data.ApplicationDbContext _context;

        public EditModel(BlazorApp1.Server.Data.ApplicationDbContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(WeatherForecast).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WeatherForecastExists(WeatherForecast.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool WeatherForecastExists(Guid id)
        {
            return _context.WeatherForecast.Any(e => e.Id == id);
        }
    }
}
