using Microsoft.EntityFrameworkCore;

namespace APOD.Models
{
	public class CommentModel
	{
		
		public int Id { get; set; }
		public string Author { get; set; }
		public string Password { get; set; }
		public string Contents { get; set; }
		public DateTime Date { get; set; }
		public int PostId { get; set; }

	}
}
