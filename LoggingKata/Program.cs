using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using System.IO;
using Geolocation;

namespace LoggingKata
{

	class Program
	{
		private static readonly ILog Logger =
			LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		static void Main(string[] args)
		{
			Logger.Info("Log initialized");

			var csvPath = Environment.CurrentDirectory + "\\Taco_Bell-US-AL-Alabama.csv";

			Logger.Debug("Created csvPath variable: " + csvPath);

			var rows = File.ReadAllLines(csvPath);

			switch (rows.Length)
			{
				case 1:
					Logger.Error("Our csv file is missing or empty of content");
					break;
				case 2:
					Logger.Warn("Can't compare. There is only one element");
					break;
			}

			var parser = new TacoParser();

			Logger.Debug("Initialized our Parser");

			var locations = rows.Select(row => parser.Parse(row))
				.OrderBy(loc => loc.Location.Longitude)
				.ThenBy(loc => loc.Location.Latitude)
				.ToArray();

			ITrackable a = null;

			ITrackable b = null;

			double distance = 0;

			//TODO:  Find the two TacoBells in Alabama that are the furthurest from one another.
			foreach (var locA in locations)
			{
				var origin = new Coordinate {Latitude = locA.Location.Latitude, Longitude = locA.Location.Longitude };
				foreach (var locB in locations)
				{
					var destination = new Coordinate {Latitude = locB.Location.Latitude, Longitude = locB.Location.Longitude};
					var nDist = GeoCalculator.GetDistance(origin, destination);

					if (!(nDist > distance)) {continue;}
					Logger.Info("Found two furthest locations");
					a = locA;
					b = locB;
					distance = nDist;
				}

			}
			if (a == null || b == null)
			{
				Logger.Error("Failed to find two furthest locations");
				Console.WriteLine("Couldn't find the two furthest locations");
				Console.ReadLine();
				return;
			}
			var logMessage =
				$"The two Taco Bells that are furthest apart are: {a.Name} and: {b.Name}. These two locations are {distance} miles apart.";
			Logger.Info(logMessage);
			Console.WriteLine(logMessage);
			Console.ReadLine();

		}

	}

}





















