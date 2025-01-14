using Microsoft.AspNetCore.Mvc;
using Record_Shop.Model;
using System.Net;

namespace Record_Shop.Service
{
    public interface IRecordShopService 
    {
        public (HttpStatusCode, List<Album>) ConfirmAlbums();
    }
    public class RecordShopService : IRecordShopService
    {
        private readonly IRecordShopModel _recordShopModel;

        public RecordShopService(IRecordShopModel recordShopModel)
        {
            _recordShopModel = recordShopModel;
        }
        public (HttpStatusCode, List<Album>) ConfirmAlbums()
        {
            var albums = _recordShopModel.RetrieveAlbums();
            if (albums.Count == 0)
            {
                return (HttpStatusCode.NoContent, albums);
            }
            return (HttpStatusCode.OK, albums);
        }
    }
}
