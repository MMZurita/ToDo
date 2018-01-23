namespace Sl.ToDo.Tasks.Entities
{
	public class Task
	{
		public Task(string name, string description, string fileId)
		{
			Name = name;
			Description = description;
			FileId = fileId;
		}

		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string FileId { get; set; }
		public TaskStatus Status { get; set; }

		public static Task Create(string name, string description, string fileId)
		{
			return new Task(name, description, fileId);
		}
	}
}