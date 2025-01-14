using Record_Shop.Model;

namespace Record_Shop.Service
{
    public interface IRecordShopService 
    {
        public List<Album> RetrieveAlbums();
    }
    public class RecordShopService : IRecordShopService
    {
        private readonly IRecordShopModel _recordShopModel;

        public RecordShopService(IRecordShopModel recordShopModel)
        {
            _recordShopModel = recordShopModel;
        }
        public List<Album> RetrieveAlbums()
        {
            return _recordShopModel.GetAlbums();
        }
    }
}
