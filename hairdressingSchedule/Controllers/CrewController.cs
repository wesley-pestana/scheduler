using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClassLibraryScheduler.Model;
using ClassLibraryScheduler.Dal;

namespace hairdressing_schedule.Controllers
{
    public class CrewController : Controller
    {
        public ActionResult Crew()
        {
            DalHairdresserCrew Crew = new DalHairdresserCrew();
            return View(Crew.SearchCrew(""));
        }
        [HttpPost]
        public ActionResult Crew(string FindCrew)
        {
            DalHairdresserCrew Crew = new DalHairdresserCrew();
            return View(Crew.SearchCrew(FindCrew));
        }
        public ActionResult InsertCrew()
        {
            return View();
        }
        [HttpPost]
        public ActionResult InsertCrew(string InsName,string InsAddress,int InsPhone,string InsEmail)
        {
            DalHairdresserCrew Crew = new DalHairdresserCrew();
            ModelHairdresserCrew ModelHairdresserCrew = new ModelHairdresserCrew(InsName,InsAddress,InsPhone,InsEmail);
            Crew.InsetCrew(ModelHairdresserCrew);
            return RedirectToAction("Crew");   
        }

        public ActionResult UpdateCrew(int Id)
        {
            DalHairdresserCrew Crew = new DalHairdresserCrew();
            var update = Crew.SearchId(Id);
            return View(update);
        }
        [HttpPost]
        public ActionResult UpdateCrew(int UpdId, string UpdName, string UpdAddress, int UpdPhone, string UpdEmail)
        {
            DalHairdresserCrew Crew = new DalHairdresserCrew();
            ModelHairdresserCrew ModelHairdresserCrew = new ModelHairdresserCrew(UpdId, UpdName, UpdAddress, UpdPhone, UpdEmail);
            Crew.UpdateCrew(ModelHairdresserCrew);
            return RedirectToAction("Crew");
        }

        public ActionResult DeleteCrew(int Id)
        {
            DalHairdresserCrew Crew = new DalHairdresserCrew();
            Crew.DeleteCrew(Id);
            return RedirectToAction("Crew");
        }
    }
}