using Moq;
using Record_Shop.Service;
using Record_Shop.Model;
using Record_Shop;
using Microsoft.AspNetCore.Mvc;
using Record_Shop.Controllers;
using Microsoft.Identity.Client;
using FluentAssertions;

namespace Record_Shop_Tests;


public class RecordShopServiceTests
{


    private Mock<IRecordShopModel> _mockModel;
    private RecordShopService _recordShopService;
    private List<Album> albumList = new List<Album>();

    [SetUp]
    public void Setup()
    {
        _mockModel = new Mock<IRecordShopModel>();
        _recordShopService = new RecordShopService(_mockModel.Object);
        Album testAlbum = new Album();
        testAlbum.Artist = "Test";
        albumList.Add(testAlbum);
        
    }


    [Test]
    public void TestThatReturnsOk()
    {
        _mockModel.Setup(model => model.RetrieveAlbums()).Returns(albumList);
        var result = _recordShopService.ConfirmAlbums();
        result.Item1.Should().Be(System.Net.HttpStatusCode.OK);

    }
    [Test]
    public void TestThatReturnsNoContent()
    {
        _mockModel.Setup(model => model.RetrieveAlbums()).Returns(new List<Album>());
        var result = _recordShopService.ConfirmAlbums();
        result.Item1.Should().Be(System.Net.HttpStatusCode.NoContent);

    }
}
