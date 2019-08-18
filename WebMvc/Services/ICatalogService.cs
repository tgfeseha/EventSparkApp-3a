using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebMvc.Models;

namespace WebMvc.Services
{
    public interface ICatalogService
    {
        Task<Catalog> GetCatalogItemsAsync(int page, int size, int? location, int? date, int? type);

        Task<IEnumerable<SelectListItem>> GetLocationAsync();
        Task<IEnumerable<SelectListItem>> GetDateAsync();
        Task<IEnumerable<SelectListItem>> GetTypeAsync();
    }
}
