using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using EventCatalogApi.Data;
using EventCatalogApi.Domain;
using EventCatalogApi.ViewModels;

namespace EventCatalogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly EventContext _context;
        private readonly IConfiguration _config;
        public CatalogController(EventContext context,
            IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        
        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> Items(
            [FromQuery]int pageSize = 6,
            [FromQuery]int pageIndex = 0)
        {
            var itemsCount = await _context.EventItems.LongCountAsync();

            var items = await _context.EventItems
                 .OrderBy(c => c.Name)
                 .Skip(pageSize * pageIndex)
                 .Take(pageSize)
                 .ToListAsync();

            items = ChangePictureUrl(items);

            var model = new PaginateditemsViewModel<EventItem>
            {
                PageSize = pageSize,
                PageIndex = pageIndex,
                Count = itemsCount,
                Data = items
            };
            return Ok(model);
        }

        
        [HttpGet]
        [Route("[action]/type/{eventTypeId}/location/{eventLocationId}/date/{eventDateId}")]
        public async Task<IActionResult> Items(int? eventTypeId,
            int? eventLocationId, int? eventDateId,
            [FromQuery] int pageSize = 6,
            [FromQuery] int pageIndex = 0)
        {
            var root = (IQueryable<EventItem>)_context.EventItems;

            if (eventTypeId.HasValue)
            {
                root = root.Where(c => c.EventTypeId == eventTypeId);
            }

            if (eventLocationId.HasValue)
            {
                root = root.Where(c => c.EventLocationId == eventLocationId);
            }

            if (eventDateId.HasValue)
            {
                root = root.Where(c => c.EventDateId == eventDateId);
            }

            var totalItems = await root
                              .LongCountAsync();

            var itemsOnPage = await root
                              .OrderBy(c => c.Name)
                              .Skip(pageSize * pageIndex)
                              .Take(pageSize)
                              .ToListAsync();

            itemsOnPage = ChangePictureUrl(itemsOnPage);

            var model = new PaginateditemsViewModel<EventItem>
            {
                PageSize = pageSize,
                PageIndex = pageIndex,
                Count = totalItems,
                Data = itemsOnPage
            };
            return Ok(model);
        }

        private List<EventItem> ChangePictureUrl(
            List<EventItem> items)
        {
            items.ForEach(
                c =>
                c.PictureURL =
                 c.PictureURL
                 .Replace("http://externalcatalogbaseurltobereplaced"
                 , _config["ExternalCatalogBaseUrl"]));

            return items;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> EventTypes()
        {
            var items = await _context.EventTypes.ToListAsync();
            return Ok(items);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> EventLocations()
        {
            var items = await _context.EventLocations.ToListAsync();
            return Ok(items);
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> EventDates()
        {
            var items = await _context.EventDates.ToListAsync();
            return Ok(items);
        }

        [HttpGet]
        [Route("items/{id:int}")]
        public async Task<IActionResult> GetItemsById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Incorrect Id!");
            }

            var item = await _context.EventItems
                            .SingleOrDefaultAsync(c => c.Id == id);


            if (item == null)
            {
                return NotFound("Catalog item not found");
            }

            item.PictureURL = item.PictureURL
                 .Replace("http://externalcatalogbaseurltobereplaced"
                 , _config["ExternalCatalogBaseUrl"]);
            return Ok(item);
        }


        [HttpGet]
        [Route("[action]/withname/{name:minlength(1)}")]
        public async Task<IActionResult> Items(string name,
            [FromQuery] int pageSize = 6,
            [FromQuery] int pageIndex = 0)
        {
            var totalItems = await _context.EventItems
                               .Where(c => c.Name.StartsWith(name))
                              .LongCountAsync();
            var itemsOnPage = await _context.EventItems
                              .Where(c => c.Name.StartsWith(name))
                              .OrderBy(c => c.Name)
                              .Skip(pageSize * pageIndex)
                              .Take(pageSize)
                              .ToListAsync();

            itemsOnPage = ChangePictureUrl(itemsOnPage);

            var model = new PaginateditemsViewModel<EventItem>
            {
                PageSize = pageSize,
                PageIndex = pageIndex,
                Count = totalItems,
                Data = itemsOnPage
            };
            return Ok(model);
        }

        [HttpPost]
        [Route("items")]
        public async Task<IActionResult> CreateProduct(
            [FromBody] EventItem product)
        {
            var item = new EventItem
            {
                EventDateId = product.EventDateId,
                EventLocationId = product.EventLocationId,
                EventTypeId = product.EventTypeId,
                Description = product.Description,
                Name = product.Name,
                PictureURL = product.PictureURL,
                Fee = product.Fee,
                EventStartTime = product.EventStartTime,
                EventEndTime = product.EventEndTime
            };

            _context.EventItems.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetItemsById), new { id = item.Id });
        }

        [HttpPut]
        [Route("items")]
        public async Task<IActionResult> Update(
            [FromBody] EventItem eventToUpdate)
        {
            var eventItem = await _context.EventItems
                              .SingleOrDefaultAsync
                              (i => i.Id == eventToUpdate.Id);
            if (eventItem == null)
            {
                return NotFound(new { Message = $"Item with id {eventToUpdate.Id} not found." });
            }

            eventItem = eventToUpdate;
            _context.EventItems.Update(eventItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetItemsById), new { id = eventToUpdate.Id });
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.EventItems
                .SingleOrDefaultAsync(p => p.Id == id);
            if (product == null)
            {
                return NotFound();

            }

            _context.EventItems.Remove(product);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}