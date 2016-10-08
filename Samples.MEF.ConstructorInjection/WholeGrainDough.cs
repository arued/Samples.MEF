using System;
using System.ComponentModel.Composition;

namespace Samples.MEF.ConstructorInjection
{
    [Export(typeof(IDough))]
    public class WholeGrainDough : IDough
    {
        public void Add()
        {
            Console.WriteLine("WholeGrain Dough added");
        }
    }
}
