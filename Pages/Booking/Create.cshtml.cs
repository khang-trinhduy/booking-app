using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Booking;
using BookingApp.Services;

namespace BookingApp.Pages.Booking
{
    public class CreateModel : PageModel
    {
        private readonly BookingServices _service;

        public CreateModel(BookingServices service)
        {
            _service = service;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Contract Contract { get; set; }

        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _service.Create(Contract);

            return RedirectToPage("./Index");
        }
    }
}