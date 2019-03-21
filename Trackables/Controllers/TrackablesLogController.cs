using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Trackables.Domain;
using Trackables.Models;
using Trackables.Services.Abstract;

namespace Trackables.Controllers
{
    
    public class TrackablesLogController : Controller
    {
        private readonly ITrackableItemServices _trackableItemServices;
        private readonly IUserServices _userServices;

        public TrackablesLogController()
        { }

        public TrackablesLogController(ITrackableItemServices trackableItemServices, IUserServices userServices)
        {
            _trackableItemServices = trackableItemServices;
            _userServices = userServices;
        }

        public ActionResult Index()
        {
            return View("Index", new TrackableItemListViewModel());
        }

        public ActionResult Refresh(DateTime date)
        {
            User user = _userServices.GetUser(User.Identity.Name);

            List<TrackableItem> trackableItems = _trackableItemServices.GetTrackableItems(date, user.Id).OrderBy(x => x.Name).ToList();

            var viewModel = new TrackableItemListViewModel()
            {
                TrackableItems = Mapper.Map<IEnumerable<TrackableItem>, IEnumerable<TrackableItemViewModel>>(trackableItems),
            };

            return Json(viewModel, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Save(int? id, int trackableId, decimal? quantity, DateTime date)
        {
            if (id == null)
                _trackableItemServices.InsertTrackableItem(trackableId, date, quantity);
            else
                _trackableItemServices.UpdateTrackableItem(id, quantity);

            return RedirectToAction("Index");
        }

    }
}
