namespace Sl.ToDo.Tasks.Entities
{
	public enum TaskStatus
	{
		None = 0x0, // Fallback for database default value
		Incompleted = 1 << 0,
		Completed = 1 << 1,
		InProcess = 1 << 2
	}
}