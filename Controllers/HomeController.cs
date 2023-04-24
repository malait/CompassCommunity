using MeetingScheduler.Models.ViewModel;
using MeetingScheduler.Service.Class;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace MeetingScheduler.Controllers
{
    public class HomeController : Controller
    {
        private NewMeetingScheduler _newMeetingScheduler;
        /*private readonly ILogger<HomeController> _logger;


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }*/
        public HomeController()
        {
            _newMeetingScheduler = new NewMeetingScheduler();
        }
        public IActionResult Index()
        {
            var model = new MeetingViewModel();
            
            model = PopulateModelData(model);

            return View(model);
        }

        public IActionResult ScheduleMeeting(MeetingViewModel meetingViewModel)
        {
            string errorMessage = _newMeetingScheduler.ScheduleNewMeeting(meetingViewModel);

            if(errorMessage == string.Empty)
            {
                errorMessage = "Meeting Scheduled Successfully";
            }
            ViewBag.Message = errorMessage;
            meetingViewModel = PopulateModelData(meetingViewModel);

            return View("Index", meetingViewModel);
        }

        public MeetingViewModel PopulateModelData(MeetingViewModel meetingViewModel)
        {
            var rooms = RoomsGetter.GetRooms();
            var persons = PersonGetter.GetPersons();

            meetingViewModel.PeopleSelectedList = new List<SelectListItem>();
            foreach (var person in persons)
            {
                meetingViewModel.PeopleSelectedList.Add(new SelectListItem()
                { Text = person.PersonName, Value = person.PersonId.ToString() });
            }

            meetingViewModel.RoomsSelectedList = new List<SelectListItem>();
            foreach (var room in rooms)
            {
                meetingViewModel.RoomsSelectedList.Add(new SelectListItem()
                { Text = room.RoomName, Value = room.RoomId.ToString() });
            }

            return meetingViewModel;
        }
    }
}