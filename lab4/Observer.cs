using System;
using System.Collections.Generic;
using System.Text;

namespace lab4
{
    interface IObserver
    {
        void Update(Object ob);
    }

    interface IObservable
    {
        void RegisterObserver(IObserver o);
        void RemoveObserver(IObserver o);
        void NotifyObservers();
    }

    class DataStorage : IObservable
    {
        private StorageInfo _storageInfo; 

        private List<IObserver> _observers;
        public DataStorage()
        {
            _observers = new List<IObserver>();
            _storageInfo = new StorageInfo();
        }
        public void RegisterObserver(IObserver o)
        {
            _observers.Add(o);
        }

        public void RemoveObserver(IObserver o)
        {
            _observers.Remove(o);
        }

        public void NotifyObservers()
        {
            foreach (IObserver o in _observers)
            {
                o.Update(_storageInfo);
            }
        }

        public void Market()//торги
        {
            Random rnd = new Random();
            _storageInfo.USD = rnd.Next(20, 40);
            _storageInfo.Euro = rnd.Next(30, 50);
            NotifyObservers();
        }
    }

    class StorageInfo
    {
        public int USD { get; set; }
        public int Euro { get; set; }
    }

    class Broker : IObserver
    {
        private IObservable _observable;
        public string Name { get; set; }
        public Broker(string name, IObservable obs)
        {
            Name = name;
            _observable = obs;
            _observable.RegisterObserver(this);
        }
        public void Update(object ob)
        {
            StorageInfo sInfo = (StorageInfo)ob;

            if (sInfo.USD > 30)
                Console.WriteLine("Брокер {0} продает доллары;  Курс доллара: {1}", this.Name, sInfo.USD);
            else
                Console.WriteLine("Брокер {0} покупает доллары;  Курс доллара: {1}", this.Name, sInfo.USD);
        }
        public void StopTrade()
        {
            _observable.RemoveObserver(this);
            _observable = null;
        }
    }

    class Bank : IObserver
    {
        public string Name { get; set; }
        IObservable dataStor;
        public Bank(string name, IObservable obs)
        {
            this.Name = name;
            dataStor = obs;
            dataStor.RegisterObserver(this);
        }
        public void Update(object ob)
        {
            StorageInfo sInfo = (StorageInfo)ob;

            if (sInfo.Euro > 40)
                Console.WriteLine("Банк {0} продает евро;  Курс евро: {1}", this.Name, sInfo.Euro);
            else
                Console.WriteLine("Банк {0} покупает евро;  Курс евро: {1}", this.Name, sInfo.Euro);
        }
    }
}
