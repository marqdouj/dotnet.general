# DotNet.General

## Summary
C# classes and extensions I find useful in my .NET projects.

## Demo
A demo of this, and other of my `DotNet` packages, can be found [here](https://github.com/marqdouj/dotnet.demo).

## Features
- **Extensions**
  - `Exceptions`
    - `exception.ToMessage()`. Resolves all messages recursively. Returns a joined string (optional separator).
    Originally designed for use with Aggregate exceptions, but will work with any Exception.
    - `exception.ToList()`. Resolves all messages recursively. Returns a list of messages.
    Originally designed for use with Aggregate exceptions, but will work with any Exception.

  - `Numbers`
    - `object.IsNumberTypeCode()`. Checks if the object's underlying type code is a number.
    - `string.ToNList<T>()`. Converts a delimited string to a List of numbers (NList).
    - `string.ToNumber<T>()`. Converts a string to to a number.
      - If the string can't be converted, default(T) will be returned unless a default value is provided.
    - `string.ToNumberN<T>()`. Converts a string to to a number. Allows for nullable.
      - If the string can't be converted, default(T?) will be returned unless a default value is provided.

  - `Strings`
    - `string.Truncate()`. Truncates a string to a specified length.

- **Classes**
  - `EnumList`. Manages a list of Enum (no duplicates)
  - `NRange`. Numeric range (NRange) constrained within a minimum and maximum value.
  - `BStringValue`. String wrapper for a bool. Useful in binding scenarios that require a string.
  - `BStringValueN`. String wrapper for a nullable bool. Useful in binding scenarios that require a string.
  - `NStringValue<T>`. String wrapper for a number. Useful in binding scenarios that require a string.
  - `NStringValueN<T>`. String wrapper for a nullable number. Useful in binding scenarios that require a string.
  - `StateModel`. Provides a base class for models that support state change notification.

## Release Notes
- `10.1.0`
  - `Numbers`
    - `string.ToNumberN<T>()`. New method.
    - `string.ToNumber<T>()`. Removed nullables (Possible breaking changes).

  - `Classes`.
    - `BStringValue`. New class.
    - `BStringValueN`. New class.
    - `NStringValue<T>`. New class.
    - `NStringValueN<T>`. New class.

- `10.0.0`
  - Initial release.
