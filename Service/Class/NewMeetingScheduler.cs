using MeetingScheduler.Data;
using MeetingScheduler.Models;
using MeetingScheduler.Models.ViewModel;

namespace MeetingScheduler.Service.Class
{
    public class NewMeetingScheduler
    {
        private ValidationFlowClass _validationFlowClass;

        public NewMeetingScheduler()
        {
            _validationFlowClass = new ValidationFlowClass();
        }
        public string ScheduleNewMeeting(MeetingViewModel meetingViewModel)
        {
            //Checks all the validation
            string errorMessage = _validationFlowClass.ValidationFlow(meetingViewModel);
            
            //If the error message is empty add the new meeting to the database
            if(errorMessage ==string.Empty)
            {
                Room room = RoomsGetter.GetRoom(Convert.ToInt32(meetingViewModel.SelectedRoom));
                List<Person> people = PersonGetter.GetPersons(
                    meetingViewModel.SelectedPersons.Select(x => Convert.ToInt32(x)).ToList());

                //Store the meeting into database
                using ScheduleMeetingContext context = new ScheduleMeetingContext();
                foreach(var person in people)
                {
                    context.Add(new MeetingBooking()
                    {
                        Title = meetingViewModel.MeetingTitle,
                        RoomId= room.RoomId,
                        PersonId = person.PersonId,
                        //Room = room,
                        //Person = person,
                        StartDateTime = meetingViewModel.MeetingStartDateTime,
                        EndDateTime = meetingViewModel.MeetingEndDateTime
                    });
                    context.SaveChanges();
                }
            }

            return errorMessage;
        }
    }
}
