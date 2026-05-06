using Microsoft.AspNetCore.Mvc;
using Record_Store_Project.Service;

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
    }
}
