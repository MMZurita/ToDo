using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Sl.ToDo.Tasks.Services;
using Sl.ToDo.Tasks.ViewModels;

namespace Sl.ToDo.Api.Controllers
{
    public class TasksController : ApiController
    {
		private readonly TaskService _service;

		public TasksController(TaskService service)
		{
			_service = service;
		}

		public IHttpActionResult Get()
		{
			var tasks = _service.GetAllTasks();

			return Ok(tasks);
		}

		public IHttpActionResult Post(TaskVM vm)
		{
			var task = _service.CreateTask(vm.Name, vm.Description, vm.FileId);

			if (task == null)
			{
				return Conflict();
			}

			return Created($"{Request.RequestUri}{task.Id}", task);
		}

		public IHttpActionResult Put(int id, TaskVM vm)
		{
			var task = _service.UpdateTask(id, vm.Name, vm.Description, vm.Status, vm.FileId);

			return Ok(task);
		}
    }
}
