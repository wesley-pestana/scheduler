using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClassLibraryScheduler.Model;
using ClassLibraryScheduler.Dal;

namespace hairdressing_schedule.Controllers
{
    public class ClientController : Controller
    {
        public ActionResult Client()
        {
            DalHairdresserClient client = new DalHairdresserClient();
            return View(client.SearchClient(""));
        }
        [HttpPost]
        public ActionResult Client(string FindClient)
        {
            DalHairdresserClient client = new DalHairdresserClient();
            return View(client.SearchClient(FindClient));
        }
        public ActionResult InsertClient()
        {
            return View();
        }
        [HttpPost]
        public ActionResult InsertClient(string InsName,string InsAddress,int InsPhone,string InsEmail)
        {
            DalHairdresserClient client = new DalHairdresserClient();
            ModelClient modelClient = new ModelClient(InsName,InsAddress,InsPhone,InsEmail);
            client.InsetClient(modelClient);
            return RedirectToAction("Client");   
        }

        public ActionResult UpdateClient(int Id)
        {
            DalHairdresserClient client = new DalHairdresserClient();
            var update = client.SearchId(Id);
            return View(update);
        }
        [HttpPost]
        public ActionResult UpdateClient(int Id, string UpdName, string UpdAddress, int UpdPhone, string UpdEmail)
        {
            DalHairdresserClient client = new DalHairdresserClient();
            ModelClient modelClient = new ModelClient(Id, UpdName, UpdAddress, UpdPhone, UpdEmail);
            client.UpdateClient(modelClient);
            return RedirectToAction("Client");
        }

        public ActionResult DeleteClient(int Id)
        {
            DalHairdresserClient client = new DalHairdresserClient();
            client.DeleteClient(Id);
            return RedirectToAction("Client");
        }
    }
}