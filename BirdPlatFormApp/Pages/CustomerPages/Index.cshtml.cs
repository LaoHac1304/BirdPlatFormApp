using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Infrastructure;

namespace BirdPlatFormApp.Pages.CustomerPages
{
    public class IndexModel : PageModel
    {
        private readonly Infrastructure.BirdPlatformContext _context;

        public IndexModel(Infrastructure.BirdPlatformContext context)
        {
            _context = context;
        }

        public IList<Customer> Customer { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Customers != null)
            {
                Customer = await _context.Customers.ToListAsync();
            }
        }
    }
}
