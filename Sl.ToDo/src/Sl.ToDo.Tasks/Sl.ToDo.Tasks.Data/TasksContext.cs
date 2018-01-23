using System.Data.Entity;
using System.Data.Entity.SqlServer;
using Sl.ToDo.Tasks.Entities;

namespace Sl.ToDo.Tasks.Data
{
	[DbConfigurationType(typeof(ContextConfiguration))]
	public class TasksContext : DbContext
	{
		public TasksContext() : base("name=ToDoConnection")
		{
			Database.CommandTimeout = 5;
			Database.SetInitializer(new CreateDatabaseIfNotExists<TasksContext>());
		}

		public DbSet<Task> Tasks { get; set; }

		public static TasksContext Create()
		{
			return new TasksContext();
		}
	}

	public class ContextConfiguration : DbConfiguration
	{
		public ContextConfiguration()
		{
			SetProviderServices("System.Data.SqlClient", SqlProviderServices.Instance);
		}
	}
}