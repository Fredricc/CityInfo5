using CityInfo.API.Models;

namespace CityInfo.API
{
    public class CitiesDataStore
    {
        public List<CityDto> Cities { get; set; }

        //public static CitiesDataStore Current { get; } = new CitiesDataStore();

        public CitiesDataStore()
        {
            Cities = new List<CityDto>()
            {
                new CityDto()
                {
                    Id = 1,
                    Name = "New York City",
                    Description = "The one with that big park.",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto ()
                        {
                            Id = 1,
                            Name = "Eiffel Tower",
                            Description = "A wrought iron lattice tower on the middle of Manhattan."
                        },
                        new PointOfInterestDto()
                        {
                            Id = 2,
                            Name = "The Louvre",
                            Description = "The world's largest museum."
                        },
                    }
                },
                new CityDto()
                {
                    Id = 2,
                    Name = "Antwerp",
                    Description = "The city with the cathedral that was never really finished.",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 3,
                            Name = "Eiffel Tower",
                            Description = "A wrought iron lattice tower on the middle of Manhattan."
                        },
                        new PointOfInterestDto()
                        {
                            Id = 4,
                            Name = "The Louvre",
                            Description = "The world's largest museum."
                        },
                    }
                },
                new CityDto()
                {
                    Id = 3,
                    Name = "Thika",
                    Description = "Kiambu county first city.",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 5,
                            Name = "Kirigiti Stadium",
                            Description = "Kenya's newest world class international stadium."
                        },
                        new PointOfInterestDto()
                        {
                            Id = 6,
                            Name = "The Louvre",
                            Description = "The world's largest museum."
                        }
                    }
                },
                new CityDto()
                {
                    Id = 4,
                    Name = "Nairobi",
                    Description = "The City with the best roads in East Africa.",
                    PointsOfInterest = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id = 7,
                            Name = "GTC",
                            Description = "A 42 story building located in Westlands along the Waiyaki highway."
                        },
                        new PointOfInterestDto()
                        {
                            Id = 8,
                            Name = "Fugo Gaucco",
                            Description = "A Italian steak restaurant located in Westlands ."
                        }

                }
            }
            };
        }
    }
}
