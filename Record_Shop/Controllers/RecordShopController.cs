using Microsoft.AspNetCore.Mvc;
using Record_Shop.Service;
using System.Net;

namespace Record_Shop.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class RecordShopController : Controller
    {
        private readonly IRecordShopService _recordShopService;

        public RecordShopController(IRecordShopService recordShopService)
        {
            _recordShopService = recordShopService;
        }
        [HttpGet]
        public IActionResult GetAlbums()
        {
            var tupledResult = _recordShopService.ConfirmAlbums();
            switch (tupledResult.Item1)
            {
                case (HttpStatusCode.OK):
                    return Ok(_recordShopService.ConfirmAlbums().Item2);
                case (HttpStatusCode.NoContent):
                    return NoContent();
                default:
                    return NotFound();
            }

        }
        [HttpGet("idSearch/{id}")]
        public IActionResult GetAlbumById(string id)
        {
            var tupledResult = _recordShopService.ConfirmIndividualAlbumById(id);
            switch (tupledResult.Item1)
            {
                case (HttpStatusCode.OK):
                    return Ok(tupledResult.Item2);
                case (HttpStatusCode.NoContent):
                    return NoContent();
                case (HttpStatusCode.BadRequest):
                    return BadRequest();
                default:
                    return NotFound();
            }
        }
        [HttpPost("AddAlbum")]
        public IActionResult PostAlbum(Album album)
        {
            var tupledResult = _recordShopService.ConfirmAdditionOfAlbum(album);
            switch (tupledResult.Item1)
            {
                case (HttpStatusCode.Accepted):
                    return Accepted((Album)tupledResult.Item2);
                case (HttpStatusCode.BadRequest):
                    return BadRequest((string)tupledResult.Item2);
                default: return NotFound();
            }
        }

    }
}
