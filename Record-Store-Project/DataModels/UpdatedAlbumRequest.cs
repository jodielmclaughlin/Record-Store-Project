using System.ComponentModel.DataAnnotations;

namespace Record_Store_Project.DataModels
{
    public class UpdatedAlbumRequest
    {
        public string Title { get; set; }
        [Required]
        public string Artist { get; set; }
        [Range(1900, 2100)]
        public int ReleaseYear { get; set; }
        [Required]
        public string Genre { get; set; }
        [Range(0, 100)]
        public int Stock { get; set; }
    }
}
