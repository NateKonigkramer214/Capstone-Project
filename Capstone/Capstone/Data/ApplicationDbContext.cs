using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Capstone.Models;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using Microsoft.Build.Framework;
using Microsoft.AspNetCore.Identity;
using Capstone.Data.Migrations;

namespace Capstone.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Theatre>().HasKey(x => x.Id);
            builder.Entity<Theatre>().HasMany(x => x.Viewings).WithOne(x => x.Theatre);

            builder.Entity<Movie>().HasKey(x => x.Id);
            //builder.Entity<Movie>().HasKey(x => x.ImdbId);
            builder.Entity<Movie>().HasMany(x => x.Viewings).WithOne(x => x.Movie);

            builder.Entity<Viewing>().HasKey(x => x.Id);
            builder.Entity<Viewing>().HasOne(x => x.Theatre).WithMany(x => x.Viewings);
            builder.Entity<Viewing>().HasOne(x => x.Movie).WithMany(x => x.Viewings);
            builder.Entity<Viewing>().HasMany(x => x.Bookings);

            builder.Entity<Contact>().HasKey(x => x.Id);

            builder.Entity<Booking>().HasKey(x => x.Id);
            builder.Entity<Booking>().HasMany(x => x.Seats);
            builder.Entity<Booking>().HasOne(x => x.Viewing).WithMany(x => x.Bookings);

            builder.Entity<Seat>().HasKey(x => x.Id);
            builder.Entity<Booking>().HasOne(x => x.User);
        }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Viewing> Viewings { get; set; }

        public DbSet<Theatre> Theatres { get; set; }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Booking> Bookings { get; set; }
    }
}