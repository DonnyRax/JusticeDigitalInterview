using FluentAssertions;
using JusticeDigitalApi.Validation;

namespace JusticeDigitalApi.Tests.Unit.Validation;

public class ValidatePasswordTests
{
    private readonly ValidatePassword _sut;

    public ValidatePasswordTests()
    {
        _sut = new ValidatePassword();
    }

    [Theory]
    [InlineData("ThisIs_MyP@ss20rd")]
    [InlineData("This?s_MyPass20rd$")]
    [InlineData("123456Aa_")]
    [InlineData("123 456Aa_")]
    [InlineData("1_aA     ")]
    public void Validate_ShouldReturnTrue_WhenPasswordIsValid(string password)
    {
        // Act
        var result = _sut.Validate(password);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void Validate_ShouldReturnFalse_WhenPasswordIsEmpty()
    {
        // Arrange
        var password = "";

        // Act
        var result = _sut.Validate(password);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void Validate_ShouldReturnFalse_WhenPasswordIsLessThanNineCharacters()
    {
        // Arrange
        var password = "Aa_1234";

        // Act
        var result = _sut.Validate(password);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void Validate_ShouldReturnFalse_WhenPasswordContainsNoCapitalLetter()
    {
        // Arrange
        var password = "aa_123456";

        // Act
        var result = _sut.Validate(password);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void Validate_ShouldReturnFalse_WhenPasswordContainsNoLowercaseLetter()
    {
        // Arrange
        var password = "AA_123456";

        // Act
        var result = _sut.Validate(password);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void Validate_ShouldReturnFalse_WhenPasswordContainsNoNumber()
    {
        // Arrange
        var password = "aA_BCDEFG";

        // Act
        var result = _sut.Validate(password);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void Validate_ShouldReturnFalse_WhenPasswordContainsUnderscore()
    {
        // Arrange
        var password = "aA*BCDEFG";

        // Act
        var result = _sut.Validate(password);

        // Assert
        result.Should().BeFalse();
    }
}
