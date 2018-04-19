using System;
using System.Runtime.Serialization;

namespace RestApplication.DomainModel
{
	[DataContract]
	public abstract class Entity
	{
		[DataMember(Name = "id")]
		public int Id { get; set; }

		[DataMember(Name = "content")]
		public string Content { get; set; }

		[DataMember(Name = "author")]
		public string Author { get; set; }

		[DataMember(Name = "publishedDate")]
		public DateTime PublishedDate { get; set; }
	}
}
