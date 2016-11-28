using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Jober.Tests
{
    public class HomeCotrollerTests
    {
        Mock<Jober.Data.ICitiesRepository> citiesMock;
        Mock<Jober.Data.IJobsRepository> jobsMock;
        IMemoryCache memoryCacheMock;
        Mock<ILogger<Controllers.HomeController>> loggerMock;
        Controllers.HomeController homeController;
        List<string> keys;
        public HomeCotrollerTests()
        {
            citiesMock = new Mock<Data.ICitiesRepository>();
            citiesMock.Setup(x => x.GetAll()).Returns(new List<Models.City>());
            jobsMock = new Mock<Data.IJobsRepository>();
            jobsMock.Setup(x => x.GetAll()).Returns(new List<Models.Job>());
            jobsMock.Setup(x => x.Add(It.IsAny<Models.Job>()));
            keys = new List<string>();
            memoryCacheMock = new DummyCache(keys);
                      

            loggerMock = new Mock<ILogger<Controllers.HomeController>>();            

            homeController = new Controllers.HomeController(jobsMock.Object, citiesMock.Object, memoryCacheMock, loggerMock.Object);
        }

        [Fact]
        public void IndexTest()
        {
            homeController.Index(null, null);
            jobsMock.Verify(x => x.GetAll(), Times.Never);
            citiesMock.Verify(x => x.GetAll(), Times.Never);
            Assert.Equal(2, keys.Count);
            Assert.True(keys.Contains("Jobs"));
            Assert.True(keys.Contains("Cities"));
        }

        [Fact]
        public void CreateTest()
        {
            homeController.Create(new Models.Job());
            jobsMock.Verify(x => x.Add(It.IsAny<Models.Job>()), Times.Once);
        }
    }
}
