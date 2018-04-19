using System.Collections.Generic;

namespace RestApplication.DomainModel
{
	public class Post : Entity
    {
		public ICollection<Comment> Comments { get; set; }
		//public Post()
		//{
		//	Comments = new List<Comment>();
		//}
    }
}
