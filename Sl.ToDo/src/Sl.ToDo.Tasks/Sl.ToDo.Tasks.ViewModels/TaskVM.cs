using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sl.ToDo.Tasks.ViewModels
{
    public class TaskVM
    {
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Status { get; set; }
		public string FileId { get; set; }
	}
}
