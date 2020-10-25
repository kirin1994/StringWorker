using Core.Plugins;
using System;
using Xunit;

namespace CoreTests
{
    public class ReversePluginTests
    {
        readonly ReversePlugin sut = new ReversePlugin();

        [Theory]
        [InlineData("abc", "cba")]
        [InlineData("aaabbbccc", "cccbbbaaa")]
        [InlineData("", "")]
        public void ReversePluginShouldReverseString(string input, string expected)
        {
            var output = sut.Execute(input);
            Assert.Equal(expected, output);
        }

        [Fact]
        public void ReversePluginShouldThrowExceptionWhenInputIsNull()
        {
            Assert.Throws<ArgumentNullException>(()=> sut.Execute(null));
        }
    }
}
