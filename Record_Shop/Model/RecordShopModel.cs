using System.Text.Json;

namespace Record_Shop.Model
{
    public interface IRecordShopModel
    {
        public List<Album> RetrieveAlbums();
    }
    public class RecordShopModel : IRecordShopModel
    {
        private RecordShopDbContext db { get; set; }
        public RecordShopModel(RecordShopDbContext context)
        {
            db = context;
        }
        private void MakeDatabase()
        {

            db.Database.EnsureCreated();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };

                db.Albums.UpdateRange(JsonSerializer.Deserialize<List<Album>>(File.ReadAllText("Albums.json"), options)!);
                db.SaveChanges();
            
        }

        public List<Album> RetrieveAlbums()
        {
            MakeDatabase();

                return db.Albums.ToList();
            
        } 
    }
}
