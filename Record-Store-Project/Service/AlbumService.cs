using Record_Store_Project.Repository;
using Record_Store_Project.DataModels;


namespace Record_Store_Project.Service
{
    public interface IAlbumService
    {
        List<Album> GetAllAlbums();
        Album GetAlbumById(int id);
        Task<Album> AddNewAlbum(Album album);
        Task<Album> UpdateAlbum(int id, UpdatedAlbumRequest request);
        Task<Album> DeleteAlbum(int id);
        Task<List<Album>> GetAlbumsByArtist(string artist);
    }
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumModel _albumModel;

        public AlbumService(IAlbumModel albumModel)
        {
            _albumModel = albumModel;
        }

        public List<Album> GetAllAlbums()
        {
            return _albumModel.GetAllAlbums();
        }

        public Album GetAlbumById(int id)
        {
            return _albumModel.GetAlbumById(id);
        }

        public async Task<Album> AddNewAlbum(Album album)
        {
            return await _albumModel.AddNewAlbum(album);
        }

        public async Task<Album> UpdateAlbum(int id, UpdatedAlbumRequest request)
        {
            var album = new Album
            {
                Title = request.Title,
                Artist = request.Artist,
                ReleaseYear = request.ReleaseYear,
                Genre = request.Genre,
                Stock = request.Stock
            };

            return await _albumModel.UpdateAlbum(id, album);
        }

        public async Task<Album> DeleteAlbum(int id)
        {
            return await _albumModel.DeleteAlbum(id);
        }

        public async Task<List<Album>> GetAlbumsByArtist(string artist)
        {
            return await _albumModel.GetAlbumsByArtist(artist);
        }
    }
}
