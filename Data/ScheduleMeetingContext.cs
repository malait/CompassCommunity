using MeetingScheduler.Models;
using Microsoft.EntityFrameworkCore;

namespace MeetingScheduler.Data
{
    public class ScheduleMeetingContext : DbContext
    {
        public DbSet<Person> Persons { get; set; } = null!;
        public DbSet<Room> Rooms { get; set; } = null!;
        public DbSet<MeetingBooking> bookings { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\ProjectModels;Initial Catalog=ScheduleMeeting;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
    }
}
