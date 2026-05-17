using Microsoft.AspNetCore.Mvc;
using Record_Store_Project.Service;
using Record_Store_Project.DataModels;

namespace Record_Store_Project.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlbumController : ControllerBase
    {
        private readonly IAlbumService _albumService;

        public AlbumController(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        [HttpGet("/health")]
        public IActionResult Health()
        {
            return Ok(new { status = "Healthy" });
        }

        [HttpGet]
        public IActionResult GetAllAlbums()
        {
            var albums = _albumService.GetAllAlbums();
            return Ok(albums);
        }

        [HttpGet("{id}")]
        public IActionResult GetAlbumById(int id) 
        {
            var albumId = _albumService.GetAlbumById(id);
            return Ok(albumId);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewAlbum(Album album)
        {
            var newAlbum = await _albumService.AddNewAlbum(album);
            return Created("", newAlbum);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAlbum(int id, UpdatedAlbumRequest request)
        {
            var updatedAlbum = await _albumService.UpdateAlbum(id, request);
            
            if (updatedAlbum == null)
            {
                return NotFound();
            }
            
            return Ok(request);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlbum(int id)
        {
            var deleteAlbum = await _albumService.DeleteAlbum(id);
            if (deleteAlbum == null)
            {
                return NotFound();
            }
            return Ok(deleteAlbum);
        }

        [HttpGet("artist/{artist}")]
        public async Task<IActionResult> GetAlbumsByArtist(string artist)
        {
            var albums = await _albumService.GetAlbumsByArtist(artist);

            if (!albums.Any())
            {
                return NotFound();
            }

            return Ok(albums);
        }
    }
}
