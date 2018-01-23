using System.Threading.Tasks;
using System.Web.Mvc;
using Sl.ToDo.App.Web.Models;
using Sl.ToDo.Tasks.ViewModels;

namespace Sl.ToDo.App.Web.Controllers
{
	public class TasksController : Controller
	{
		private readonly TasksProxy _proxy;

		public TasksController()
		{
			_proxy = TasksProxy.Create();
		}

		// GET: Tasks
		public async Task<ActionResult> Index()
		{
			var tasks = await _proxy.GetAllTasks();

			return View(tasks);
		}

		public ActionResult New()
		{
			return View();
		}

		[HttpPost]
		public async Task<ActionResult> CreateNew(TaskVM task)
		{
			if (Request.Files.Count == 1)
			{
				var file = Request.Files[0];
				// TODO: Save file and generate random name.
			}

			await _proxy.CreateTask(task);

			return RedirectToAction("Index");
		}
	}
}