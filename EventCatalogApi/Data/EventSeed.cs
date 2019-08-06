using System;
using EventCatalogApi.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                new EventItem() { EventTypeId=1,EventLocationId=10,EventDateId=1, Description = "Join us for your travel guide as well as free Food ", Name = "Travel, Lifestyle, Food",EventStartTime= "7PM", EventEndTime= "9PM", Fee = 20, PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/1" },
                new EventItem() { EventTypeId=2,EventLocationId=9, EventDateId=2,Description = "Dance the night away with us at our new location where we have the spot like just for you", Name = "Music and Party",EventStartTime= "7PM", EventEndTime= "1am",  Fee= 60, PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/2" },
                new EventItem() { EventTypeId=3,EventLocationId=8,EventDateId=3, Description = "Are you ready to learn more about different businesses as well as meet new people in a proffessional setting? if yes come join us", Name = "Buisness and Networking", EventStartTime= "3PM", EventEndTime="8PM",  Fee = 100, PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/3" },
                new EventItem() { EventTypeId=4,EventLocationId=7,EventDateId=4, Description = "Explore different technology and Science with us ", Name = "Technology and Science", EventStartTime= "8PM", EventEndTime= "2AM",  Fee = 50, PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/4" },
                new EventItem() { EventTypeId=5,EventLocationId=6,EventDateId=5, Description = "Game night and fitness", Name = "Sports and Fitness", EventStartTime= "2PM", EventEndTime= "9PM" , Fee = 25, PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/5" },
                new EventItem() { EventTypeId=6,EventLocationId=5,EventDateId=8, Description = "Real Estate ", Name = "Real Estate", EventStartTime= "3PM", EventEndTime= "8PM", Fee = 75, PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/6" },
                new EventItem() { EventTypeId=7,EventLocationId=4,EventDateId=9, Description = "Come create something fun ", Name = "Arts and Crafts", EventStartTime= "1PM", EventEndTime= "5PM", Fee = 15, PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/7"  },
                new EventItem() { EventTypeId=8,EventLocationId=3, EventDateId=10,Description = "Get ready to check some automobile", Name = "Cars, Trucks, Motorcycles ",EventStartTime= "2PM", EventEndTime= "6PM", Fee = 10, PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/8" },
                new EventItem() { EventTypeId=9,EventLocationId=2, EventDateId=3,Description = " Learn how to invest", Name = "Finance and Investing",  EventStartTime= "4PM", EventEndTime= "10PM", Fee = 20, PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/9" },
                new EventItem() { EventTypeId=10,EventLocationId=1,EventDateId=5, Description = "come learn how you can make movies", Name = "Film and Movie Making",  EventStartTime= "5PM", EventEndTime= "11PM",Fee = 10, PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/10" },
                new EventItem() { EventTypeId=11,EventLocationId=2,EventDateId=6, Description = "Educational ", Name = "Edcuational and Informative ", EventStartTime= "7PM", EventEndTime= "1AM", Fee = 30, PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/11" },
                new EventItem() { EventTypeId=12,EventLocationId=3, EventDateId=2,Description = "Do you like helping others? well this is the right place for you", Name = "Volunteer and Charity Fundraising",EventStartTime= "6PM", EventEndTime= "10PM", Fee = 0, PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/12" },
                new EventItem() { EventTypeId=13,EventLocationId=4,EventDateId=8, Description = " Seattle Fashion week", Name = "Fashion - Catwalk or Thrifting ",EventStartTime= "6PM", EventEndTime= "8PM",  Fee = 25, PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/13" },
                new EventItem() { EventTypeId=14,EventLocationId=5,EventDateId=1, Description = " Great standup comedy with food and drinks ", Name = "Standup Comedy and Live Shows",EventStartTime= "4:30PM", EventEndTime= "7PM",  Fee = 35, PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/14" },
                new EventItem() { EventTypeId=1,EventLocationId=6,EventDateId=7, Description = "Fun in the sun", Name = "Travel, Lifestyle, Food",  EventStartTime= "1PM", EventEndTime= "9PM", Fee = 45, PictureURL = "http://externalcatalogbaseurltobereplaced/api/pic/15" }
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