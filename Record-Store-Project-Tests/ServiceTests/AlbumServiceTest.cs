using Moq;
using Record_Store_Project.Repository;
using Record_Store_Project.Service;
using Record_Store_Project.DataModels;

namespace Record_Store_Project_Tests.ServiceTests;

public class AlbumServiceTest
{
    private AlbumService _albumService;
    private Mock<IAlbumModel> _albumModelMock;

    [SetUp]
    public void Setup()
    {
        _albumModelMock = new Mock<IAlbumModel>();
        _albumService = new AlbumService(_albumModelMock.Object );
    }

    [Test]
    public void GetAllAlbums_ShouldReturnListOfAlbumObjects()
    {
        var album = new Album { AlbumId  = 1, Title = "Taylor Swift", Artist = "Taylor Swift", ReleaseYear = 2006, Genre = "Country", Stock = 13};

        var albumList = new List<Album>();
        albumList.Add(album);
        _albumModelMock.Setup(model => model.GetAllAlbums()).Returns(albumList);

        var actual = _albumService.GetAllAlbums();

        Assert.That(actual, Is.EqualTo(albumList));
    }

    [Test]
    public void GetAlbumById_ShouldReturnAlbum_WhenGivenId()
    {
        var album = new Album { AlbumId = 1, Title = "Taylor Swift", Artist = "Taylor Swift", ReleaseYear = 2006, Genre = "Country", Stock = 13 };
        var albumList = new List<Album> { album };

        _albumModelMock.Setup(model => model.GetAlbumById(1)).Returns(album);


        var actual = _albumService.GetAlbumById(1);

        Assert.That(actual.AlbumId, Is.EqualTo(1));
    }
}
