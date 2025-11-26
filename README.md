# Either

![Platform](https://img.shields.io/badge/platform-.NET_7.0%2B-512BD4)
![License](https://img.shields.io/badge/license-MIT-green)
![Allocations](https://img.shields.io/badge/allocations-zero-brightgreen)

A lightweight, thread-safe discriminated union struct for C#.

> [!TIP]
> **Performance Focused:** This implementation uses `readonly struct` with `[StructLayout(LayoutKind.Auto)]` to minimize memory footprint and ensure **zero-allocation overhead** during instantiation.

## Usage

```csharp
// 1. Implicit conversion (Clean Syntax)
Either<string, int> value = 42; 

// 2. Type-safe matching
string result = value.Match(
    onLeft:  str => $"Text: {str}",
    onRight: num => $"Number: {num}"
);
