# KlusterG.Essentials
* Basic checks library to make programming certain commonly used checks easier and faster.

# Requirements
* .NET Core v6.0

# How To Import?

## NuGet
* Access the NuGet package manager in your project
* Click Search
* Search for KlusterG.Essentials
* Install the latest version of the library

## Command Line
* Access the Package Manager Console
* Type the command ```Install-Package KlusterG.Essentials -Version 2.0.0```

## .NET CLI
* Type the command ```dotnet add package KlusterG.Essentials --version 2.0.0```

# All Functions

* IsTextNumeric(string value, bool space = true)
* IsEmail(string value)
* IsPassword(string value, bool text = true, bool number = true, int min = 3, int max = 10, string characters = "@!")
* IsText(string value, bool space = true)
* IsCustomText(string value, string characters, bool space = true)
* IsPercentage(string value)
* IsMoney(string value)
* IsNumeric(string value, bool realNumber = false)
* IsValidCpf(string value)
* IsValidRg(string value)
* IsValidCnpj(string value)

#### Alert! Custom special characters follow the same rules as regular expressions, so be careful when using special characters.
