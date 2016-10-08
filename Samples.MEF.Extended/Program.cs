using Samples.MEF.Common;

namespace Samples.MEF.ManyDelegates
{
    public class Program
    {
        static void Main(string[] args)
        {
            var testRunner = new TestRunner();

            CompositionServices.ComposeParts(testRunner);

            testRunner.RunTests();
        }
    }
}
