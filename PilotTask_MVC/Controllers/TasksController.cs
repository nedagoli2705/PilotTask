using PilotTask_MVC.Models;
using PilotTask_MVC.Services;
using PilotTask_MVC.Services.Interfaces;
using System.Web.Mvc;

namespace PilotTask_MVC.Controllers
{
    public class TasksController : Controller
    {
        private readonly IProfileService _profileService;
        private readonly ITaskService _taskService;

        public TasksController(IProfileService profileService, ITaskService taskService)
        {
            _profileService = profileService;
            _taskService = taskService;
        }

        public ActionResult Index(int id)
        {
            ViewBag.ProfileId = id;
            var tasks = _taskService.GetTasksByProfileId(id);
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

        public ActionResult Create(int profileId)
        {
            var model = new Task { ProfileId = profileId };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Task task)
        {
            if (ModelState.IsValid)
            {
                _taskService.CreateTask(task);
                return RedirectToAction("Index", new { id = task.ProfileId });
            }
            return View(task);
        }

        public ActionResult Edit(int id)
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
        public ActionResult Edit(Task task)
        {
            if (ModelState.IsValid)
            {
                _taskService.UpdateTask(task);
                return RedirectToAction("Index", new { id = task.ProfileId });
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
            var profileId = task.ProfileId;
            if (task != null)
            {
                _taskService.DeleteTask(id);
            }

            return RedirectToAction("Index", new { id = profileId });
        }
    }
}