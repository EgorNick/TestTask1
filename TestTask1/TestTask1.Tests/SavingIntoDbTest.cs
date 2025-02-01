namespace TestTask1.Tests
{
    using System;
    using Moq;
    using Xunit;
    using TestTask1.Data;
    using TestTask1.Data.Entitys;
    using Microsoft.EntityFrameworkCore;
    using TestTask1.Models;

    public class SavingInfoTests
    {
        private Mock<AppDbContext> _mockContext;
        private SavingInfo _savingInfo;

        public SavingInfoTests()
        {
            _mockContext = new Mock<AppDbContext>(new DbContextOptions<AppDbContext>());
            _savingInfo = new SavingInfo(_mockContext.Object, _mockContext.Object);
        }

        [Fact]
        public void SaveInfoIntoDb_ValidData_ReturnsTrue()
        {
            var model1 = new CoordinateModel
            {
                X = 10,
                Y = 30,
                Time = DateTime.UtcNow
            };

            var model2 = new CoordinateModel
            {
                X = 20,
                Y = 40,
                Time = DateTime.UtcNow
            };
            
            var mockSet = new Mock<DbSet<CoordinateEntity>>();
            _mockContext.Setup(c => c.JsonData).Returns(mockSet.Object);
            
            var result1 = _savingInfo.SaveInfoIntoDb(model1);

            Assert.True(result1);
            mockSet.Verify(m => m.Add(It.IsAny<CoordinateEntity>()), Times.Once);
            _mockContext.Verify(m => m.SaveChanges(), Times.Once);
            
            _mockContext.Setup(c => c.SaveChanges()).Throws(new Exception("Error of db"));

            var result2 = _savingInfo.SaveInfoIntoDb(model2);
            Assert.False(result2);
        }
    }
}