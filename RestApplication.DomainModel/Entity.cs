using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestApplication.DomainModel
{
	public abstract class Entity
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		[DataType(DataType.MultilineText)]
		[Required(ErrorMessage = "Content cannot be empty")]
		[StringLength(1000, ErrorMessage = "Content length cannot be more than 1000 symbols")]
		public string Content { get; set; }

		[Required(ErrorMessage = "Author field must be set")]
		[StringLength(10, MinimumLength = 3, ErrorMessage = "Author name length should be between 3 and 10 symbols")]
		public string Author { get; set; }

		[DataType(DataType.DateTime)]
		public DateTime? PublishedDate { get; set; }
	}
}
