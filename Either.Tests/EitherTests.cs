namespace Either.Tests;

public class EitherTests
{
    [Fact]
    public void Left_CreatesLeftEither_Success()
    {
        var either = Either<int, string>.Left(10);
        
        Assert.True(either.IsLeft);
        Assert.False(either.IsRight);
    }

    [Fact]
    public void Right_CreatesRightEither_Success()
    {
        var either = Either<int, string>.Right("hello");
        
        Assert.False(either.IsLeft);
        Assert.True(either.IsRight);
    }

    [Fact]
    public void ImplicitConversion_FromLeftValue()
    {
        Either<int, string> either = 10;
        Assert.True(either.IsLeft);
    }

    [Fact]
    public void ImplicitConversion_FromRightValue()
    {
        Either<int, string> either = "hello";
        Assert.True(either.IsRight);
    }

    [Fact]
    public void Match_ExecutesOnLeft_ForLeftEither()
    {
        Either<int, string> either = 10;
        
        var result = either.Match(
            onLeft: l => l * 2,
            onRight: r => r?.Length
        );
        
        Assert.Equal(20, result);
    }

    [Fact]
    public void Match_ExecutesOnRight_ForRightEither()
    {
        Either<int, string> either = "hello";
        
        var result = either.Match(
            onLeft: l => l * 2,
            onRight: r => r?.Length
        );
        
        Assert.Equal(5, result);
    }
    
    [Fact]
    public void Match_ExecutesOnLeft_ForLeftEitherWithNull()
    {
        var either = Either<string, int>.Left(null);
        
        var result = either.Match(
            onLeft: l => l ?? "default",
            onRight: r => r.ToString()
        );
        
        Assert.Equal("default", result);
    }

    [Fact]
    public void Match_ExecutesOnRight_ForRightEitherWithNull()
    {
        var either = Either<int, string>.Right(null);
        
        var result = either.Match(
            onLeft: l => l.ToString(),
            onRight: r => r ?? "default"
        );
        Assert.Equal("default", result);
    }

    [Fact]
    public void Equals_ReturnsTrue_ForSameLeftValues()
    {
        Either<int, string> either1 = 10;
        Either<int, string> either2 = 10;
        
        Assert.True(either1.Equals(either2));
        Assert.True(either1 == either2);
        Assert.False(either1 != either2);
    }

    [Fact]
    public void Equals_ReturnsTrue_ForSameRightValues()
    {
        Either<int, string> either1 = "hello";
        Either<int, string> either2 = "hello";
        
        Assert.True(either1.Equals(either2));
        Assert.True(either1 == either2);
        Assert.False(either1 != either2);
    }
    
    [Fact]
    public void Equals_ReturnsTrue_ForTwoLeftsWithNullValue()
    {
        var either1 = Either<string?, string>.Left(null);
        var either2 = Either<string?, string>.Left(null);
        
        Assert.True(either1.Equals(either2));
        Assert.True(either1 == either2);
    }

    [Fact]
    public void Equals_ReturnsTrue_ForTwoRightsWithNullValue()
    {
        var either1 = Either<string, string?>.Right(null);
        var either2 = Either<string, string?>.Right(null);
        
        Assert.True(either1.Equals(either2));
        Assert.True(either1 == either2);
    }

    [Fact]
    public void Equals_ReturnsFalse_ForDifferentValues()
    {
        Either<int, string> either1 = 10;
        Either<int, string> either2 = 20;
        
        Assert.False(either1.Equals(either2));
        Assert.False(either1 == either2);
        Assert.True(either1 != either2);
    }

    [Fact]
    public void Equals_ReturnsFalse_ForDifferentTypes()
    {
        Either<int, string> either1 = 10;
        Either<int, string> either2 = "hello";
        
        Assert.False(either1.Equals(either2));
        Assert.False(either1 == either2);
        Assert.True(either1 != either2);
    }
    
    [Fact]
    public void Equals_ReturnsFalse_ForLeftAndRightWithNullValue()
    {
        var either1 = Either<string?, string>.Left(null);
        var either2 = Either<string, string?>.Right(null);
        
        Assert.False(either1.Equals(either2));
        Assert.False(either1 == either2);
    }

    [Fact]
    public void GetHashCode_ReturnsSameValue_ForSameLeftValues()
    {
        Either<int, string> either1 = 10;
        Either<int, string> either2 = 10;
        
        Assert.Equal(either1.GetHashCode(), either2.GetHashCode());
    }

    [Fact]
    public void GetHashCode_ReturnsSameValue_ForSameRightValues()
    {
        Either<int, string> either1 = "hello";
        Either<int, string> either2 = "hello";
        
        Assert.Equal(either1.GetHashCode(), either2.GetHashCode());
    }

    [Fact]
    public void GetHashCode_ReturnsDifferentValue_ForDifferentValues()
    {
        Either<int, string> either1 = 10;
        Either<int, string> either2 = 20;
        
        Assert.NotEqual(either1.GetHashCode(), either2.GetHashCode());
    }

    [Fact]
    public void GetHashCode_ReturnsDifferentValue_ForDifferentTypes()
    {
        Either<int, string> either1 = 10;
        Either<int, string> either2 = "hello";
        
        Assert.NotEqual(either1.GetHashCode(), either2.GetHashCode());
    }
}
