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
    public class TrackablesController : Controller
    {
        private readonly ITrackablesServices _trackablesServices;
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


        public TrackablesController()
        { }


        public TrackablesController(ITrackablesServices trackablesServices, IUserServices userServices)
        {
            _trackablesServices = trackablesServices;
            _userServices = userServices;
        }


        public ActionResult Index()
        {
            var viewModel = GetTrackablesModel();

            return View("Index", viewModel);
        }


        [HttpGet]
        public ViewResult Create()
        {
            Trackable trackable = new Trackable()
            {
                Name = String.Empty,
            };

            TrackableViewModel trackableViewModel = Mapper.Map<Trackable, TrackableViewModel>(trackable);

            return View(trackableViewModel);
        }


        [HttpPost]
        public ActionResult Create(TrackableViewModel trackableViewModel)
        {
            if (ModelState.IsValid)
            {
                Trackable trackable = Mapper.Map<TrackableViewModel, Trackable>(trackableViewModel);

                _trackablesServices.CreateTrackable(trackable, UserId);

                return RedirectToAction("Index");
            }
            else
            {
                return View(trackableViewModel);
            }
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            Trackable trackable = _trackablesServices.GetTrackable(id);

            TrackableViewModel trackableViewModel = Mapper.Map<Trackable, TrackableViewModel>(trackable);

            return View(trackableViewModel);
        }


        [HttpPost]
        public ActionResult Edit(TrackableViewModel trackableViewModel)
        {
            if (ModelState.IsValid)
            {
                Trackable trackable = Mapper.Map<TrackableViewModel, Trackable>(trackableViewModel);

                _trackablesServices.UpdateTrackable(trackable);

                return RedirectToAction("Index");
            }
            else
            {
                return View(trackableViewModel);
            }
        }


        public ActionResult Delete(int id)
        {
            _trackablesServices.DeleteTrackable(id);

            var viewModel = GetTrackablesModel();

            return PartialView("TrackablesTable", viewModel);
        }


        private TrackablesViewModel GetTrackablesModel()
        {
            List<Trackable> items = _trackablesServices.GetTrackables(UserId).OrderBy(x => x.Name).ToList();

            var viewModel = new TrackablesViewModel()
            {
                Trackables = items
            };

            return viewModel;
        }
    }
}
