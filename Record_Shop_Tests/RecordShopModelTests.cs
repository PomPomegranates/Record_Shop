using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Record_Shop;
namespace Record_Shop_Tests
{
    public class RecordShopModelTests
    {
        //private SqliteConnection _connection;
        //_connection = new SqliteConnection("Filename=:memory:");
        //_connection.Open();
        //    var _contextOptions = new DbContextOptionsBuilder<RecordShopDbContext>()
        //    .UseSqlite(_connection)
        //    .Options;
        //      _connection.Dispose();


        [SetUp]
        public void Setup()
        {
          
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [TearDown]
        public void Cleanup()
        {
            
        }
    }
}