## Introduction

[![NuGet Release](https://img.shields.io/nuget/v/Optivem.Commons.Parsing.svg)](https://www.nuget.org/packages/Optivem.Commons.Parsing)

Optivem .NET Commons Parsing is a .NET Core 2.2 library providing interfaces for parsing.

## Installation

To install this package via NuGet:

```
PM> Install-Package Optivem.Commons.Parsing
```

## License

Licensed under the [MIT license](http://opensource.org/licenses/mit-license.php). Copyright © 2019 [Optivem](https://www.optivem.com/) All Rights Reserved. 














[![NuGet Release](https://img.shields.io/nuget/v/Optivem.Commons.Parsing.Default.svg)](https://www.nuget.org/packages/Optivem.Commons.Parsing.Default)

Optivem .NET Commons Parsing Default is a .NET Core 2.2 library providing default implementations for parsing.

It contains parsers for basic data types:
* Numeric types
* Date types
* Boolean types
* Enum types

## Installation

To install this package via NuGet:

```
PM> Install-Package Optivem.Commons.Parsing.Default
```

## Tutorial

### Parsing numeric types

When parsing numeric types, we can define the group separator and the decimal separator as part of the number format. Then, this number format is provided to the parser, so that the parser can parse numeric types using that format:

```cs
NumberFormatInfo format = new NumberFormatInfo { NumberGroupSeparator = ".", NumberDecimalSeparator = "," };
NumberParser parser = new NumberParser(format);
double result = parser.ParseDouble("5.300.199,20"); // converts to 5300199.20
```

Alternatively, if we do not want to create any custom number formats, but instead want to use the predefined European (comma as decimal separator) or American (dot as decimal separator), we can use that:

```cs
double result2 = NumberParser.European.ParseDouble("5.300.199,20"); // converts to 5300199.20
double result3 = NumberParser.American.ParseDouble("5,300,199.20"); // converts to 5300199.20
```

### Parsing date types

When parsing date types, the date format needs to be passed to the parser, so that it can parse dates using that format:

```cs
string format = "yyyy-MM-dd";
DateTimeParser parser = new DateTimeParser(format);
DateTime result = parser.ParseDateTime("1996-04-01");
DateTime result2 = parser.ParseDateTime("2011-12-28");
```

### Parsing boolean types

When parsing boolean types, one possibility is to use the default strings for true and false (case-insensitive):

```cs
BooleanParser parser = new BooleanParser();
bool result = parser.ParseBoolean("truE"); // converts to true
bool result2 = parser.ParseBoolean("FAlse"); // converts to false
```

Alternatively, we might want to define a custom map of strings representing boolean values. In that case, the parser will perform the custom conversion:

```cs
Dictionary<string, bool> mapping = new Dictionary<string, bool>
  {
    { "Yes", true },
    { "No", false },
    { "Y", true },
    { "N", false }
  };

BooleanParser parser2 = new BooleanParser(mapping);
bool result3 = parser2.ParseBoolean("true"); // converts to true
bool result4 = parser2.ParseBoolean("Yes"); // converts to true
bool result5 = parser2.ParseBoolean("N"); // converts to false
```

### Parsing enum types

Suppose that there is some enum defined:
```cs
enum Seasons {  Spring, Summer, Autumn, Winter }
```

Then, we can set a parser for that enum type (can be either case-sensitive or case-insensitive):

```cs
bool ignoreCase = true; // set whether case will be ignored when parsing enum
EnumParser parser = new EnumParser(ignoreCase);

Seasons season = parser.ParseEnum<Seasons>("winTER"); // Converts to Seasons.Winter
Seasons autumn = parser.ParseEnum<Seasons>("summer"); // Converts to Seasons.Summer
```

Alternatively, we are also able to define mappings between strings and enums, so that strings get converted to enums:

```cs
Dictionary<string, Seasons> map = new Dictionary<string, Seasons>
{
  { "sppringg", Seasons.Spring },
  { "Sptring", Seasons.Spring },
  { "Summer", Seasons.Summer },
  { "SSS", Seasons.Summer },
  { "suMMer", Seasons.Summer }
};

EnumStringParser<Seasons> parser = new EnumStringParser<Seasons>(map);
Seasons result1 = parser.ParseEnum("Sptring"); // Converts to Seasons.Spring
Seasons result2 = parser.ParseEnum("SSS"); // Converts to Seasons.Summer
```