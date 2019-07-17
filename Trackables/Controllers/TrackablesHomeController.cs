using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Trackables.Controllers
{
    public class TrackablesHomeController : Controller
    {
        // GET: TrackablesHome
        public ActionResult Index()
        {
            return View();
        }
    }
}