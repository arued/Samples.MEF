using System;
using System.ComponentModel.Composition;

namespace Samples.MEF.Simple
{
    [Export(typeof(IQuackBehaviour))]
    public class QuackBeaviour : IQuackBehaviour
    {
        public void MakeSound()
        {
            Console.WriteLine("Quack!");
        }
    }
}
