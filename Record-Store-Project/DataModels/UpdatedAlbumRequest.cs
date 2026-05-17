namespace Record_Store_Project.DataModels
{
    public class UpdatedAlbumRequest
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public int ReleaseYear { get; set; }
        public string Genre { get; set; }
        public int Stock { get; set; }
    }
}
