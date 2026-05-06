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
                AlbumId = 1,
                Title = "Taylor Swift",
                Artist = "Taylor Swift",
                ReleaseYear = 2006,
                Genre = "Country",
                Stock = 13
            };

            _dbContext.Albums.Add(newAlbum);
            _dbContext.SaveChanges();

            var actual = album.GetAllAlbums();
            Assert.That(actual.Count, Is.EqualTo(1));
            Assert.That(actual[0].Title, Is.EqualTo("Taylor Swift"));
            Assert.That(actual[0].Artist, Is.EqualTo("Taylor Swift"));
        }
    }
}
