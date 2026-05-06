using Record_Store_Project.Repository;

namespace Record_Store_Project.Service
{
    public interface IAlbumService
    {

    }
    public class AlbumService : IAlbumService
    {
        private readonly IAlbumModel _albumModel;

        public AlbumService(IAlbumModel albumModel)
        {
            _albumModel = albumModel;
        }


    }
}
