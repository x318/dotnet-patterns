using System;
using System.Collections.Concurrent;
using System.Linq;

namespace lab2
{
    public class Multition
    {
        private static readonly ConcurrentDictionary<string, Multition> _instances = new();
        private Multition(string key) {}
        public static Multition GetInstance(string key)
        {
            return Multition._instances.GetOrAdd(key, x => new(x));
        }
        public void DoSomething()
        {
            Console.WriteLine(_instances.Keys.ToArray()[0]);
        }
    }
}
