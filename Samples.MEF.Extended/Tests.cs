using System;
using System.ComponentModel.Composition;

namespace Samples.MEF.ManyDelegates
{
    public class Tests
    {
        [Export("TestRun")]
        public void GreenTest()
        {
            Console.WriteLine("Test Green");
        }

        [Export("TestRun")]
        public void RedTest()
        {
            Console.WriteLine("Test Red");
        }
    }
}
