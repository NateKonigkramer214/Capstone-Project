using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Capstone.Models
{
    public class Theatre
    {
        public int Id { get; set; }
        public int RowCount { get; set; }
        public int SeatsPerRow { get; set; }
        public List<Viewing> Viewings { get; set; }
    }

    public class Viewing
    {
        public int Id { get; set; }
        public DateTime ViewingDateTime { get; set; }
        public Movie Movie { get; set; }
        public Theatre Theatre { get; set; }
        public List<Booking> Bookings { get; set; }
    }

    public class Movie
    { 
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImdbId { get; set; }
        public List<Viewing> Viewings { get; set; }
    }

    //[EntityTypeConfiguration(typeof(UsersList))]
    public class UsersList
    {
        public string Email { get; set; }
        public string UserId { get; set; }
        public string RoleName { get; set; }
        public string RoleId { get; set; }
    }
}
