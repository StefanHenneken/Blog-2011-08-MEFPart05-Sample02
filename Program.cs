using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using CarContract;

namespace CarHost
{
    class Program
    {
        [ImportMany(typeof(ICarContract), AllowRecomposition=true)]
        private IEnumerable<ICarContract> CarParts { get; set; }

        static void Main(string[] args)
        {
            new Program().Run();
        }
        void Run()
        {
            var aggregateCatalog = new AggregateCatalog();

            aggregateCatalog.Catalogs.Add(new DirectoryCatalog(@".\AddIn01"));
            var container = new CompositionContainer(aggregateCatalog);
            container.ComposeParts(this);

            foreach (ICarContract car in CarParts)
                Console.WriteLine(car.GetName());
                
            Console.WriteLine("\n...weitere Parts laden...\n");

            aggregateCatalog.Catalogs.Add(new DirectoryCatalog(@".\AddIn02"));
            container.ComposeParts(this);

            foreach (ICarContract car in CarParts)
                Console.WriteLine(car.GetName());

            container.Dispose();
        }
    }
}
