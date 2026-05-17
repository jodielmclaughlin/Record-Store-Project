using Microsoft.EntityFrameworkCore;
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
        Task<List<Album>> GetAlbumsByArtist(string artist);
        Task<List<Album>> GetAlbumsByYear(int year);
        Task<List<Album>> GetAlbumsByGenre(string genre);
        Task<Album?> GetAlbumByTitle(string title);
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
        public async Task<List<Album>> GetAlbumsByArtist(string artist)
        {
            using (_dbContext)
            {
                return await _dbContext.Albums
                .Where(a => a.Artist.ToLower() == artist.ToLower())
                .ToListAsync();
            }
        }
        public async Task<List<Album>> GetAlbumsByYear(int year)
        {
            using (_dbContext)
            {
                return await _dbContext.Albums
                    .Where(a => a.ReleaseYear == year)
                    .ToListAsync();
            }
        }
        public async Task<List<Album>> GetAlbumsByGenre(string genre)
        {
            using (_dbContext)
            {
                return await _dbContext.Albums
                    .Where(a => a.Genre.ToLower() == genre.ToLower())
                    .ToListAsync();
            }
        }
        public async Task<Album?> GetAlbumByTitle(string title)
        {
            using (_dbContext)
            {
                return await _dbContext.Albums
                    .FirstOrDefaultAsync(a => a.Title.ToLower() == title.ToLower());
            }
        }

    }
}
