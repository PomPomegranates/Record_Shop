using Microsoft.IdentityModel.Tokens;
using System.Text.Json;

namespace Record_Shop.Model
{
    public interface IRecordShopModel
    {
        public List<Album> RetrieveAlbums();
        public Album? RetrieveAlbum(int id);
        public void AddAlbum(Album album);
        public Album ModifyAlbum(int id, Album album);
    }
    public class RecordShopModel : IRecordShopModel
    {
        private RecordShopDbContext db { get; set; }
        public RecordShopModel(RecordShopDbContext context)
        {
            db = context;
        }
        private void CheckDatabase()
        {

            db.Database.EnsureCreated();
            
            if (db.Albums == null || db.Albums.ToList().Count == 0)
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };
                var list = JsonSerializer.Deserialize<List<Album>>(File.ReadAllText("Albums.json"), options)!;
                db.Albums.UpdateRange(list);
                db.SaveChanges();
                //try
                //{
                    
                //} catch (FileNotFoundException ex)
                //{
                //    return;
                //}
                
            }
                
            
        }

        public List<Album> RetrieveAlbums()
        {
            CheckDatabase();
            var list = db.Albums.ToList();
            return list;
            
        } 

        public Album? RetrieveAlbum(int id)
        {
            CheckDatabase();
            //return db.Albums.FirstOrDefault(x => x.Id == id, null);
            var query = db.Albums.Where(x => x.Id == id);
            if (!query.IsNullOrEmpty())
            {
                return query.First();
            }
            else
            {
                return null;
            }
        }

        //Should prepare to add functionality for checking album names against names in the database and only add if they're not already there. That will also require a search function for searching for albums, too. 

        public void AddAlbum(Album album)
        {
            CheckDatabase();
            db.Albums.Add(album);
            db.SaveChanges();
        }

        public Album ModifyAlbum(int id, Album album)
        {
            CheckDatabase();
            var changeableAlbum = RetrieveAlbum(id)!;
            
           
                if (!album.Title.IsNullOrEmpty())
                {
                    changeableAlbum.Title = album.Title;
                }
                if (!album.Artist.IsNullOrEmpty())
                {
                    changeableAlbum.Artist = album.Artist;
                }
                if (!album.Songs.IsNullOrEmpty())
                {
                foreach (Song song in album.Songs)
                {
                    if (!album.Songs.Contains(song))
                    {
                        changeableAlbum.Songs.Add(song);
                    }
                    
                }
                }

                db.SaveChanges();
            
            return RetrieveAlbum(album.Id)!;
            
            
        }

        
    }
}
