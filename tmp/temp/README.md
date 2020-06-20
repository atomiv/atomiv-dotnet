# Vembridge

Vembridge is a general-purpose utility library for reading and writing delimiter-separated values (DSV) with support for internationalization and custom formats.

## Functionalities

Functionalities which are in the progress of being implemented:

* Support reading and writing delimiter-separated value formats
* Support reading and writing fixed-width formats
* Support conversion to custom objects when reading and writing
* Support for internationalization of number formats and date formats

## Tutorial

### Reading delimiter-separated value files

To read delimiter-separated value files, it is necessary to firstly construct a TextReader, and then pass it to the StringDelimitedReader which will read the lines of the file and split each line by the delimiter.

```cs
string path = @"C:\path\to\some_file.csv";
string delimiter = ",";

List<string[]> records;
using (TextReader textReader = new StreamReader(path))
{
	StringDelimitedReader reader = new StringDelimitedReader(textReader, delimiter);
	records = reader.ReadToEnd();
}
```

### Reading fixed-width files

To read fixed-width files, it is necessary to define the fixed-width field formats (i.e. the starting indexes and the lengths for each field). Then, after constructing a TextReader for the relevant file, the TextReader is passed to the StringFixedReader which reads all the lines, using the fixed-width formats to retrieve the records.

```cs
string path = @"C:\path\to\some_file.csv";
List<FixedFieldFormat> formats = new List<FixedFieldFormat>
{
	new FixedFieldFormat(0, 5),
	new FixedFieldFormat(5, 3),
	new FixedFieldFormat(8, 4),
	new FixedFieldFormat(12, 2)
};

List<string[]> records;
using (TextReader textReader = new StreamReader(path))
{
	StringFixedReader reader = new StringFixedReader(textReader, formats);
	records = reader.ReadToEnd();
}
```

### More tutorials coming up

The Tutorials section will soon be updated with examples of how you can set up your custom object converters for reading and writing, and also how to read/write files with internationalization support. Stay tuned!

## Website

The main website for this project on GitHub: [optivem.github.io/vembridge](http://optivem.github.io/vembridge).

## Issues

To report any issues and bugs, or if you have any suggestions for improvements and new features, please create a ticket using the Issue Tracker: [github.com/optivem/vembridge/issues](https://github.com/optivem/vembridge/issues).

## Licence

Copyright (c) 2015 [Atomiv](http://atomiv.com/). Licensed under the [Apache License, Version 2.0](http://www.apache.org/licenses/LICENSE-2.0).
