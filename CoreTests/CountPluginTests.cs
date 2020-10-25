using Core.Plugins;
using System;
using Xunit;

namespace CoreTests
{
    public class CountPluginTests
    {
        readonly CountPlugin sut = new CountPlugin();

        [Theory]
        [InlineData("abcd", "4")]
        [InlineData("testing data", "12")]
        [InlineData("", "0")]
        public void CountPluginShouldReturnNumberOfLettersInInput(string input, string expected)
        {
            var output = sut.Execute(input);
            Assert.Equal(expected, output);
        }

        [Fact]
        public void CountPluginShouldThrowExceptionWhenInputIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => sut.Execute(null));
        }
    }
}
