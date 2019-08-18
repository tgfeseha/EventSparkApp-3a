using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebMvc.Services;
using WebMvc.ViewModels;

namespace WebMvc.Controllers
{
    public class CatalogController : Controller
    {
        private readonly ICatalogService _service;
        public CatalogController(ICatalogService service) => _service = service;

        public async Task<IActionResult> Index(int? type, int? location, int? date, int? page)
        {
            var itemsOnPage = 10;
            var catalog = await _service.GetCatalogItemsAsync(page ?? 0, itemsOnPage, type, location, date);

            var viewmod = new CatalogIndexViewModel
            {
                PaginationInfo = new PaginationInfo
                {
                    ActualPage = page ?? 0,
                    ItemsPerPage = itemsOnPage,
                    TotalItems = catalog.Count,
                    TotalPages = (int)Math.Ceiling((decimal)catalog.Count / itemsOnPage)
                },
                CatalogItems = catalog.Data,
                Locations = await _service.GetLocationAsync(),
                Dates = await _service.GetDateAsync(),
                Types = await _service.GetTypeAsync(),
                LocationsFilterApplied = location ?? 0,
                DatesFilterApplied = date ?? 0,
                TypesFilterApplied = date ?? 0

            };

            viewmod.PaginationInfo.Previous = (viewmod.PaginationInfo.ActualPage == 0) ? "is-disabled" : "";
            viewmod.PaginationInfo.Next = (viewmod.PaginationInfo.ActualPage == viewmod.PaginationInfo.TotalPages - 1) ? "is-disabled" : "";


            return View(viewmod);
        }

        [Authorize]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";


            return View();
        }
    }
}