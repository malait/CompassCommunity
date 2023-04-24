using MeetingScheduler.Models;

namespace MeetingScheduler.Service.Class
{
    public class PeopleValidation
    {
        public string ValidatePeople(List<int> people, DateTime startDateTime, DateTime EndDateTime)
        {
            string errorMessage = string.Empty;
            List<int> erroredPeopleId = new List<int>();
            //Checking people available for the particular time or not
            var meetingDetails = MeetingBookingGetter.GetMeetingByPerson(people);
            foreach(int person in people)
            {
                var meetingDetailsPerPerson = meetingDetails.Where(x => x.PersonId == person);
                if(meetingDetailsPerPerson != null && meetingDetailsPerPerson.Any())
                {
                    foreach (var meeting in meetingDetailsPerPerson)
                    {
                        int startDifStart = DateTime.Compare(meeting.StartDateTime, startDateTime);
                        int startDifEnd = DateTime.Compare(startDateTime, meeting.EndDateTime);
                        int EndDifStart = DateTime.Compare(meeting.StartDateTime, EndDateTime);
                        int EndDifEnd = DateTime.Compare(EndDateTime, meeting.EndDateTime);

                        if ((startDifStart <= 0 && startDifEnd < 0) || (EndDifStart < 0 && EndDifEnd <= 0))
                        {
                            erroredPeopleId.Add(person);
                        }
                    }
                }
            }
            if (erroredPeopleId.Any())
            {
                List<Person> peopleNotAvailable = PersonGetter.GetPersons()
                                .Where(x => erroredPeopleId.Contains(x.PersonId)).ToList();
                errorMessage = string.Join(",", peopleNotAvailable.Select(x => x.PersonName));
                errorMessage += " are not available for the meeting on selected date and time";
            }

            return errorMessage;
        }
    }
}