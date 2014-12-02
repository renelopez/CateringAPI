using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catering.Data.Migrations;
using Microsoft.Owin.Hosting;

namespace Catering.ServiceSH
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = "http://localhost:9000/";

            // System.Data.Entity.Database.SetInitializer(new ColloquiumDBContextInitializer());
            // Start OWIN host 
            using (WebApp.Start<Startup>(url: baseAddress))
            {
                Console.WriteLine("Running on:" + baseAddress);
                Console.ReadLine();
            }
        }
    }
}
