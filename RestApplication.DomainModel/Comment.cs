using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace RestApplication.DomainModel
{
	[DataContract]
	public class Comment : Entity
	{
		[DataMember(Name = "lastUpdatedDate")]
		[DataType(DataType.DateTime)]
		public DateTime LastUpdatedDate { get; set; }

		[DataMember(Name = "postId")]
		public int? PostId { get; set; } 

		public Post Post { get; set; }
	}
}
