# DotNet.General

> NOTE: This is a new repository and is released as a Preview version.

## Summary
C# classes and extensions I find useful in my .NET projects.

## Demo
A demo of all my `DotNet` packages can be found [here](https://github.com/marqdouj/dotnet.demo).

## Features
- **Extensions**
  - `Exceptions`
    - `ToMessage()`. Resolves all messages recursively. Returns a joined string (optional separator).
    Originally designed for use with Aggregate exceptions, but will work with any Exception.
    - `ToList()`. Resolves all messages recursively. Returns a list of messages.
    Originally designed for use with Aggregate exceptions, but will work with any Exception.

  - `Numbers`
    - `IsNumberTypeCode(object)`. Checks if the object's underlying type code is a number.
    - `ToNList<T>(string)`. Converts a delimited string to a List of numbers (NList).

  - `Strings`
    - `ToCrLf()`. Converts line endings in the specified string to carriage return and line feed (`\r\n`).
    - `ToNewLine()`. Converts line endings in the specified string to `Environment.NewLine`.
    - `Truncate`. Truncates a string to a specified length.

- **Classes**
  - `EnumList`. Manages a list of Enum (no duplicates)
  - `NRange`. Numeric range (NRange) constrained within a minimum and maximum value.
  - `StateModel`. Provides a base class for models that support state change notification.

## Release Notes
- `10.0.0-Preview`
  - Initial release.
