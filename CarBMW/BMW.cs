using System;
using System.ComponentModel.Composition;
using CarContract;

namespace CarBMW
{
    [Export(typeof(ICarContract))]
    public class BMW : ICarContract
    {
        public string GetName()
        {
            return "BMW";
        }
    }
}
