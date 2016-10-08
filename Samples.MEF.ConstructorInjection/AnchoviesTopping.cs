using System;
using System.ComponentModel.Composition;

namespace Samples.MEF.ConstructorInjection
{
    [Export(typeof(ITopping))]
    public class AnchoviesTopping : ITopping
    {
        public void Add()
        {
            Console.WriteLine("Anchovies added");
        }
    }
}
