using Microsoft.AspNetCore.Mvc;
using Record_Shop.Service;

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
            return Ok(_recordShopService.RetrieveAlbums());
        }


    }
}
