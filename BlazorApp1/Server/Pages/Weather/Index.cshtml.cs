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
    public class IndexModel : PageModel
    {
        private readonly BlazorApp1.Server.Data.ApplicationDbContext _context;

        public IndexModel(BlazorApp1.Server.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<WeatherForecast> WeatherForecast { get;set; }

        public async Task OnGetAsync()
        {
            WeatherForecast = await _context.WeatherForecast.ToListAsync();
        }
    }
}
