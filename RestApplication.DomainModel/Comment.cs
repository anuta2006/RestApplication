using System;
using System.ComponentModel.DataAnnotations;

namespace RestApplication.DomainModel
{
	public class Comment : Entity
	{
		[DataType(DataType.DateTime)]
		public DateTime? LastUpdatedDate { get; set; }

		[Required]
		public int? PostId { get; set; } 

		public Post Post { get; set; }
	}
}
