using MeetingScheduler.Data;
using MeetingScheduler.Models;

namespace MeetingScheduler.Service.Class
{
    public class RoomValidation
    {
        public string ValidateRoom(string room, int peopleCount, DateTime startDateTime, DateTime EndDateTime)
        {
            string errorMessage = string.Empty;
            int roomId = Convert.ToInt32(room);
            using ScheduleMeetingContext context = new ScheduleMeetingContext();
            //People count should not exceed the room capacity
            int roomCapacity = context.Rooms.Where(x => x.RoomId == roomId)
                                            .Select(x=>x.Capacity).FirstOrDefault();
            if (roomCapacity < peopleCount)
            {
                errorMessage = "People count should not exceed the room capacity";
            }
            //Room is not available between the meeting date and Time
            else
            {
                var meetingDetails = MeetingBookingGetter.GetMeetingByRoom(roomId);
                if(meetingDetails!=null && meetingDetails.Count>0)
                {
                    foreach(var meeting in meetingDetails)
                    {
                        int startDifStart = DateTime.Compare(meeting.StartDateTime, startDateTime);
                        int startDifEnd = DateTime.Compare(startDateTime, meeting.EndDateTime);
                        int EndDifStart = DateTime.Compare(meeting.StartDateTime, EndDateTime);
                        int EndDifEnd = DateTime.Compare(EndDateTime, meeting.EndDateTime);
                        
                        if ((startDifStart <=0 && startDifEnd <0) || (EndDifStart <0 && EndDifEnd <=0))
                        {
                            errorMessage = "Room not available on the selected date and time";
                        }
                    }
                }
            }

            return errorMessage;
        }
    }
}
