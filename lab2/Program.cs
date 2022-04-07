using System;

namespace lab2
{
    static class Program
    {
        static void Main(string[] args)
        {
            // AbstractFactory
            var pirateShip = new SpaceShip("Pirate ship 1", new PirateSpaceshipFactory());
            var milShip = new SpaceShip("Millitary ship 1", new MillitarySpaceshipFactory());

            Console.WriteLine(pirateShip.ToString());
            Console.WriteLine(milShip.ToString());


            // Builder
            Builder builder = new BuilderRandomInt();
            Director director = new(builder);
            director.ConstructInt();
            var arrInt = builder.GetResInt();
            foreach (var el in arrInt.GetArrayInt())
            {
                Console.Write($"{el},");
            }
            Console.WriteLine();

            Builder builderChar = new BuilderRandomChar();
            Director directorChar = new(builderChar);
            directorChar.ConstructChar();
            var arrChar = builderChar.GetResChar();
            foreach (var el in arrChar.GetArrayChar())
            {
                Console.Write($"{el},");
            }
            Console.WriteLine();

            //Factory Method
            Creator[] creators = new Creator[]
            {
                new ConcreteCreatorA(),
                new ConcreteCreatorB()
            };

            foreach (var creator in creators)
            {
                Product product = creator.FactoryMethod();
                Console.WriteLine($"Created {product.GetType().Name}");
            }

            //Lazy init
            Lazyinitialization lazyInit = new();
            Console.WriteLine(lazyInit.BlobData.Length);
            
            //Multition
            Multition mt = Multition.GetInstance("test");
            mt.DoSomething();
        }
    }
}
