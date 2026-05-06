using Record_Store_Project.DataModels;

namespace Record_Store_Project.Repository
{
    public interface IAlbumModel
    {
        List<Album> GetAllAlbums();
    }
    public class AlbumModel : IAlbumModel
    {
        private AlbumDbContext _dbContext;

        public AlbumModel(AlbumDbContext db)
        {
            _dbContext = db;
        }

        public List<Album> GetAllAlbums()
        {
            using (_dbContext)
            {
                return _dbContext.Albums.ToList();
            }
        }
    }
}
