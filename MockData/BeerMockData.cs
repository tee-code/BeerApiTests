using Beer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerApiTests.MockData
{
    public class BeerMockData
    {
        public static List<BeerModel> GetBeers()
        {
            return new List<BeerModel>
            {
                new()
                {
                    Id = 0,
                    Name = "string",
                    Tagline = "string",
                    Description = "string"


                },
                new()
                {
                    Id = 1,
                    Name = "string 2",
                    Tagline = "string",
                    Description = "string"


                },
                new()
                {
                    Id = 2,
                    Name = "string",
                    Tagline = "string",
                    Description = "string"


                },

            };
        }

        public static List<BeerModel> EmptyBeer()
        {
            return new List<BeerModel>();
            
        }

        public static BeerModel RandomBeer()
        {
            Random random = new Random();
            int Id = random.Next(0, 3);

            var beers = GetBeers();

            return beers[Id];

        }

        public static List<BeerModel> GetSearchedBeers()
        {
            return new List<BeerModel>
            {
                new()
                {
                    Id = 0,
                    Name = "search for me",
                    Tagline = "string",
                    Description = "string"


                },
                new()
                {
                    Id = 1,
                    Name = "search for me",
                    Tagline = "string",
                    Description = "string"


                }

            };
        }

       
    }
}
                       