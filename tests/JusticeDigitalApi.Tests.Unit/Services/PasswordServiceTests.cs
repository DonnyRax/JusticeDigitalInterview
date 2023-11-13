using FluentAssertions;
using JusticeDigitalApi.Services;

namespace JusticeDigitalApi.Tests.Unit.Services;

public class PasswordServiceTests
{
    private readonly PasswordService _sut;

    public PasswordServiceTests()
    {
        _sut = new PasswordService();
    }

    [Theory]
    [InlineData("ThisIs_MyPass20rd")]
    [InlineData("ThisIs_MyPass20rd$")]
    [InlineData("123456Aa_#")]
    [InlineData("123 4^5Aa_")]
    [InlineData("1_aA  ()   ")]
    public void ValidatePassword_ShouldReturnTrue_WhenPasswordIsValid(string password)
    {
        // Act
        var result = _sut.ValidatePassword(password);

        // Assert
        result.Should().BeTrue();
    }

    [Theory]
    [InlineData("Aa_1234")]
    [InlineData("aa_123456$")]
    [InlineData("AA_123456")]
    [InlineData("aA_BCDEFG")]
    [InlineData("aA*BCDEFG")]
    [InlineData("")]
    public void ValidatePassword_ShouldReturnFalse_WhenPasswordIsInvalid(string password)
    {
        // Act
        var result = _sut.ValidatePassword(password);

        // Assert
        result.Should().BeFalse();
    }
}
