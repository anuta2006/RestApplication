using RestApplication.DomainModel;
using RestApplication.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace RestApplication.Web.Controllers
{
	public class PostsController : ApiController
    {
		private readonly ICrudService<Post> _postService;

		public PostsController(ICrudService<Post> postService)
		{
			_postService = postService;
		}

		// GET: api/Posts
		[Route("api/posts")]
		public IEnumerable<Post> GetPosts()
		{
			return _postService.GetAll();
		}

		// GET: api/Posts/5
		[ResponseType(typeof(Post))]
		[Route("api/post/{id}")]
		public async Task<IHttpActionResult> GetPostAsync(int? id)
		{
			if (id == null)
			{
				return BadRequest();
			}
			Post post = await _postService.GetAsync(id);
			if (post == null)
			{
				return NotFound();
			}

			return Ok(post);
		}

		[HttpPost]
		[Route("api/post")]
		public IHttpActionResult AddPost([FromBody]Post post)
		{
			_postService.Create(post);
			return Ok();
		}
    }
}
