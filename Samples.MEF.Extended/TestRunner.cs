using System;
using System.ComponentModel.Composition;

namespace Samples.MEF.ManyDelegates
{
    public class TestRunner
    {
        [ImportMany("TestRun")]
        private Action[] testRuns = null;
        
        public void RunTests()
        {
            foreach (var testRun in this.testRuns)
            {
                testRun();
            }

            Console.ReadKey();
        }
    }
}
