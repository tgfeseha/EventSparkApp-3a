using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebMvc.Infrastructure;
using WebMvc.Models;

namespace WebMvc.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly IHttpClient _client;
        private readonly string _baseUri;

        public CatalogService(IHttpClient httpclient, IConfiguration config)
        {
            _client = httpclient;
            _baseUri = $"{config["CatalogUrl"]}/api/catalog/";
        }
        public async Task<Catalog> GetCatalogItemsAsync(int page, int size, int? location, int? date, int? type)
        {
            var catalogItemsUri = ApiPaths.Catalog.GetAllCatalogItems(_baseUri, page, size, date, location, type);

            var dataString = await _client.GetStringAsync(catalogItemsUri);
            var response = JsonConvert.DeserializeObject<Catalog>(dataString);
            return response;
        }

        public async Task<IEnumerable<SelectListItem>> GetDateAsync()
        {
            var dateUri = ApiPaths.Catalog.GetAllDates(_baseUri);
            var dataString = await _client.GetStringAsync(dateUri);
            var items = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value = null,
                    Text = "All",
                    Selected= true

                }
            };

            var dates = JArray.Parse(dataString);
            foreach (var date in dates)
            {
                items.Add(new SelectListItem
                {
                    Value = date.Value<string>("id"),
                    Text = date.Value<string>("date")
                }
                 );
            }

            return items;
        }
        public async Task<IEnumerable<SelectListItem>> GetLocationAsync()
        {
            var locationUri = ApiPaths.Catalog.GetAllLocations(_baseUri);
            var locationString = await _client.GetStringAsync(locationUri);
            var items = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value = null,
                    Text = "All",
                    Selected= true

                }
            };

            var locations = JArray.Parse(locationString);
            foreach (var location in locations)
            {
                items.Add(
                    new SelectListItem
                    {
                        Value = location.Value<string>("id"),
                        Text = location.Value<string>("location")
                    }
                 );
            }

            return items;
        }

        public async Task<IEnumerable<SelectListItem>> GetTypeAsync()
        {
            var typeUri = ApiPaths.Catalog.GetAllTypes(_baseUri);
            var dataString = await _client.GetStringAsync(typeUri);
            var items = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value=null,
                    Text="All",
                    Selected = true
                }
            };

            var types = JArray.Parse(dataString);
            foreach (var type in types)
            {
                items.Add(
                    new SelectListItem
                    {
                        Value = type.Value<string>("id"),
                        Text = type.Value<string>("type")
                    }
                 );
            }

            return items;
        }
    }
}
