using System;
using System.Collections.Generic;
using Sl.ToDo.Tasks.Data;
using Sl.ToDo.Tasks.Entities;
using Sl.ToDo.Tasks.ViewModels;

namespace Sl.ToDo.Tasks.Services
{
	public class TaskService
	{
		private readonly TaskRepository _repo;

		public TaskService(TaskRepository repo)
		{
			_repo = repo;
		}

		public List<TaskVM> GetAllTasks()
		{
			return _repo.GetAllTasks();
		}	

		public TaskVM CreateTask(string name, string description, string fileId)
		{
			var task = _repo.CreateTask(name, description, fileId);
			_repo.SetTaskState(task.Id, TaskStatus.Incompleted);
			var vm = _repo.FindTaskVMById(task.Id);
			return vm;
		}

		public TaskVM UpdateTask(int id, string name, string description, string statusName, string fileId)
		{
			Enum.TryParse(statusName, out TaskStatus status);
			return _repo.UpdateTask(id, name, description, status, fileId);
		}
	}
}