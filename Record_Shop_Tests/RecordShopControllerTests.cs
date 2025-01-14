using Record_Shop.Service;
using Moq;
using Record_Shop.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace Record_Shop_Tests;


public class RecordShopControllerTests
{
    private Mock<IRecordShopService> _mockService;
    private RecordShopController _recordShopController;

    [SetUp]
    public void Setup()
    {
        _mockService = new Mock<IRecordShopService>();
        _recordShopController = new RecordShopController(_mockService.Object);
    }
    [Test]
    public void TestTheCorrectIAction()
    {
        _mockService.Setup(service => service.ConfirmAlbums()).Returns((System.Net.HttpStatusCode.OK, null));
        var result = _recordShopController.GetAlbums();
        result.Should().BeOfType<OkObjectResult>();
    }
    [Test]
    public void TestTheIncorrectIAction()
    {
        _mockService.Setup(service => service.ConfirmAlbums()).Returns((System.Net.HttpStatusCode.NoContent, null));
        var result = _recordShopController.GetAlbums();
        result.Should().BeOfType<NoContentResult>();
    }
    [Test]
    public void TestTheDefaultIAction()
    {
        _mockService.Setup(service => service.ConfirmAlbums()).Returns((System.Net.HttpStatusCode.Ambiguous, null));
        var result = _recordShopController.GetAlbums();
        result.Should().BeOfType<NotFoundResult>();
    }
    [TearDown]
    public void Cleanup()
    {
        _recordShopController.Dispose();
    }
}
