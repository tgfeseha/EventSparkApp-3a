using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebMvc.Models;

namespace WebMvc.ViewModels
{
    public class CatalogIndexViewModel
    {
        public PaginationInfo PaginationInfo { get; set; }
        public IEnumerable<SelectListItem> Locations { get; set; }
        public IEnumerable<SelectListItem> Dates { get; set; }
        public IEnumerable<SelectListItem> Types { get; set; }
        public IEnumerable<Catalogitem> CatalogItems {get; set; }

        public int? TypesFilterApplied { get; set; }
        public int? LocationsFilterApplied { get; set; }
        public int? DatesFilterApplied { get; set; }
    }
}
