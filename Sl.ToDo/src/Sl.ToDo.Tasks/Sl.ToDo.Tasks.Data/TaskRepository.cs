using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Sl.ToDo.Tasks.Entities;
using Sl.ToDo.Tasks.ViewModels;

namespace Sl.ToDo.Tasks.Data
{
	public class TaskRepository
	{
		private readonly TasksContext _context;

		public TaskRepository()
		{
			_context = TasksContext.Create();
		}

		public List<TaskVM> GetAllTasks()
		{
			var tasks = _context.Tasks.AsNoTracking()
				.Select(t => new TaskVM
				{
					Id = t.Id,
					Name = t.Name,
					Description = t.Description,
					FileId = t.FileId,
					Status = t.Status.ToString()
				}).ToList();

			return tasks;
		}

		public Task CreateTask(string name, string description, string fileId)
		{
			var task = Task.Create(name, description, fileId);

			// TODO: Task creation validation
			_context.Tasks.Add(task);
			_context.SaveChanges();

			return task;
		}

		public TaskVM FindTaskVMById(int id)
		{
			var vm = _context.Tasks.Where(t => t.Id == id).Select(t => new TaskVM
			{
				Id = t.Id,
				Name = t.Name,
				Description = t.Description,
				FileId = t.FileId,
				Status = t.Status.ToString()
			}).SingleOrDefault();

			return vm;
		}

		public void SetTaskState(int taskId, TaskStatus status)
		{
			var task = _context.Tasks.Find(taskId);
			// TODO: Null validation
			task.Status = status;
			_context.Entry(task).State = EntityState.Modified;
			_context.SaveChanges();
		}

		public TaskVM UpdateTask(int id, string name, string description, TaskStatus status, string fileId)
		{
			var task = _context.Tasks.Find(id);

			// TODO: Null validation
			task.Name = name;
			task.Description = description;
			task.Status = status;
			task.FileId = fileId;

			_context.Entry(task).State = EntityState.Modified;
			_context.SaveChanges();

			var vm = FindTaskVMById(id);

			return vm;
		}

		public static TaskRepository Create()
		{
			return new TaskRepository();
		}
	}
}
