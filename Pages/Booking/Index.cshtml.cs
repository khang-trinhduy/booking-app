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
    public class IndexModel : PageModel
    {
        private readonly BookingServices _service;

        public IndexModel(BookingServices service)
        {
            _service = service;
        }

        public IList<Contract> Contract { get;set; }

        public void OnGet()
        {
            Contract = _service.Get().ToList();
        }
    }
}
