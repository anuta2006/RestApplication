using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestApplication;
using RestApplication.Web.Controllers;
using Moq;
using RestApplication.Services.Interfaces;
using RestApplication.DomainModel;
using System;
using System.Web.Http;
using System.Web.Http.Results;
using System.Threading.Tasks;

namespace RestApplication.Tests.Controllers
{
	[TestClass]
	public class PostsControllerTests
	{
		private Mock<ICrudService<Post>> _mockPostService;
		private PostsController _postsController;

		[TestInitialize]
		public void Init()
		{
			_mockPostService = new Mock<ICrudService<Post>>();
		}

		#region GetPostAsync(id)
		[TestMethod]
		public async Task PostsController_WhenGetPost_ReturnsOk()
		{
			// Arrange
			_mockPostService.Setup(x => x.GetAsync(It.IsAny<int>())).ReturnsAsync(new Post { Id = 1, Author = "hanna", Content = "test", PublishedDate = DateTime.Now });
			_postsController = new PostsController(_mockPostService.Object);

			// Act
			IHttpActionResult result = await _postsController.GetPostAsync(42);
			var contentResult = result as OkNegotiatedContentResult<Post>;

			// Assert
			Assert.IsNotNull(result);
			Assert.IsNotNull(contentResult.Content);
			Assert.AreEqual("hanna", contentResult.Content.Author);
		}

		[TestMethod]
		public async Task PostsController_WhenGetPostWithNullId_ReturnsBadRequest()
		{
			// Arrange
			_postsController = new PostsController(_mockPostService.Object);

			// Act
			IHttpActionResult result = await _postsController.GetPostAsync(null);

			// Assert
			Assert.IsInstanceOfType(result, typeof(BadRequestResult));
		}

		[TestMethod]
		public async Task PostsController_WhenGetPostWithId_ReturnsNotFound()
		{
			// Arrange
			_postsController = new PostsController(_mockPostService.Object);

			// Act
			IHttpActionResult result = await _postsController.GetPostAsync(20);

			// Assert
			Assert.IsInstanceOfType(result, typeof(NotFoundResult));
		}
		#endregion

		[TestMethod]
		public void PostsController_AddPost_ReturnsOk()
		{
			// Arrange
			_postsController = new PostsController(_mockPostService.Object);
			Post post = new Post { Author = "hanna", Content = "test" };

			// Act
			IHttpActionResult result = _postsController.AddPost(post);

			// Assert
			_mockPostService.Verify(x => x.Create(It.IsAny<Post>()), Times.Once);
			Assert.IsInstanceOfType(result, typeof(OkResult));
		}
	}
}
