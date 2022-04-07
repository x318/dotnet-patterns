using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace lab4
{
    class Account
    {
        public string AccountOwner { get; set; }
        public int Balance { get; set; }

        public Account(string accountOwner, int balance)
        {
            this.Balance = balance;
            this.AccountOwner = accountOwner;
        }

        public void Info() => WriteLine($"{AccountOwner}: ${Balance}");

    }

    interface IOperation
    {
        void Execute();
        public bool IsComplete { get; }
    }

    class Deposit : IOperation
    {
        private readonly Account _account;
        private readonly int _money;
        private bool _isComplete;
        public bool IsComplete { get => _isComplete; }

        public Deposit(Account account, int money)
        {
            this._account = account;
            this._money = money;
            _isComplete = false;
        }

        public void Execute()
        {
            _account.Balance += _money;
            _isComplete = true;
        }
    }



    class Withdraw : IOperation
    {
        private readonly Account _account;
        private readonly int _money;
        private bool _isComplete;
        public bool IsComplete { get => _isComplete; }

        public Withdraw(Account account, int money)
        {
            this._account = account;
            this._money = money;
            _isComplete = false;
        }

        public void Execute()
        {
            if (_account.Balance - _money < 0) return;
            _account.Balance -= _money;
            _isComplete = true;
        }
    }
}
