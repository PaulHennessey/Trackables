using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Trackables.Domain;
using Trackables.Models;
using Trackables.Services.Abstract;

namespace Trackables.Controllers
{
    [Authorize]
    public class TrackablesLogController : Controller
    {
        private readonly ITrackableItemServices _trackableItemServices;
        private readonly IUserServices _userServices;

        public ApplicationUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }

        public string UserId
        {
            get
            {
                return UserManager.FindById(User.Identity.GetUserId()).Id;
            }
        }

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
            List<TrackableItem> trackableItems = _trackableItemServices.GetTrackableItems(date, UserId).OrderBy(x => x.Name).ToList();

            var viewModel = new TrackableItemListViewModel()
            {
                TrackableItems = Mapper.Map<IEnumerable<TrackableItem>, IEnumerable<TrackableItemViewModel>>(trackableItems),
            };

            return PartialView("TrackableItemTable", viewModel);
        }


        public ActionResult Save(int? id, int trackableId, decimal? quantity, DateTime date)
        {
            if (id == null)
                _trackableItemServices.InsertTrackableItem(trackableId, date, quantity);
            else
                _trackableItemServices.UpdateTrackableItem(id, quantity);

            List<TrackableItem> trackableItems = _trackableItemServices.GetTrackableItems(date, UserId).OrderBy(x => x.Name).ToList();

            var viewModel = new TrackableItemListViewModel()
            {
                TrackableItems = Mapper.Map<IEnumerable<TrackableItem>, IEnumerable<TrackableItemViewModel>>(trackableItems),
            };

            return PartialView("TrackableItemTable", viewModel);
        }

    }
}
