using System;
using System.ComponentModel.Composition;
using Samples.MEF.Common;

namespace Samples.MEF.ConstructorInjection
{
    class Program
    {
        [Import]
        public Pizza Pizza { get; set; }

        static void Main(string[] args)
        {
            new Program().Run();
        }

        private void Run()
        {
            var container = CompositionServices.ComposeAll();
            container.ComposeParts(this);

            this.Pizza.Prepare();

            Console.ReadKey();
        }
    }
}
