using MeetingScheduler.Data;
using MeetingScheduler.Models;

namespace MeetingScheduler.Service.Class
{
    public static class PersonGetter
    {
        public static List<Person> GetPersons()
        {            
            using ScheduleMeetingContext context = new ScheduleMeetingContext();
            var persons = context.Persons.ToList();
            
            return persons;
        }

        public static List<Person> GetPersons(List<int> list)
        {
            using ScheduleMeetingContext context = new ScheduleMeetingContext();
            var persons = context.Persons.Where(x=> list.Contains(x.PersonId)).ToList();

            return persons;
        }
    }
}
