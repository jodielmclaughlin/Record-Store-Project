using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Record_Store_Project;
using Record_Store_Project.DataModels;
using Record_Store_Project.Repository;

namespace Record_Store_Project_Tests;

public class AlbumModelTest
{
    private AlbumModel _albumModel;
    private AlbumDbContext _dbContext;
    
    [SetUp]
    public void Setup()
    {
        using (_dbContext)
        {
            var options = new DbContextOptionsBuilder<AlbumDbContext>()
           .UseInMemoryDatabase("TestDb")
           .Options;

            _dbContext = new AlbumDbContext(options);
            _albumModel = new AlbumModel(_dbContext);
        }
    }

    [Test]
    public void GetAllAlbums_ShouldReturnListOfAllAlbums()
    {

        using (_dbContext)
        {
            AlbumModel album = new AlbumModel(_dbContext);

            var newAlbum = new Album
            {
                Title = "Fearless",
                Artist = "Taylor Swift",
                ReleaseYear = 2008,
                Genre = "Country",
                Stock = 15
            };

            _dbContext.Albums.Add(newAlbum);
            _dbContext.SaveChanges();

            var actual = album.GetAllAlbums();
            Assert.That(actual[0].Genre, Is.EqualTo("Country"));
            Assert.That(actual[0].Artist, Is.EqualTo("Taylor Swift"));
        }

    }
    [Test]
    public void GetAlbumById_ShouldReturnAlbum_WhenGivenId()
    {
        using (_dbContext)
        {
            AlbumModel album = new AlbumModel(_dbContext);

            var newAlbum = new Album
            {
                
                Title = "Taylor Swift",
                Artist = "Taylor Swift",
                ReleaseYear = 2006,
                Genre = "Country",
                Stock = 13
            };

            _dbContext.Albums.Add(newAlbum);
            _dbContext.SaveChanges();

            var actual = album.GetAlbumById(1);
            Assert.That(actual.AlbumId, Is.EqualTo(1));
        }
    }
    [Test]
    public void AddNewAlbum_ShouldReturnAlbum_WhenPostingNewAlbum()
    {
        using (_dbContext)
        {
            AlbumModel album = new AlbumModel(_dbContext);

            var newAlbum = new Album
            {
                Title = "Speak Now",
                Artist = "Taylor Swift",
                ReleaseYear = 2010,
                Genre = "Country",
                Stock = 13
            };

            _dbContext.Albums.Add(newAlbum);
            _dbContext.SaveChanges();

            var actual = album.AddNewAlbum(newAlbum);
            Assert.That(actual, Is.EqualTo(newAlbum));
        }
    }
}
