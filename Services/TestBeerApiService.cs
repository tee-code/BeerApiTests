using Beer.Controllers;
using Beer.Models;
using Beer.Services;
using BeerApiTests.MockData;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerApiTests.Services
{
    public class TestBeerApiService
    {

        private readonly Mock<IBeersApiService> _beerService;
        

        public TestBeerApiService()
        {
            _beerService = new Mock<IBeersApiService>();
           
        }

        // Test for Get all beers
        [Fact]
        public async Task GetAll_WhenCalled_ReturnsAllBeers()
        {
            //arrange
            var beerList = BeerMockData.GetBeers();

            _beerService.Setup(x => x.GetBeers())
                .ReturnsAsync(BeerMockData.GetBeers());

            var _beerController = new BeerController(_beerService.Object);

            //act
            IActionResult actionResult = await _beerController.GetAll();
            
            OkObjectResult okResult = actionResult as OkObjectResult;

            var beerResult = okResult.Value as List<BeerModel>;

            //assert
            Assert.NotNull(okResult);
            
            Assert.NotNull(beerResult);
            Assert.Equal(beerList.Count(), beerResult.Count());
        }

        // Test for GetBeerById
        [Fact]
        public async Task GetById_WhenCalled_ReturnsABeerWithTheId()
        {

            //arrange
            var beerList = BeerMockData.GetBeers();

            _beerService.Setup(x => x.GetBeerById(1))
                .ReturnsAsync(BeerMockData.GetBeers()[1]);

            var _beerController = new BeerController(_beerService.Object);

            //act
            IActionResult actionResult = await _beerController.GetById(1);

            OkObjectResult okResult = actionResult as OkObjectResult;

            var beerResult = okResult.Value as BeerModel;

            //assert
            Assert.NotNull(okResult);

            Assert.Equal(beerList[1].Id, beerResult.Id);
            Assert.True(beerList[1].Id == beerResult.Id);

        }

        // Test for GetRandomBeer
        [Fact]
        public async Task GetById_WhenCalled_ReturnsARandomBeer()
        {

            //arrange
            var beerList = BeerMockData.GetBeers();

            _beerService.Setup(x => x.GetRandomBeer())
                .ReturnsAsync(BeerMockData.RandomBeer());

            var _beerController = new BeerController(_beerService.Object);

            //act
            IActionResult actionResult = await _beerController.GetARandomBeer();

            OkObjectResult okResult = actionResult as OkObjectResult;

            var beerResult = okResult.Value as BeerModel;

            var randomBeer = (beerList?.Any(e => e.Id == beerResult.Id));

            //assert
            Assert.NotNull(okResult);

            Assert.Equal(randomBeer, true);

        }
    }
}
