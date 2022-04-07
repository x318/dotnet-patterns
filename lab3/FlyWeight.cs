using System.Collections;

namespace lab3
{
    class FlyweightFactory
    {
        private Hashtable _flyweights = new Hashtable();
        public FlyweightFactory()
        {
            _flyweights.Add("X", new ConcreteFlyweight());
            _flyweights.Add("Y", new ConcreteFlyweight());
            _flyweights.Add("Z", new ConcreteFlyweight());
        }
        public Flyweight GetFlyweight(string key)
        {
            if (!_flyweights.ContainsKey(key))
                _flyweights.Add(key, new ConcreteFlyweight());
            return _flyweights[key] as Flyweight;
        }
    }
 
    abstract class Flyweight
    {
        public abstract void Operation(int extrinsicState);
    }
 
    class ConcreteFlyweight : Flyweight
    {
        private int _intrinsicState;
        public override void Operation(int extrinsicState)
        {
        }
    }
 
    class UnsharedConcreteFlyweight : Flyweight
    {
        int allState;
        public override void Operation(int extrinsicState)
        {
            allState = extrinsicState;
        }
    }
}
