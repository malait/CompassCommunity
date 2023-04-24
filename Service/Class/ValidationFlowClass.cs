using MeetingScheduler.Models.ViewModel;

namespace MeetingScheduler.Service.Class
{
    public class ValidationFlowClass
    {
        private MeetingDateTimeValidation meetingDateTimeValidation;
        private RoomValidation roomValidation;
        private PeopleValidation peopleValidation;
        public ValidationFlowClass()
        {
            meetingDateTimeValidation = new MeetingDateTimeValidation();
            roomValidation = new RoomValidation();
            peopleValidation = new PeopleValidation();
        }
        public string ValidationFlow(MeetingViewModel meetingViewModel)
        {
            string errorMessage = string.Empty;

            errorMessage = meetingDateTimeValidation.ValidateMeetingDateTime(
                            meetingViewModel.MeetingStartDateTime, meetingViewModel.MeetingEndDateTime);
            if(errorMessage == string.Empty)
            {
                errorMessage = roomValidation.ValidateRoom(meetingViewModel.SelectedRoom,
                            meetingViewModel.SelectedPersons.Count, meetingViewModel.MeetingStartDateTime,
                            meetingViewModel.MeetingEndDateTime);
            }

            if(errorMessage == string.Empty)
            {
                List<int> personIds = meetingViewModel.SelectedPersons.Select(x => Convert.ToInt32(x)).ToList();
                
                errorMessage = peopleValidation.ValidatePeople(personIds, meetingViewModel.MeetingStartDateTime,
                                            meetingViewModel.MeetingEndDateTime);
            }
            return errorMessage;
        }
    }
}
