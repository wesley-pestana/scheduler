using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClassLibraryScheduler.Model;
using ClassLibraryScheduler.Dal;

namespace hairdressing_schedule.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new ModelCalendarEvent());
        }

        public JsonResult GetEvents()
        {
            var events = new List<ModelCalendarEvent>();
            DalScheduling dalScheduling = new DalScheduling();
            foreach(var scheduling in dalScheduling.Schedules())
            {
                events.Add(new ModelCalendarEvent()
                {
                    title = scheduling.ClientName,
                    start = scheduling.ScheduledStart.ToString("yyyy-MM-ddTHH:mm"),
                    end = scheduling.ScheduledEnd.ToString("yyyy-MM-ddTHH:mm")
                });
            }
            return Json(events.ToArray(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult InsertSchedule()
        {
            DalHairdresserClient client = new DalHairdresserClient();
            //var listclient = client.SearchClient("");
            ViewBag.listclient = client.SearchClient("");

            DalHairdresserCrew crew = new DalHairdresserCrew();            
            //var listcrew = crew.SearchCrew("");
            ViewBag.listcrew = crew.SearchCrew("");

            return View();
        }

        [HttpPost]
        public ActionResult InsertSchedule(int searchClientId,int searchCrewId,DateTime InsStartTime, DateTime InsEndTime)
        {
            DalScheduling scheduling = new DalScheduling();
            ModelScheduling modelScheduling = new ModelScheduling(searchClientId, searchCrewId, "",InsStartTime, InsEndTime);
            scheduling.InsertSchedule(modelScheduling);
            return RedirectToAction("Index");
        }
    }
}