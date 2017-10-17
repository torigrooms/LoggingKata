using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;

namespace LoggingKata
{
    class Program
    {
        //Why do you think we use ILog?
        private static readonly ILog Logger =
            LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
         
            Logger.Info("Log initialized");
            var csvPath = Environment.CurrentDirectory + "\\Taco_Bell-US-AL-Alabama.csv";
            Logger.Debug("Created csvPath variable:" + csvPath);
            var rows = File.ReadAllLines(csvPath);

            if (rows.Length == 0)
            {
                Logger.Error("Our csv file is empty or missing content.");
            }

            else if (rows.Length == 1)
            {
                Logger.Warn("Can't compare. There's only one element.");
            }
            
            var parser = new TacoParser();
            var locations = rows.Select(row => parser.Parse(row));

            //TODO:  Find the two TacoBells in Alabama that are the furthurest from one another.
            //HINT:  You'll need two nested forloops

        }
    }
}