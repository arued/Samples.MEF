using System.ComponentModel.Composition;

namespace Samples.MEF.ConstructorInjection
{
    [Export]
    public class Pizza
    {
        [ImportingConstructor]
        public Pizza(
            [Import(typeof(IDough))] IDough dough,
            [Import(typeof(ITopping))] ITopping topping)
        {
            this.Dough = dough;
            this.Topping = topping;
        }

        public void Prepare()
        {
            this.Dough.Add();
            this.Topping.Add();
        }

        public ITopping Topping { get; private set; }

        public IDough Dough { get; private set; }
    }
}
