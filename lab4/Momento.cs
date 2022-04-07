using System;
using System.Collections.Generic;
using System.Text;

namespace lab4
{

    class Player
    {
        private int _patrons = 10;
        private int _lives = 5;

        public void Shoot()
        {
            if (_patrons > 0)
            {
                _patrons--;
                Console.WriteLine("Производим выстрел. Осталось {0} патронов", _patrons);
            }
            else
                Console.WriteLine("Патронов больше нет");
        }
        public PlayerMemento SaveState()
        {
            Console.WriteLine("Сохранение игры. Параметры: {0} патронов, {1} жизней", _patrons, _lives);
            return new PlayerMemento(_patrons, _lives);
        }

        public void RestoreState(PlayerMemento memento)
        {
            this._patrons = memento.Patrons;
            this._lives = memento.Lives;
            Console.WriteLine("Восстановление игры. Параметры: {0} патронов, {1} жизней", _patrons, _lives);
        }
    }

    class PlayerMemento
    {
        public int Patrons { get; private set; }
        public int Lives { get; private set; }

        public PlayerMemento(int patrons, int lives)
        {
            this.Patrons = patrons;
            this.Lives = lives;
        }
    }

    class GameHistory
    {
        public Stack<PlayerMemento> History { get; private set; }
        public GameHistory()
        {
            History = new Stack<PlayerMemento>();
        }
    }

}
