using Microsoft.AspNetCore.Mvc;
using Moq;
using Record_Store_Project;
using Record_Store_Project.Controllers;
using Record_Store_Project.Service;
using Record_Store_Project.DataModels;
namespace Record_Store_Project_Tests.ControllerTests
{
    public class AlbumControllerTests
    {
        private AlbumController _albumController;
        private Mock<IAlbumService> _albumServiceMock;

        [SetUp]
        public void Setup()
        {
            _albumServiceMock = new Mock<IAlbumService>();
            _albumController = new AlbumController(_albumServiceMock.Object);
        }

        [Test]
        public void GetAllAlbums_ShouldReturnStatusCode200()
        {
            var album = new Album { AlbumId = 1, Title = "Taylor Swift", Artist = "Taylor Swift", ReleaseYear = 2006, Genre = "Country", Stock = 13 };

            var albumList = new List<Album> { album };

            _albumServiceMock.Setup(serv => serv.GetAllAlbums()).Returns(albumList);

            var actual = (OkObjectResult)_albumController.GetAllAlbums();

            Assert.That(actual.StatusCode, Is.EqualTo(200));
        }
    }
}