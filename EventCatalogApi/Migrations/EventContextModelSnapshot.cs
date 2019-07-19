﻿// <auto-generated />
using EventCatalogApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EventCatalogApi.Migrations
{
    [DbContext(typeof(EventContext))]
    partial class EventContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("Relational:Sequence:.event_date_hilo", "'event_date_hilo', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:.event_hilo", "'event_hilo', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:.event_location_hilo", "'event_location_hilo', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:.event_types_hilo", "'event_types_hilo', '', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EventCatalogApi.Domain.EventDate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(100)
                        .HasAnnotation("SqlServer:HiLoSequenceName", "event_date_hilo")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("Date");

                    b.HasKey("Id");

                    b.ToTable("EventDates");
                });

            modelBuilder.Entity("EventCatalogApi.Domain.EventItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "event_hilo")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("Description");

                    b.Property<int>("EventDateId");

                    b.Property<string>("EventEndTime")
                        .IsRequired();

                    b.Property<int>("EventLocationId");

                    b.Property<string>("EventStartTime")
                        .IsRequired();

                    b.Property<int>("EventTypeId");

                    b.Property<decimal>("Fee");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("PictureURL");

                    b.HasKey("Id");

                    b.HasIndex("EventDateId");

                    b.HasIndex("EventLocationId");

                    b.HasIndex("EventTypeId");

                    b.ToTable("EventIds");
                });

            modelBuilder.Entity("EventCatalogApi.Domain.EventLocation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "event_location_hilo")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("EventLocations");
                });

            modelBuilder.Entity("EventCatalogApi.Domain.EventType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "event_types_hilo")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("EventTypes");
                });

            modelBuilder.Entity("EventCatalogApi.Domain.EventItem", b =>
                {
                    b.HasOne("EventCatalogApi.Domain.EventDate", "EventDate")
                        .WithMany()
                        .HasForeignKey("EventDateId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EventCatalogApi.Domain.EventLocation", "EventLocation")
                        .WithMany()
                        .HasForeignKey("EventLocationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EventCatalogApi.Domain.EventType", "EventType")
                        .WithMany()
                        .HasForeignKey("EventTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
