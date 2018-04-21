using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace RestApplication.DomainModel
{
	[DataContract]
	public abstract class Entity
	{
		[DataMember(Name = "id")]
		public int Id { get; set; }

		[DataMember(Name = "content")]
		[DataType(DataType.MultilineText)]
		[Required(ErrorMessage = "Content cannot be empty")]
		[StringLength(1000, ErrorMessage = "Content length cannot be more than 1000 symbols")]
		public string Content { get; set; }

		[DataMember(Name = "author")]
		[Required(ErrorMessage = "Author field must be set")]
		[StringLength(10, MinimumLength = 3, ErrorMessage = "Author name length should be between 3 and 10 symbols")]
		public string Author { get; set; }

		[DataMember(Name = "publishedDate")]
		[DataType(DataType.DateTime)]
		public DateTime PublishedDate { get; set; }
	}
}
