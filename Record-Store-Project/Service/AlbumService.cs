using Record_Store_Project.Repository;
using Record_Store_Project.DataModels;
using Record_Store_Project.Repository;

namespace Record_Store_Project.Service
{
    public interface IAlbumService
    {
        List<Album> GetAllAlbums();
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
    }
}
