using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MeetingScheduler.Models
{
    [Index(nameof(RoomName), IsUnique = true)]
    public class Room
    {
        public int RoomId { get; set; }
        
        public string RoomName { get; set; } = null!;
        [Required]
        [Range(0, 100, ErrorMessage = "Only positive number allowed.")]
        public int Capacity { get; set;}
    }
}
