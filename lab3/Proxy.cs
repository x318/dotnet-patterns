using System;

namespace lab3
{
    public abstract class Subject
    {
        public abstract void Request();
    }
    public class RealSubject : Subject
    {
        public override void Request()
        {
            Console.WriteLine("Called RealSubject.Request()");
        }
    }
    public class Proxy : Subject
    {
        private RealSubject _realSubject;
        public override void Request()
        {
            if (_realSubject is null)
            {
                _realSubject = new RealSubject();
            }
            _realSubject.Request();
        }
    }

}
