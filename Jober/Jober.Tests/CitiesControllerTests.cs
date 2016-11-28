using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Jober.Tests
{
    public class CitiesControllerTests
    {
        Jober.Controllers.CitiesController citiesController;
        Mock<Jober.Data.ICitiesRepository> citiesMock;

        public CitiesControllerTests()
        {
            citiesMock = new Mock<Data.ICitiesRepository>();
            citiesMock.Setup(x => x.GetAll()).Returns(new List<Models.City>());
            citiesMock.Setup(x => x.Add(It.IsAny<Models.City>()));
            citiesController = new Controllers.CitiesController(citiesMock.Object);
        }

        [Fact]
        public void IndexTest()
        {
            citiesController.Index();
            citiesMock.Verify(x => x.GetAll(), Times.Once);
        }

        [Fact]
        public void CreateTest()
        {
            citiesController.Create(new Models.City());
            citiesMock.Verify(x => x.Add(It.IsAny<Models.City>()), Times.Once);
        }
    }
}
