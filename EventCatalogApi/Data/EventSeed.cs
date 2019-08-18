using EventCatalogApi.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EventCatalogApi.Data
{
    public static class EventSeed
    {
        public static void Seed(EventContext context)
        {
            context.Database.Migrate();
            if (!context.EventLocations.Any())
            {
                context.EventLocations.AddRange(GetPreConfiguredEventLocations());
                context.SaveChanges();
            }

            if (!context.EventTypes.Any())
            {
                context.EventTypes.AddRange(GetPreConfiguredEventTypes());
                context.SaveChanges();
            }

            if (!context.EventDates.Any())
            {
                context.EventDates.AddRange(GetPreConfiguredEventDates());
                context.SaveChanges();
            }

            if (!context.EventItems.Any())
            {
                context.EventItems.AddRange(GetPreConfiguredEventItems());
                context.SaveChanges();
            }
        }



        // populated from class project for dummy data
        private static IEnumerable<EventItem> GetPreConfiguredEventItems()
        {
            return new List<EventItem>()
            {
                new EventItem() { EventTypeId=1,EventLocationId=10,EventDateId=1, Description = "Travel, Lifestyle, Food Description", Name = "World Traveling",EventStartTime= "7PM", EventEndTime= "9PM", Fee = 20, PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/1" },
                new EventItem() { EventTypeId=2,EventLocationId=9, EventDateId=2,Description = "Music and Parties Description", Name = "Summer Block Party",EventStartTime= "7PM", EventEndTime= "1AM",  Fee= 60, PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/2" },
                new EventItem() { EventTypeId=3,EventLocationId=8,EventDateId=3, Description = "Buisness and Networking Description", Name = "Startups Conference", EventStartTime= "3PM", EventEndTime="8PM",  Fee = 100, PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/3" },
                new EventItem() { EventTypeId=4,EventLocationId=7,EventDateId=4, Description = "Technology and Science Description", Name = "Event Name Here", EventStartTime= "8PM", EventEndTime= "2AM",  Fee = 50, PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/4" },
                new EventItem() { EventTypeId=5,EventLocationId=6,EventDateId=8, Description = "Sports and Fitness Description", Name = "BeachBum VolleyBall Tournament", EventStartTime= "2PM", EventEndTime= "9PM" , Fee = 25, PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/5" },
                new EventItem() { EventTypeId=5,EventLocationId=6, EventDateId=6,Description = "Sports and Fitness Description", Name = "Get out and Play Day", EventStartTime= "2PM", EventEndTime= "9PM" , Fee = 25, PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/5" },
                new EventItem() { EventTypeId=5,EventLocationId=6, EventDateId=7,Description = "Sports and Fitness Description", Name = "End of Summer Sports Event", EventStartTime= "2PM", EventEndTime= "9PM" , Fee = 25, PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/5" },
                new EventItem() { EventTypeId=6,EventLocationId=5,EventDateId=8, Description = "Real Estate Description", Name = "FLIP and EARN", EventStartTime= "3PM", EventEndTime= "8PM", Fee = 75, PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/6" },
                new EventItem() { EventTypeId=7,EventLocationId=4,EventDateId=9, Description = "Arts and Crafts Description", Name = "Paint and Wine", EventStartTime= "1PM", EventEndTime= "5PM", Fee = 15, PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/7"  },
                new EventItem() { EventTypeId=8,EventLocationId=3, EventDateId=10,Description = "Cars, Trucks, Motorcycles Description", Name = "2019 CAR SHOW",EventStartTime= "2PM", EventEndTime= "6PM", Fee = 10, PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/8" },
                new EventItem() { EventTypeId=9,EventLocationId=2, EventDateId=3,Description = "Finance and Investing Description", Name = "Leading Young Entreprenures",  EventStartTime= "4PM", EventEndTime= "10PM", Fee = 20, PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/9" },
                new EventItem() { EventTypeId=10,EventLocationId=1,EventDateId=5, Description = "Film and Movie Making Description", Name = "Your Name (could be) Here",  EventStartTime= "5PM", EventEndTime= "11PM",Fee = 10, PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/10" },
                new EventItem() { EventTypeId=11,EventLocationId=2,EventDateId=6, Description = "Edcuational and Informative Description", Name = "Washington Annual Teacher Conference", EventStartTime= "7PM", EventEndTime= "1AM", Fee = 30, PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/11" },
                new EventItem() { EventTypeId=12,EventLocationId=3, EventDateId=2,Description = "Volunteer and Charity Fundraising Description", Name = "March for Minorities",EventStartTime= "6PM", EventEndTime= "10PM", Fee = 0, PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/12" },
                new EventItem() { EventTypeId=13,EventLocationId=4,EventDateId=8, Description = "Fashion - Catwalk or Thrifting Description", Name = "Look What the Catwalk Dragged In",EventStartTime= "6PM", EventEndTime= "8PM",  Fee = 25, PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/13" },
                new EventItem() { EventTypeId=14,EventLocationId=5,EventDateId=1, Description = "Standup Comedy and Live Shows Description", Name = "Last Laugh Comedy Variety",EventStartTime= "4:30PM", EventEndTime= "7PM",  Fee = 35, PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/14" },
                new EventItem() { EventTypeId=1,EventLocationId=6,EventDateId=7, Description = "Travel, Lifestyle, Food Description", Name = "A Culinary Trip Around the World",  EventStartTime= "1PM", EventEndTime= "9PM", Fee = 45, PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/15" }
            };
        }

        private static IEnumerable<EventLocation> GetPreConfiguredEventLocations()
        {
            return new List<EventLocation>()
            {
                new EventLocation() {Location = "Bellevue"},
                new EventLocation() {Location = "Seattle"},
                new EventLocation() {Location = "Kirkland"},
                new EventLocation() {Location = "Renton" },
                new EventLocation() {Location = "Everett"},
                new EventLocation() {Location = "Tacoma"},
                new EventLocation() {Location = "Lynnwood"},
                new EventLocation() {Location = "Redmond"},
                new EventLocation() {Location = "Federal Way"},
                new EventLocation() {Location = "Bothell"}
            };
        }
        private static IEnumerable<EventDate> GetPreConfiguredEventDates()
        {
            return new List<EventDate>()
            {
                new EventDate() {Date = "6/15/2019"},
                new EventDate() {Date = "12/14/2019"},
                new EventDate() {Date= "9/9/2019"},
                new EventDate() {Date = "7/26/2019" },
                new EventDate() {Date = "11/05/2019"},
                new EventDate() {Date = "10/05/2019"},
                new EventDate() {Date = "8/12/2019"},
                new EventDate() {Date = "7/11/2019"},
                new EventDate() {Date = "9/25/2019"},
                new EventDate() {Date = "1/24/2020"}
            };
        }
        private static IEnumerable<EventType> GetPreConfiguredEventTypes()
        {
            return new List<EventType>()
            {
                new EventType() {Type = "Travel, Lifestyle, Food"},
                new EventType() {Type = "Music and Parties"},
                new EventType() {Type = "Buisness and Networking"},
                new EventType() {Type = "Technology and Science"},
                new EventType() {Type = "Sports and Fitness"},
                new EventType() {Type = "Real Estate"},
                new EventType() {Type = "Arts and Crafts"},
                new EventType() {Type = "Cars, Trucks, Motorcycles"},
                new EventType() {Type = "Finance and Investing"},
                new EventType() {Type = "Film and Movie Making"},
                new EventType() {Type = "Edcuational and Informative"},
                new EventType() {Type = "Volunteer and Charity Fundraising"},
                new EventType() {Type = "Fashion - Catwalk or Thrifting"},
                new EventType() {Type = "Standup Comedy and Live Shows"}
            };
        }
    }
}