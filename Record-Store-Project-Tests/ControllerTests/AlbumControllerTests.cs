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
            var album = new Album { Title = "Taylor Swift", Artist = "Taylor Swift", ReleaseYear = 2006, Genre = "Country", Stock = 13 };

            var albumList = new List<Album> { album };

            _albumServiceMock.Setup(serv => serv.GetAllAlbums()).Returns(albumList);

            var actual = (OkObjectResult)_albumController.GetAllAlbums();

            Assert.That(actual.StatusCode, Is.EqualTo(200));
        }

        [Test]
        public void GetAlbumById_SShouldReturnStatusCode200_WhenGivenId()
        {
            var album = new Album { Title = "Taylor Swift", Artist = "Taylor Swift", ReleaseYear = 2006, Genre = "Country", Stock = 13 };

            var albumList = new List<Album> { album };

            _albumServiceMock.Setup(serv => serv.GetAlbumById(1)).Returns(album);

            var actual = (OkObjectResult)_albumController.GetAlbumById(1);

            Assert.That(actual.StatusCode, Is.EqualTo(200));
        }

        [Test]
        public void AddNewAlbum_ShouldReturnStatusCode201_WhenPostingNewAlbum()
        {
            var album = new Album { Title = "Speak Now", Artist = "Taylor Swift", ReleaseYear = 2010, Genre = "Country", Stock = 13 };

            _albumServiceMock.Setup(serv => serv.AddNewAlbum(album)).Returns(album);

            var actual = (CreatedResult)_albumController.AddNewAlbum(album);

            Assert.That(actual.StatusCode, Is.EqualTo(201));

        }
        [Test]
        public void UpdateAlbum_ReturnsOk_WhenAlbumUpdated()
        {
            var request = new UpdatedAlbumRequest
            {
                
                Title = "Speak Now",
                Artist = "Taylor Swift",
                ReleaseYear = 2010,
                Genre = "Pop",
                Stock = 13
            };

            var updatedAlbum = new Album
            {
                
                Title = request.Title,
                Artist = request.Artist,
                ReleaseYear = request.ReleaseYear,
                Genre = request.Genre,
                Stock = request.Stock
            };

            _albumServiceMock.Setup(serv => serv.UpdateAlbum(3, request)).Returns(updatedAlbum);


            var actual = (OkObjectResult)_albumController.UpdateAlbum(3, request);

            Assert.That(actual.StatusCode, Is.EqualTo(200));
        }
        [Test]
        public void UpdateAlbum_ReturnsNotFound_WhenAlbumDoesNotExist()
        {
            var request = new UpdatedAlbumRequest();

            _albumServiceMock.Setup(serv => serv.UpdateAlbum(99, request)).Returns((Album)null);

            var actual = (NotFoundResult)_albumController.UpdateAlbum(99, request);

            Assert.That(actual.StatusCode, Is.EqualTo(404));
        }

    }
}