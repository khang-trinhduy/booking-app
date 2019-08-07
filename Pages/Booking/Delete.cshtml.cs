using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Booking;
using BookingApp.Services;

namespace BookingApp.Pages.Booking
{
    public class DeleteModel : PageModel
    {
        private readonly BookingServices _services;

        public DeleteModel(BookingServices service)
        {
            _services = service;
        }

        [BindProperty]
        public Contract Contract { get; set; }

        public IActionResult OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Contract = _services.Get(id);

            if (Contract == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Contract = _services.Get(id);

            if (Contract != null)
            {
                _services.Remove(id);
            }

            return RedirectToPage("./Index");
        }
    }
}
