using System;
using System.Collections.Generic;
using System.Text;
using ClassLibraryScheduler.Dal;

namespace ClassLibraryScheduler.Model
{
    public class ModelScheduling
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public string CrewName { get; set; }
        public int ClientId { get; set; }
        public int CrewId { get; set; }
        public string Title { get; set; }
        public DateTime ScheduledStart { get; set; }
        public DateTime ScheduledEnd { get; set; }

        public ModelScheduling(int id, int clientId, int crewId, string title, DateTime scheduledStart, DateTime scheduledEnd)
        {
            Id = id;
            ClientId = clientId;
            CrewId = crewId;
            Title = title;
            ScheduledStart = scheduledStart;
            ScheduledEnd = scheduledEnd;
        }

        public ModelScheduling(int clientId, int crewId, string title, DateTime scheduledStart, DateTime scheduledEnd)
        {
            ClientId = clientId;
            CrewId = crewId;
            Title = title;
            ScheduledStart = scheduledStart;
            ScheduledEnd = scheduledEnd;
        }

        public ModelScheduling()
        {
        }

        /*public string scheduling()
        {
            DalScheduling dalScheduling = new DalScheduling();
            List<string> Schedulinglist = new List<string>(); 
            foreach(var scheduling in dalScheduling.Schedules())
            {
                dalScheduling.Schedules;
            }
        }*/
    }
}
