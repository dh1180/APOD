using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace APOD.Models
{
	public class CommentModel
	{
		
		public int Id { get; set; }
		public string Author { get; set; }
		public string Password { get; set; }
		public string Contents { get; set; }
		public DateTime Date { get; set; }
		
		[ForeignKey("APODModel")]
		public int PostId { get; set; }
		public virtual APODModel APODModel { get; set; }
	}
}
