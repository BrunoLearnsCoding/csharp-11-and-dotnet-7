using FluentAssertions;
using Implementing_Common_Interfaces;
namespace Unit_Tests;


public class IFormattableTests {
    [Theory]
    [InlineData("FF, LL", "Tim, Corey")]
    [InlineData("FLL", "TCorey")]
    [InlineData("LL, F.", "Corey, T.")]

    public void Test_Format(string? fromat, string expected) {
        // Arrange
        var person = new Person("Corey") {FirstName = "Tim"};

        // Action
        var actual = person.ToString(fromat);

        // Assert

        actual.Should().Be(expected);


    }

}