namespace Record_Store_Project.Repository
{
    public interface IAlbumModel
    {

    }
    public class AlbumModel : IAlbumModel
    {
        private AlbumDbContext _dbContext;

        public AlbumModel(AlbumDbContext db)
        {
            _dbContext = db;
        }


    }
}
