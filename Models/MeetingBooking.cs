using System.ComponentModel.DataAnnotations;

namespace MeetingScheduler.Models
{
    public class MeetingBooking
    {
        [Key]
        public int BookingId { get; set; }
        public string Title { get; set; } = null!;
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }

        public int PersonId { get; set; }
        public int RoomId { get; set; }
        public Person Person { get; set; } = null!;
        public Room Room { get; set; } = null!;

    }
}
