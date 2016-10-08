using System.ComponentModel.Composition;

namespace Samples.MEF.Simple
{
    public class Duck
    {
        // Die Property kann auch als private deklariert werden.
        [Import(typeof(IQuackBehaviour))]
        public IQuackBehaviour QuackBehaviour { get; set; }

        public void MakeSound()
        {
            this.QuackBehaviour.MakeSound();
        }
    }
}
