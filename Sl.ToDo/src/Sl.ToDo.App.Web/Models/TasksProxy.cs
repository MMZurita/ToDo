using System.Collections.Generic;
using System.Threading.Tasks;
using Sl.ToDo.Tasks.ViewModels;

namespace Sl.ToDo.App.Web.Models
{
	public class TasksProxy : ApiProxy
	{
		protected TasksProxy() : base("http://localhost:50579/api/Tasks")
		{
		}

		public async Task<List<TaskVM>> GetAllTasks()
		{
			return await Execute<List<TaskVM>>(string.Empty);
		}

		public async Task<TaskVM> CreateTask(TaskVM task)
		{
			return await ExecutePost(task);
		}

		public static TasksProxy Create()
		{
			return new TasksProxy();
		}
	}
}