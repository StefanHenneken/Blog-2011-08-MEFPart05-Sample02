using System;
using System.ComponentModel.Composition;
using CarContract;

namespace CarMercedes
{
    [Export(typeof(ICarContract))]
    public class Mercedes : ICarContract
    {
        public string GetName()
        {
            return "Mercedes";
        }
    }
}
