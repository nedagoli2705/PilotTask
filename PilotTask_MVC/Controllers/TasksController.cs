using PilotTask_MVC.Models;
using PilotTask_MVC.Services;
using System.Web.Mvc;

namespace PilotTask_MVC.Controllers
{
    public class TasksController : Controller
    {
        private readonly ProfileService _profileService;
        private readonly TaskService _taskService;

        public TasksController(ProfileService profileService, TaskService taskService)
        {
            _profileService = profileService;
            _taskService = taskService;
        }

        public ActionResult Index()
        {
            var tasks = _taskService.GetTasks();
            return View(tasks);
        }

        public ActionResult Details(int id)
        {
            var task = _taskService.GetTaskById(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        public ActionResult Create()
        {
            var profiles = _profileService.GetProfiles();
            ViewBag.Profiles = new SelectList(profiles, "ProfileId", "FullName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Task task)
        {
            if (ModelState.IsValid)
            {
                _taskService.CreateTask(task);
                return RedirectToAction("Index", new { profileId = task.ProfileId });
            }
            return View(task);
        }

        public ActionResult Edit(int id)
        {
            var profiles = _profileService.GetProfiles();
            var task = _taskService.GetTaskById(id);
            ViewBag.Profiles = new SelectList(profiles, "ProfileId", "FullName", task.ProfileId);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Task task)
        {
            if (ModelState.IsValid)
            {
                _taskService.UpdateTask(task);
                return RedirectToAction("Index", new { profileId = task.ProfileId });
            }
            return View(task);
        }

        public ActionResult Delete(int id)
        {
            var task = _taskService.GetTaskById(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var task = _taskService.GetTaskById(id);
            if (task != null)
            {
                _taskService.DeleteTask(id);
            }
            return RedirectToAction("Index");
        }
    }
}