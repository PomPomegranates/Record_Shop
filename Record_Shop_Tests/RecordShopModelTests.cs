using FluentAssertions;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Record_Shop;
using Record_Shop.Model;
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
        //_mockModel = new Mock<IRecordShopModel>();
        //_recordShopService = new RecordShopService(_mockModel.Object);
        //Album testAlbum = new Album();
        //testAlbum.Artist = "Test";
        //albumList.Add(testAlbum);
        private RecordShopDbContext testDbContext;
        private RecordShopModel recordShopModel;

        [SetUp]
        public void Setup()
        {
            var optionsBuilder = new DbContextOptionsBuilder<RecordShopDbContext>();
            optionsBuilder.UseInMemoryDatabase("MemoryDb");
            testDbContext = new RecordShopDbContext(optionsBuilder.Options);
            recordShopModel = new RecordShopModel(testDbContext);
        }

        [Test]
        public void TestIdIsFinding()
        {
            var test_album = recordShopModel.RetrieveAlbum(1);
            test_album.Artist.Should().Be("TEST");

        }

        [TearDown]
        public void Cleanup()
        {
            testDbContext.Dispose();
        }
    }
}