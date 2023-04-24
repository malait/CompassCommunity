using MeetingScheduler.Data;
using MeetingScheduler.Models;

namespace MeetingScheduler.Service.Class
{
    public static class RoomsGetter
    {
        public static List<Room> GetRooms()
        {
            using ScheduleMeetingContext context = new ScheduleMeetingContext();
            var rooms = context.Rooms.ToList();

            return rooms;
        }

        public static Room GetRoom(int roomId)
        {
            using ScheduleMeetingContext context = new ScheduleMeetingContext();
            var room = context.Rooms.Where(x => x.RoomId == roomId).FirstOrDefault();

            return room;
        }
    }
}
