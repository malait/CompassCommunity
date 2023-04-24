namespace MeetingScheduler.Service.Class
{
    public class MeetingDateTimeValidation
    {
        public string ValidateMeetingDateTime(DateTime startDateTime, DateTime EndDateTime)
        {
            string errorMessage = string.Empty;

            //Start date time should be greater than current date time
            if (DateTime.Compare(DateTime.Now, startDateTime) > 0)
            {
                errorMessage = "StartDateTime Should be greater than current date time";
            }
            //End date time should be greater than start date time
            else if (DateTime.Compare(startDateTime, EndDateTime)>0)
            {
                errorMessage = "Meeting End date time should be greater than start date time";
            }
            //Meeting should not exceed more than 8 hours
            else if(((int)EndDateTime.Subtract(startDateTime).TotalMinutes) > 480)
            {
                errorMessage = "Meeting should not exceed more than 8 hours";
            }

            return errorMessage;
        }
    }
}
