using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Booking;
using BookingApp.Services;

namespace BookingApp.Pages.Booking
{
    public class EditModel : PageModel
    {
        private readonly BookingServices _service;

        public EditModel(BookingServices service)
        {
            _service = service;
        }

        [BindProperty]
        public Contract Contract { get; set; }

        public IActionResult OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Contract = _service.Get(id);

            if (Contract == null)
            {
                return NotFound();
            }
            return Page();
        }



        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var contract = _service.Get(Contract.Id);
            if (contract == null)
            {
                return NotFound();
            }
            _service.Update(Contract.Id, Contract);

            return RedirectToPage("./Index");
        }

        private bool ContractExists(string id)
        {
            return _service.Get(id) != null;
        }
    }
}
