using System;
using System.Runtime.Serialization;

namespace RestApplication.DomainModel
{
	[DataContract]
	public class Comment : Entity
	{
		[DataMember(Name = "lastUpdatedDate")]
		public DateTime LastUpdatedDate { get; set; }

		[DataMember(Name = "postId")]
		public int? PostId { get; set; } 
		public Post Post { get; set; }
	}
}
