using System;
using Samples.MEF.Common;

namespace Samples.MEF.Simple
{
    public class Program
    {
        static void Main(string[] args)
        {
            var duck = new Duck();

            CompositionServices.ComposeParts(duck);

            duck.MakeSound();

            Console.Read();
        }
    }
}
