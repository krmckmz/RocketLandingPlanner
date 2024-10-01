using Moq;
using Xunit;
using RocketLandingPlanner.Business.Enums;
using RocketLandingPlanner.Business.Services.RocketLanding.Concrete;
using RocketLandingPlanner.Data.Entities.RocketLanding;
using RocketLandingPlanner.Data.Repositories.RocketLanding.Abstract;
using System.Linq.Expressions;

public class RocketLandingServiceTests
{
    private readonly Mock<IRocketLandingRepository> _rocketLandingRepositoryMock;
    private readonly RocketLandingService _rocketLandingService;

    public RocketLandingServiceTests()
    {
        _rocketLandingRepositoryMock = new Mock<IRocketLandingRepository>();
        _rocketLandingService = new RocketLandingService(_rocketLandingRepositoryMock.Object);
    }

    [Fact]
    public async Task CanRocketLand_Returns_OutOfPlatform_When_Outside_Boundaries()
    {
        int horizontalIndex = -1;
        int verticalIndex = 0;

        var result = await _rocketLandingService.CanRocketLand(horizontalIndex, verticalIndex);

        Assert.False(result.IsSuccess);
        Assert.Equal(RocketLandingResponseType.OutOfPlatform, result.ResponseType);
    }

    [Fact]
    public async Task CanRocketLand_Returns_Crash_When_Other_Rocket_Already_Landed()
    {
        int horizontalIndex = 5;
        int verticalIndex = 5;

        _rocketLandingRepositoryMock.Setup(repo => repo.GetItemAsync(It.IsAny<Expression<Func<RocketLanding, bool>>>()))
            .ReturnsAsync(new RocketLanding { HorizontalIndex = 5, VerticalIndex = 5 });

        var result = await _rocketLandingService.CanRocketLand(horizontalIndex, verticalIndex);

        Assert.False(result.IsSuccess);
        Assert.Equal(RocketLandingResponseType.Crash, result.ResponseType);
    }

    [Fact]
    public async Task CanRocketLand_Returns_SuitableToLand_When_No_Collision()
    {
        int horizontalIndex = 5;
        int verticalIndex = 5;

        _rocketLandingRepositoryMock.Setup(repo => repo.GetItemAsync(It.IsAny<Expression<Func<RocketLanding, bool>>>()))
            .ReturnsAsync((RocketLanding)null); 

        var result = await _rocketLandingService.CanRocketLand(horizontalIndex, verticalIndex);

        Assert.True(result.IsSuccess);
        Assert.Equal(RocketLandingResponseType.SuitableToLand, result.ResponseType);
    }
}
