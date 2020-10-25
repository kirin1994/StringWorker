using Core.Plugins;
using System;
using Xunit;


namespace CoreTests
{
    public class SumPluginTests
    {
        readonly SumPlugin sut = new SumPlugin();

        [Theory]
        [InlineData("10+4", "14")]
        [InlineData("12+5+3", "20")]
        public void SumPluginShouldReturnNumberOfLettersInInput(string input, string expected)
        {
            var output = sut.Execute(input);
            Assert.Equal(expected, output);
        }

        [Fact]
        public void SumPluginShouldThrowExceptionWhenInputIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => sut.Execute(null));
        }

        [Fact]
        public void SumPluginShouldThrowExceptionWhenInputContainsLetters()
        {
            Assert.Throws<ArgumentException>(() => sut.Execute("ad+12+b"));
        }

        [Fact]
        public void SumPluginShouldThrowExceptionWhenInputContainsEmptyChars()
        {
            Assert.Throws<ArgumentException>(() => sut.Execute("ad++b"));
        }
    }
}
