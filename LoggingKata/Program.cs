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

			if (rows.Length == 0)
			{
				Logger.Error("Our csv file is missing or empty of content");
			}
			else if (rows.Length == 1)
			{
				Logger.Warn("Can't compare. There is only one element");
			}

			var parser = new TacoParser();

			Logger.Debug("Initialized our Parser");

			var locations = rows.Select(row => parser.Parse(row));

			ITrackable a = null;

			ITrackable b = null;

			double distance = 0;

			//TODO:  Find the two TacoBells in Alabama that are the furthurest from one another.
			foreach (var locA in locations)
			{
				Logger.Debug("Checking origins");
				var origin = new Coordinate
				{
					Latitude = locA.Location.Latitude,
					Longitude = locA.Location.Longitude
				};
				foreach (var locB in locations)
				{
					Logger.Debug("Checking origin against destinations");
					var destination = new Coordinate
					{
						Latitude = locB.Location.Latitude,
						Longitude = locB.Location.Longitude
					};
					Logger.Debug("Getting miles");
					var nDist = GeoCalculator.GetDistance(origin, destination);

					if (nDist > distance)
					{
						Logger.Info("Found two furthest locations");
						a = locA;
						b = locB;
						distance = nDist;
					}
				}

			}
			Console.WriteLine($"The two Taco Bells that are furthest apart are: {a.Name} and: {b.Name}");
			Console.WriteLine($"These two locations are {distance} miles apart");
			Console.ReadLine();

		}

	}

}





















