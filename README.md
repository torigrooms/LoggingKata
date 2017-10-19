# LoggingKata
An exercise in geolocation, csv parsing, and logging

## Kata Overview
Here's what you'll need to do for this Kata

### Step 1
Fork and clone this repo

### Step 2
* Complete all the TODOs while adding appropriate log statements along the way!
* Start with writing a Unit Test to Test the Parse method
* Implement the Parse Method
* Use the Geolocation to calculate distance between two points

You can find more details below in [Kata Details](#kata-details)

### Step 3
* Reduce the logging verbosity and rerun

### Step 4
Send a pull request from your forked repo to this original repo

## Kata Details
Here's some more details for completing the steps above.

### TacoParser
Updating the `Parse` method in your `TacoParser`

This method is used to parse a single row from your CSV file as a string and return an ITrackable:

```csharp
public ITrackable Parse(string line)
{
    // Take your line and use string.Split(",", line);
    // Or it's line.Split(",");

    // If your array.Length is less than 3, something went wrong
    // Log that and return null

    // grab the long from your array at index 0
    // grab the lat from your array at index 1
    // grab the name from your array at index 2

    // Your going to need to parse your string as a Decimal
    // which is similar to parse a string as an int

    // You'll need to create a TacoBell class
    // that conforms to ITrackable

    // Then, you'll need an instance of the TacoBell class
    // With the name and point set correctly

    // Then, return the instance of your TacoBell class
    // Since it conforms to ITrackable
}
```
