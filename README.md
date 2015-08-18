# Immerest

Immerest is a C# library containing parsers for basic data types:
* Numeric types
* Date types
* Boolean types
* Enum types

## Tutorial

### Parsing numeric types

```cs
// We can set up custom parser by specifying the thousands and decimal separators
NumberFormatInfo format = new NumberFormatInfo { NumberGroupSeparator = ".", NumberDecimalSeparator = "," };
NumberParser parser = new NumberParser(format);
double result = parser.ParseDouble("5.300.199,20"); // converts to 5300199.20

// Alternatively we can use predefined parsers which support the common European and American number formats
double result2 = NumberParser.European.ParseDouble("5.300.199,20"); // converts to 5300199.20
double result3 = NumberParser.American.ParseDouble("5,300,199.20"); // converts to 5300199.20
```

### Parsing date types

```cs
// Create and use datetime parser using specified datetime formats 
string format = "yyyy-MM-dd";
DateTimeParser parser = new DateTimeParser(format);
DateTime result = parser.ParseDateTime("1996-04-01");
DateTime result2 = parser.ParseDateTime("2011-12-28");
```

### Parsing boolean types

```cs
// Use the default boolean parser
BooleanParser parser = new BooleanParser();
bool result = parser.ParseBoolean("true"); // converts to true
bool result2 = parser.ParseBoolean("false"); // converts to false

// Alternatively, we can set custom strings for conversion of boolean values
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

```cs
enum Seasons {  Spring, Summer, Autumn, Winter }

bool ignoreCase = true; // set whether case will be ignored when parsing enum
EnumParser parser = new EnumParser(ignoreCase);

Seasons season = parser.ParseEnum<Seasons>("winTER"); // Converts to Seasons.Winter
Seasons autumn = parser.ParseEnum<Seasons>("summer"); // Converts to Seasons.Summer
```

## Licence

This project is licensed under the Apache License Version 2.0, which means it can be freely redistributed / modified / used in both commercial and non-commercial projects.
