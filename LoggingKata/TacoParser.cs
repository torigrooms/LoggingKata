using System.Collections;
using System.Collections.Generic;
using log4net;

namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the TacoBells
    /// </summary>
    public class TacoParser
    {
        public TacoParser()
        {

        }

        private static readonly ILog Logger =
            LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ITrackable Parse(string line)
        {
            //Take your line and use string.Split(",",line)
            //Or it is a line.Split(",")

            //if your array.Length is less than 3, something went wrong...log that and return null
            
            //use a foreach to print out every item in your array

            //grab the long from your array at index 0
            //grab the lat from your array at index 1
            //grab the name from your array at index 2

            //Need to parse your string as a decimal, which is similiar to parsing as an int
            //create a taco bell class that conforms to ITrackable

            //you'll need an instance of the taco bell class with the name and point set correctly
            //then return your instance of your taco bell class since it conforms to ITrackable.

            //DO not fail if one record parsing fails, return null
            return null; //TODO Implement
        }
    }
}