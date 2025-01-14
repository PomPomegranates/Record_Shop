using System.Text.Json;

namespace Record_Shop.Model
{
    public interface IRecordShopModel
    {
        public List<Album> GetAlbums();
    }
    public class RecordShopModel : IRecordShopModel
    {
        private void MakeDatabase()
        {
            using (var db = new RecordShopDbContext())
            {
                db.Database.EnsureCreated();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };

                db.Albums.UpdateRange(JsonSerializer.Deserialize<List<Album>>(File.ReadAllText("Albums.json"), options)!);
            }
        }

        public List<Album> GetAlbums()
        {
            MakeDatabase();
            using (var db = new RecordShopDbContext())
            {
                return db.Albums.ToList();
            }
        } 
    }
}
