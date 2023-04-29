using System;
using Business.Business;
using Business.Interfaces;

namespace BusinessTestCases;

public class CodeManagerTest
{
    [Fact]
    public void CodeGenerater_ShouldReturn_ValidCode()
    {
        var generator = new CodeManager();

        var code = generator.CodeGenerater();

        Assert.NotNull(code);
        Assert.Equal(8, code.Length); 
        Assert.True(Char.IsLetterOrDigit(code[0]));
        Assert.True(Char.IsLetterOrDigit(code[1])); 
        Assert.True(Char.IsLetterOrDigit(code[2]));
        Assert.True(Char.IsLetterOrDigit(code[3])); 
        Assert.True(Char.IsLetterOrDigit(code[4])); 
        Assert.True(Char.IsLetterOrDigit(code[5])); 
        Assert.True(Char.IsLetterOrDigit(code[6])); 
        Assert.True(Char.IsDigit(code[7]));
    }

    [Fact]
    public void CodeGenerater_ShouldReturn_InvalidCode()
    {
        var generator = new CodeManager();

        var code = generator.CodeGenerater();

        Assert.NotEqual(9, code.Length);
        Assert.False(Char.IsLetter(code[7]));
    }

    [Theory]
    [InlineData("CL2FMER3")]
    [InlineData("Z7NKM9D2")]
    [InlineData("3KTANL33")]
    public void ValidCode_ReturnsTrue(string code)
    {
        var generator = new CodeManager();
        var isValid = generator.InValidCode(code);
        Assert.True(isValid);
    }

    [Theory]
    [InlineData("")]
    [InlineData("L1ZABCD")]
    [InlineData("L1ZABCD22")]
    [InlineData("XYZ12345")]
    [InlineData("L1ZABCD!")]
    [InlineData("A1ZABCD2")]
    [InlineData("L1ZABCD1")]
    [InlineData("L1ZABCD3")]
    [InlineData("L1ZABCD4")]
    [InlineData("L1ZABCD5")]
    [InlineData("L1ZABCD7")]
    [InlineData("L1ZABCD8")]
    [InlineData("L1ZABCD9")]
    public void InValidCode_ReturnsFalse(string code)
    {
        var generator = new CodeManager();
        var isValid = generator.InValidCode(code);
        Assert.False(isValid);
    }
}
