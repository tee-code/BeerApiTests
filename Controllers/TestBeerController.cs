using Beer.Controllers;
using Beer.Models;
using Beer.Services;
using BeerApiTests.MockData;
using Microsoft.AspNetCore.Mvc;
using Moq;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerApiTests.Controllers
{
    public class TestBeerController
    {
        private readonly Mock<IBeersApiService> _beerService;
        
       
        public TestBeerController()
        {
            _beerService = new Mock<IBeersApiService>();
            

        }

        // Test for Get all beers

        [Fact]
        public async Task GetAll_ShouldReturn200Status()
        {
            // Arrange 
            _beerService.Setup(x => x.GetBeers())
             .ReturnsAsync(BeerMockData.GetBeers());
            var _beerController = new BeerController(_beerService.Object);

            // Act
            var okResult = await _beerController.GetAll();
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult).StatusCode.Should().Be(200);
            
        }
        [Fact]
        public async Task GetAll_ShouldReturn204Status()
        {
            // Arrange 
            _beerService.Setup(x => x.GetBeers())
             .ReturnsAsync(BeerMockData.EmptyBeer());
            var _beerController = new BeerController(_beerService.Object);

            // Act
            var result = await _beerController.GetAll();
            // Assert
            result.GetType().Should().Be(typeof(NoContentResult));
            (result as NoContentResult).StatusCode.Should().Be(204);
        }

        // Test For SearchBeers
        [Fact]
        public async Task GetSearchedBeers_ShouldReturn200Status()
        {
            // Arrange 
            _beerService.Setup(x => x.GetBeers())
             .ReturnsAsync(BeerMockData.GetBeers());
            var _beerController = new BeerController(_beerService.Object);

            // Act
            var okResult = await _beerController.GetAll();
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult).StatusCode.Should().Be(200);

        }

        [Fact]
        public async Task GetSearchedBeers_ShouldReturn204Status()
        {
            // Arrange 
            _beerService.Setup(x => x.GetBeers())
             .ReturnsAsync(BeerMockData.EmptyBeer());
            var _beerController = new BeerController(_beerService.Object);

            // Act
            var result = await _beerController.GetAll();
            // Assert
            result.GetType().Should().Be(typeof(NoContentResult));
            (result as NoContentResult).StatusCode.Should().Be(204);
        }

        // Test for GetBearById

        [Fact]
        public async Task GetById_ShouldReturn200Status()
        {
            
            // Arrange 
            _beerService.Setup(x => x.GetBeers())
             .ReturnsAsync(BeerMockData.GetBeers());
            var _beerController = new BeerController(_beerService.Object);

            // Act
            var okResult = await _beerController.GetById(1);

            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult).StatusCode.Should().Be(200);

        }

       
        // Test for GetRadomBear

        [Fact]
        public async Task GetARandomBeer_ShouldReturn200Status()
        {

            // Arrange 
            _beerService.Setup(x => x.GetBeers())
             .ReturnsAsync(BeerMockData.GetBeers());
            var _beerController = new BeerController(_beerService.Object);

            // Act
            var okResult = await _beerController.GetARandomBeer();

            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult).StatusCode.Should().Be(200);

        }

    }
}
