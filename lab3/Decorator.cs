using System;

namespace lab3
{
    class Thing
    {
        private string _string;
        public string ThingString
        {
            get => _string;
            set => _string = value;
        }
        public void PrintThingString()
        {
            Console.WriteLine(_string);
        }
    }

    class ThingWrapper
    {
        private Thing _thing;
        public ThingWrapper(Thing thing)
        {
            _thing = thing;
        }
        public string ThingString
        {
            get => _thing.ThingString;
            set => _thing.ThingString = value;
        }
        public void PrintThingString()
        {
            _thing.PrintThingString();
        }
    }
}
