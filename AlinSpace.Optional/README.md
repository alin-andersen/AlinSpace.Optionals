# AlinSpace.Optional
[![NuGet version (AlinSpace.Optional)](https://img.shields.io/nuget/v/AlinSpace.Optional.svg?style=flat-square)](https://www.nuget.org/packages/AlinSpace.Optional/)

AlinSpace Optional Types.

## Why?

In C# reference types can either point to an object (be not "null") or not point to any object (be "null"). 
Value types can't be "null". 

However, both reference and value types can be "default". But "default" does not
mean the same for reference and value types. For reference types it means "null" and for value types it means the 
default value (e.g. for integer it is 0).

Optionals help with this problem, by making both reference and value types behave the same.

## Examples

The following optional contains the value 5: 

```csharp
Optional<int> optional = Optional<int>.Some(5);

// Same as above.
Optional<int> optional = 5;

optional.HasValue // true
optional.HasNoValue // false
optional.Value // 5
optional.ValueOrDefault // 5
```

The following optional contains no value: 

```csharp
Optional<int> optional = Optional<int>.None();

optional.HasValue // false
optional.HasNoValue // true
optional.Value // throws OptionalHasNoValueException
optional.ValueOrDefault // 0
```

However be careful about "default". The optional
will have a value:

```csharp
Optional<int> optional = default;

optional.HasValue // true
optional.HasNoValue // false
optional.Value // 0
optional.ValueOrDefault // 0
```