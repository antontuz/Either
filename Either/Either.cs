using System.Runtime.InteropServices;

namespace Either;

[StructLayout(LayoutKind.Auto)]
public readonly struct Either<TLeft, TRight> : IEquatable<Either<TLeft, TRight>>
{
    private readonly TLeft? _left;
    private readonly TRight? _right;
    private readonly bool _isRight;

    private Either(TLeft? left, TRight? right, bool isRight)
    {
        _left = left;
        _right = right;
        _isRight = isRight;
    }

    public bool IsLeft => !_isRight;
    public bool IsRight => _isRight;

    public static Either<TLeft, TRight> Left(TLeft? value) => new(value, default, false);
    public static Either<TLeft, TRight> Right(TRight? value) => new(default, value, true);

    public static implicit operator Either<TLeft, TRight>(TLeft? value) => Left(value);
    public static implicit operator Either<TLeft, TRight>(TRight? value) => Right(value);

    public TResult Match<TResult>(
        Func<TLeft?, TResult> onLeft,
        Func<TRight?, TResult> onRight) =>
        _isRight ? onRight(_right) : onLeft(_left);
    
    public bool Equals(Either<TLeft, TRight> other) =>
        _isRight == other._isRight && (_isRight
            ? EqualityComparer<TRight?>.Default.Equals(_right, other._right)
            : EqualityComparer<TLeft?>.Default.Equals(_left, other._left));

    public override bool Equals(object? obj) => obj is Either<TLeft, TRight> other && Equals(other);

    public override int GetHashCode() => _isRight 
        ? HashCode.Combine(true, _right) 
        : HashCode.Combine(false, _left);

    public static bool operator ==(Either<TLeft, TRight> left, Either<TLeft, TRight> right) => left.Equals(right);
    
    public static bool operator !=(Either<TLeft, TRight> left, Either<TLeft, TRight> right) => !left.Equals(right);
}