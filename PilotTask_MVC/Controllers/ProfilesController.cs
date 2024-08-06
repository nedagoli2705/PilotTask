using PilotTask_MVC.Models;
using PilotTask_MVC.Services;
using System.Web.Mvc;

namespace PilotTask_MVC.Controllers
{
    public class ProfilesController : Controller
    {
        private readonly ProfileService _profileService;

        public ProfilesController(ProfileService profileService)
        {
            _profileService = profileService;
        }


        public ActionResult Index()
        {
            var profiles = _profileService.GetProfiles();
            return View(profiles);
        }

        public ActionResult Details(int id)
        {
            var profile = _profileService.GetProfileById(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Profile profile)
        {
            if (ModelState.IsValid)
            {
                _profileService.CreateProfile(profile);
                return RedirectToAction("Index");
            }
            return View(profile);
        }

        public ActionResult Edit(int id)
        {
            var profile = _profileService.GetProfileById(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Profile profile)
        {
            if (ModelState.IsValid)
            {
                _profileService.UpdateProfile(profile);
                return RedirectToAction("Index");
            }
            return View(profile);
        }

        public ActionResult Delete(int id)
        {
            var profile = _profileService.GetProfileById(id);
            if (profile == null)
            {
                return HttpNotFound();
            }
            return View(profile);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Profile profile)
        {
            _profileService.DeleteProfile(profile.ProfileId);
            return RedirectToAction("Index");
        }
    }
}