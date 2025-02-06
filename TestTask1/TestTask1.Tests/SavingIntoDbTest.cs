using TestTask1.Core.Entitys;
using TestTask1.Services;

namespace TestTask1.Tests
{
    using System;
    using Moq;
    using Xunit;
    using TestTask1.Core.Entitys;

    public class SavingInfoTests
    {
        private readonly Mock<ICoordinateSaving> _mockContext;
        private readonly CoordinateService _coordinateService;

        public SavingInfoTests()
        {
            _mockContext = new Mock<ICoordinateSaving>();
            _coordinateService = new CoordinateService(_mockContext.Object);
        }

        [Fact]
        public async Task SaveInfoIntoDb_ValidData_ReturnsTrue()
        {
            var coordinate = new Coordinate {X = 0, Y = 0, Time = DateTime.UtcNow};
            _mockContext.Setup(x => x.SaveAsync(coordinate)).ReturnsAsync(true);
            var result = await _coordinateService.SaveCoordinateAsync(coordinate);
            Assert.True(result);
        }

        [Fact]
        public async Task SaveInfoIntoDb_ValidData_ReturnsFalse()
        {
            var coordinate = new Coordinate {X = 0, Y = 0, Time = DateTime.UtcNow};
            _mockContext.Setup(x => x.SaveAsync(coordinate)).ReturnsAsync(false);
            var result = await _coordinateService.SaveCoordinateAsync(coordinate);
            Assert.False(result);
        }
    }
}