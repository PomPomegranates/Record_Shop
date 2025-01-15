using Microsoft.AspNetCore.Mvc;
using Record_Shop.Model;
using System.Net;

namespace Record_Shop.Service
{
    public interface IRecordShopService 
    {
        public (HttpStatusCode, List<Album>) ConfirmAlbums();
        public (HttpStatusCode, Album?) ConfirmIndividualAlbumById(string id);
        public (HttpStatusCode, object) ConfirmAdditionOfAlbum(Album album);
        public (HttpStatusCode, object) ConfirmUpdateAlbum(string id, Album album);
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

        public (HttpStatusCode, Album?) ConfirmIndividualAlbumById(string id)
        {
            if(!int.TryParse(id, out var albumId))
            {
                return (HttpStatusCode.UnprocessableEntity, null);
            } 

            var album = _recordShopModel.RetrieveAlbum(albumId);
            if (album != null)
            {
                return (HttpStatusCode.OK, album);
            }
            else
            {
                return (HttpStatusCode.NoContent, album);
            }
            
        }
        public (HttpStatusCode, object) ConfirmAdditionOfAlbum(Album album)
        {

            if (album.Artist == null)
            {
                return (HttpStatusCode.UnprocessableEntity,  $"Request Denied, because you provided no artist");
            }
            if (album.Title == null)
            {
                return (HttpStatusCode.UnprocessableEntity, $"Request Denied, because you provided no title");
            }
            if (album.Songs == null || album.Songs.Count == 0)
            {
                return (HttpStatusCode.UnprocessableEntity, "Request Denied, because you provided no songs");
            }
            for (int i = 0; i<album.Songs.Count; i++ )
            {
                album.Songs[i].id = 0;
                if (album.Songs[i].title == null)
                {
                    return (HttpStatusCode.UnprocessableEntity, $"Request Denied, because the song provided at position {i} has no title. Please ensure all songs are given proper titles.");
                }
                if (album.Songs[i].length == 0)
                {
                    return (HttpStatusCode.UnprocessableEntity,  $"Request Denied, because the song provided at position {i} has no length. Please ensure all songs have song lengths provided.");
                }
        
            }

            _recordShopModel.AddAlbum(album);
            return (HttpStatusCode.Accepted, album);
            
        }
        public (HttpStatusCode, object) ConfirmUpdateAlbum(string id, Album album)
        {
            if (ConfirmIndividualAlbumById(id).Item2 == null) return (HttpStatusCode.NotFound, $"No Item exists for Album ID:{id}");
            else return (HttpStatusCode.Accepted, _recordShopModel.ModifyAlbum(int.Parse(id), album));

        }
    }
}
