using Moq;
using Xunit;
using RocketLandingPlanner.Business.Enums;
using RocketLandingPlanner.Business.Services.RocketLanding.Concrete;
using RocketLandingPlanner.Data.Entities.RocketLanding;
using RocketLandingPlanner.Data.Repositories.RocketLanding.Abstract;
using System.Linq.Expressions;
using RocketLandingPlanner.Data.Contexts.Mongo.Concrete;

public class RocketLandingServiceTests
{
    private readonly Mock<IRocketLandingRepository> _rocketLandingRepositoryMock;
    private readonly RocketLandingService _rocketLandingService;
    private readonly MongoDBSettings _mongoDBSettings = null;

    public RocketLandingServiceTests(MongoDBSettings mongoDBSettings)
    {
        _rocketLandingRepositoryMock = new Mock<IRocketLandingRepository>();
        _mongoDBSettings = mongoDBSettings;
        _rocketLandingService = new RocketLandingService(_rocketLandingRepositoryMock.Object, _mongoDBSettings);
    }

    [Fact]
    public async Task CanRocketLand_Returns_OutOfPlatform_When_Outside_Boundaries()
    {
        int horizontalIndex = -1;
        int verticalIndex = 0;
        int userId = 103452;

        var result = await _rocketLandingService.CanRocketLand(horizontalIndex, verticalIndex, userId);

        Assert.False(result.IsSuccess);
        Assert.Equal(RocketLandingResponseType.OutOfPlatform, result.ResponseType);
    }

    [Fact]
    public async Task CanRocketLand_Returns_Crash_When_Other_Rocket_Already_Landed()
    {
        int horizontalIndex = 5;
        int verticalIndex = 5;
        int userId = 103452;

        _rocketLandingRepositoryMock.Setup(repo => repo.GetItemAsync(It.IsAny<Expression<Func<RocketLanding, bool>>>()))
            .ReturnsAsync(new RocketLanding { HorizontalIndex = 5, VerticalIndex = 5 });

        var result = await _rocketLandingService.CanRocketLand(horizontalIndex, verticalIndex, userId);

        Assert.False(result.IsSuccess);
        Assert.Equal(RocketLandingResponseType.Crash, result.ResponseType);
    }

    [Fact]
    public async Task CanRocketLand_Returns_SuitableToLand_When_No_Collision()
    {
        int horizontalIndex = 5;
        int verticalIndex = 5;
        int userId = 103452;

        _rocketLandingRepositoryMock.Setup(repo => repo.GetItemAsync(It.IsAny<Expression<Func<RocketLanding, bool>>>()))
            .ReturnsAsync((RocketLanding)null);

        var result = await _rocketLandingService.CanRocketLand(horizontalIndex, verticalIndex, userId);

        Assert.True(result.IsSuccess);
        Assert.Equal(RocketLandingResponseType.SuitableToLand, result.ResponseType);
    }

    #region Açıklamalar
    //3 işlem sonuç tipi için örnek automated unit test class'ıdır.
    //Mevcut ticari projemizde uygulamamamız sebebiyle araştırmalar ve örnek çalışmak şeklinde eklenmiştir.
    #endregion
}
