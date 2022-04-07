using System;

namespace lab3
{
    static class Program
    {
        static void Main(string[] args)
        {
            //Adapter
            Adaptee adaptee = new();
            ITarget target = new Adapter(adaptee);
            Console.WriteLine(target.GetRequest());

            //Bridge
            Abstraction abstraction = new RefinedAbstraction(new ConcreteImplementorA());
            abstraction.Operation();
            abstraction.Implementor = new ConcreteImplementorB();
            abstraction.Operation();

            //Composite
            Composite composite = new Composite();
            composite.AddChild(new Leaf());
            composite.AddChild(new Leaf());
            foreach (var el in composite)
            {
                Console.WriteLine(el.ToString());
            }

            //Decorator
            ThingWrapper thingWrapper = new(new Thing() { ThingString = "test" });
            thingWrapper.PrintThingString();

            //Facade
            Facade facade = new();
            facade.MethodA();
            facade.MethodB();
            
            //Front controller
            FrontController frontController = new FrontController();
            frontController.dispatchRequest("Teacher");
            frontController.dispatchRequest("Student");
            
            //Flyweight
            int extrinsicstate = 22;
            FlyweightFactory f = new FlyweightFactory();
            Flyweight fx = f.GetFlyweight("X");
            fx.Operation(--extrinsicstate);
            Flyweight fy = f.GetFlyweight("Y");
            fy.Operation(--extrinsicstate);
            UnsharedConcreteFlyweight uf = new UnsharedConcreteFlyweight();
            uf.Operation(--extrinsicstate);
            
            //Proxy
            Proxy proxy = new Proxy();
            proxy.Request();
        }
    }
}
