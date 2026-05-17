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
            if (id <= 0)
            {
                return BadRequest(new ErrorResponse
                {
                    StatusCode = 400,
                    Message = "Invalid album ID."
                });
            }
            var albumId = _albumService.GetAlbumById(id);
            
            if (albumId == null)
            {
                return NotFound(new ErrorResponse
                {
                    StatusCode = 404,
                    Message = "Album not found."
                });
            }
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
            if (id <= 0)
            {
                return BadRequest(new ErrorResponse
                {
                    StatusCode = 400,
                    Message = "Invalid album ID."
                });
            }
            var deleteAlbum = await _albumService.DeleteAlbum(id);
            if (deleteAlbum == null)
            {
                return NotFound(new ErrorResponse
                {
                    StatusCode = 404,
                    Message = "Album not found."
                });
            }
            return Ok(deleteAlbum);
        }

        [HttpGet("artist/{artist}")]
        public async Task<IActionResult> GetAlbumsByArtist(string artist)
        {
            var albums = await _albumService.GetAlbumsByArtist(artist);

            if (!albums.Any())
            {
                return NotFound(new ErrorResponse
                {
                    StatusCode = 404,
                    Message = "Albums by this artist not found."
                });
            }

            return Ok(albums);
        }
        [HttpGet("year/{year}")]
        public async Task<IActionResult> GetAlbumsByYear(int year)
        {
            var albums = await _albumService.GetAlbumsByYear(year);

            if (!albums.Any())
            {
                return NotFound(new ErrorResponse
                {
                    StatusCode = 404,
                    Message = "Albums from this year not found."
                });
            }

            return Ok(albums);
        }
        [HttpGet("genre/{genre}")]
        public async Task<IActionResult> GetAlbumsByGenre(string genre)
        {
            var albums = await _albumService.GetAlbumsByGenre(genre);

            if (!albums.Any())
            {
                return NotFound(new ErrorResponse
                {
                    StatusCode = 404,
                    Message = "Albums in this genre not found."
                });
            }

            return Ok(albums);
        }
        [HttpGet("title/{title}")]
        public async Task<IActionResult> GetAlbumByTitle(string title)
        {
            var album = await _albumService.GetAlbumByTitle(title);

            if (album == null)
            {
                return NotFound(new ErrorResponse
                {
                    StatusCode = 404,
                    Message = "Album not found."
                });
            }

            return Ok(album);
        }
    }
}
