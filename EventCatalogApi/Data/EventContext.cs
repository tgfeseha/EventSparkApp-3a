using EventCatalogApi.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogApi.Data
{
    public class EventContext : DbContext
    {
        public EventContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<EventLocation> EventLocations { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<EventDate> EventDates { get; set; }
        public DbSet<EventItem> EventItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventLocation>(ConfigureEventLocation);
            modelBuilder.Entity<EventType>(ConfigureEventType);
            modelBuilder.Entity<EventDate>(ConfigureEventDate);
            modelBuilder.Entity<EventItem>(ConfigureEventItem);
        }

        private void ConfigureEventItem(EntityTypeBuilder<EventItem> builder)
        {
           builder.ToTable("EventIds");
           builder.Property(c => c.Id)
               .IsRequired()
               .ForSqlServerUseSequenceHiLo("event_hilo");

           builder.Property(c => c.Name)
               .IsRequired()
               .HasMaxLength(100);  //Title is 100 characters or less

          /* builder.Property(c => c.EventStartDate)
               .IsRequired();*/
            builder.Property(c => c.EventStartTime)
              .IsRequired();
            /*builder.Property(c => c.EventEndDate)
              .IsRequired();*/
            builder.Property(c => c.EventEndTime)
              .IsRequired();
            builder.Property(c => c.Fee)
              .IsRequired();

            builder.HasOne(c => c.EventType)
               .WithMany()
               .HasForeignKey(c => c.EventTypeId);

           builder.HasOne(c => c.EventLocation)
               .WithMany()
               .HasForeignKey(c => c.EventLocationId);

           builder.HasOne(c => c.EventDate)
               .WithMany()
               .HasForeignKey(c => c.EventDateId);
        }
        
        private void ConfigureEventType(EntityTypeBuilder<EventType> builder)
        {
            builder.ToTable("EventTypes");
            builder.Property(c => c.Id)
                .IsRequired()
                .ForSqlServerUseSequenceHiLo("event_types_hilo");

            builder.Property(c => c.Type)
                .IsRequired()
                .HasMaxLength(100);  //Type is 100 characters or less
        }

        private void ConfigureEventLocation(EntityTypeBuilder<EventLocation> builder)
        {
            builder.ToTable("EventLocations");
            builder.Property(c => c.Id)
                .IsRequired()
                .ForSqlServerUseSequenceHiLo("event_location_hilo");

            builder.Property(c => c.Location)
                .IsRequired()
                .HasMaxLength(100);  //Brand is 100 characters or less
        }

        private void ConfigureEventDate(EntityTypeBuilder<EventDate> builder)
        {
            builder.ToTable("EventDates");
            builder.Property(c => c.Id).IsRequired().ForSqlServerUseSequenceHiLo("event_date_hilo");

            builder.Property(c => c.Id)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}