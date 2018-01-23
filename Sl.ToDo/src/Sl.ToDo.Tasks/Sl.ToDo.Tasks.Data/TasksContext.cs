using System.Data.Entity;
using Sl.ToDo.Tasks.Entities;

namespace Sl.ToDo.Tasks.Data
{
	public class TasksContext : DbContext
	{
		public DbSet<Task> Tasks { get; set; }
	}
}