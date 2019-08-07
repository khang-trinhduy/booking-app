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
    public class DetailsModel : PageModel
    {
        private readonly BookingServices _service;

        public DetailsModel(BookingServices service)
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

        public IActionResult OnPostAjax()
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult($"Modelstate is invalid {ModelState}");
            }

            var contract = _service.Get(Contract.Id);
            if (contract == null)
            {
                return new JsonResult($"contract is not found id={Contract.Id}");
            }
            _service.Update(Contract.Id, Contract);

            return new JsonResult("Your changes have been saved!");
        }
    }
}
