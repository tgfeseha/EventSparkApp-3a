namespace EventCatalogApi.Domain
{
    public class EventItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Fee { get; set; }
        public string PictureURL { get; set; }
        public string EventStartTime { get; set; }
        public string EventEndTime { get; set; }

        public int EventTypeId { get; set; }
        public virtual EventType EventType { get; set; }

        public int EventLocationId { get; set; }
        public virtual EventLocation EventLocation { get; set; }

        public int EventDateId { get; set; }
        public virtual EventDate EventDate { get; set; }
    }
}