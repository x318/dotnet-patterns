namespace lab3
{
    abstract class Abstraction
    {
        protected Implementor _implementor;
        public Implementor Implementor
        {
            set => _implementor = value;
        }
        public Abstraction(Implementor imp)
        {
            _implementor = imp;
        }
        public virtual void Operation()
        {
            _implementor.OperationImp();
        }
    }

    abstract class Implementor
    {
        public abstract void OperationImp();
    }

    class RefinedAbstraction : Abstraction
    {
        public RefinedAbstraction(Implementor imp)
            : base(imp)
        {
        }
        public override void Operation()
        {
        }
    }

    class ConcreteImplementorA : Implementor
    {
        public override void OperationImp()
        {
        }
    }

    class ConcreteImplementorB : Implementor
    {
        public override void OperationImp()
        {
        }
    }
}
