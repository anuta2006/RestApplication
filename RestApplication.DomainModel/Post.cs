using System.Collections.Generic;

namespace RestApplication.DomainModel
{
	public class Post : Entity
    {
		public virtual ICollection<Comment> Comments { get; set; }
    }
}
