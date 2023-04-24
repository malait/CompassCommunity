using MeetingScheduler.Data;
using MeetingScheduler.Models;

namespace MeetingScheduler.Service.Class
{
    public static class MeetingBookingGetter
    {
        public static List<MeetingBooking> GetMeetingBookings()
        {
            using ScheduleMeetingContext context = new ScheduleMeetingContext();
            var meetingDetails = context.bookings.ToList();

            return meetingDetails;
        }

        public static List<MeetingBooking> GetMeetingByRoom(int roomId)
        {
            using ScheduleMeetingContext context = new ScheduleMeetingContext();
            var meetingDetails = context.bookings.Where(x=> x.Room.RoomId == roomId).ToList();

            return meetingDetails;
        }

        public static List<MeetingBooking> GetMeetingByPerson(List<int> peopleId)
        {
            using ScheduleMeetingContext context = new ScheduleMeetingContext();
            var meetingDetails = context.bookings.Where(x => peopleId.Contains(x.Person.PersonId)).ToList();

            return meetingDetails;
        }
    }
}
