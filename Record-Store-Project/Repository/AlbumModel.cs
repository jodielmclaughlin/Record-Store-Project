using Record_Store_Project.DataModels;

namespace Record_Store_Project.Repository
{
    public interface IAlbumModel
    {
        List<Album> GetAllAlbums();
        Album GetAlbumById(int id);
        Task<Album> AddNewAlbum(Album album);
        Task<Album> UpdateAlbum(int id, Album album);
        Task<Album> DeleteAlbum(int id);
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
        public Album GetAlbumById(int id)
        {
            using (_dbContext)
            {
                return _dbContext.Albums.FirstOrDefault(x => x.AlbumId == id);
            }
        }

        public async Task<Album> AddNewAlbum(Album album)
        {
            await _dbContext.Albums.AddAsync(album);
            await _dbContext.SaveChangesAsync();

            return album;
        }

        public async Task<Album> UpdateAlbum (int id, Album album)
        {
            using (_dbContext)
            {
                var albumToUpdate = _dbContext.Albums.FirstOrDefault(a => a.AlbumId == id);

                if (albumToUpdate == null)
                {
                    return null;

                }

                albumToUpdate.Title = album.Title;
                albumToUpdate.Artist = album.Artist;
                albumToUpdate.ReleaseYear = album.ReleaseYear;
                albumToUpdate.Genre = album.Genre;
                albumToUpdate.Stock = album.Stock;
                await _dbContext.SaveChangesAsync();
                return albumToUpdate;

            }
        }
        public async Task<Album> DeleteAlbum (int id)
        {
           
            using (_dbContext)
            {
                var albumToDelete = _dbContext.Albums.FirstOrDefault(a => a.AlbumId == id);
                _dbContext.Albums.Remove(albumToDelete);

                await _dbContext.SaveChangesAsync();

                return albumToDelete;
            }
        }
    }
}
