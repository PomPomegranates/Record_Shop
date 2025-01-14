using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Record_Shop;
namespace Record_Shop_Tests
{
    public class RecordShopModelTests
    {
        private SqliteConnection _connection;

        [SetUp]
        public void Setup()
        {
            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();
            var _contextOptions = new DbContextOptionsBuilder<BloggingContext>()
            .UseSqlite(_connection)
            .Options;

        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [TearDown]
        public void Cleanup()
        {
            _connection.Dispose();
        }
    }
}