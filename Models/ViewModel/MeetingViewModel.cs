using Microsoft.AspNetCore.Mvc.Rendering;

namespace MeetingScheduler.Models.ViewModel
{
    public class MeetingViewModel
    {
        public DateTime MeetingStartDateTime { get; set; }
        public DateTime MeetingEndDateTime { get; set; }
        public string MeetingTitle { get; set; }
        public string SelectedRoom { get; set; }
        public List<string> SelectedPersons { get; set; }
        public List<SelectListItem> PeopleSelectedList { get; set; }
        public List<SelectListItem> RoomsSelectedList { get; set; }
    }
}
