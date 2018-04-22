using RestApplication.DomainModel;
using RestApplication.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace RestApplication.Web.Controllers
{
    public class CommentsController : ApiController
    {
		private readonly ICrudService<Comment> _commentService;


		public CommentsController(ICrudService<Comment> commentService)
		{
			_commentService = commentService;
		}

		[HttpPost]
		[Route("api/comment")]
		public IHttpActionResult AddComment([FromBody]Comment comment)
		{
			_commentService.Create(comment);
			return Ok();
		}

		[HttpDelete]
		[Route("api/comment/{id}")]
		public async Task<IHttpActionResult> DeleteCommentAsync(int? id)
		{
			if (id == null)
			{
				return BadRequest();
			}
			await _commentService.DeleteAsync(id); 

			return Ok();
		}
	}
}
