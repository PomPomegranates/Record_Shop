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
                    return Ok(_recordShopService.ConfirmAlbums());
                case (HttpStatusCode.NoContent):
                    return NoContent();
                default:
                    return NotFound();
            }

        }
        [HttpGet("{id}")]
        public IActionResult GetAlbumById(id)
        {

        }


    }
}
