﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            var enemy = new Orc(120);
            var aragon = new Aragorn();
            var sam = new Sam();
            var gendalf = new Gendalf();
            aragon.Next = sam;
            sam.Next = gendalf;
            aragon.MustWin(enemy);
            Console.WriteLine("\n");

            Account ac1 = new Account("jorick", 0);
            new Deposit(ac1, 199).Execute();
            ac1.Info();
            Console.WriteLine("\n");

            string roman = "MCMXXVIII";
            Context context = new Context(roman);
            List<Expression> tree = new List<Expression>();
            tree.Add(new ThousandExpression());
            tree.Add(new HundredExpression());
            tree.Add(new TenExpression());
            tree.Add(new OneExpression());
            foreach (Expression exp in tree)
            {
                exp.Interpret(context);
            }
            Console.WriteLine("{0} = {1}",
                roman, context.Output);
            Console.WriteLine("\n");

            SimpleSet<int> set = new SimpleSet<int>(Enumerable.Range(1, 10));
            foreach (var item in set) Console.Write($"{item} ");
            Console.WriteLine("\n");

            ChatMediator chat = new ChatMediator();
            var user1 = new User(chat, "user1");
            var user2 = new User(chat, "user2");
            var user3 = new User(chat, "user3");
            chat.AppendUser(user1);
            user1.SendMessage("Hey you");
            chat.AppendUser(user2);
            user2.SendMessage("Getting lonely, getting old");
            chat.AppendUser(user3);
            user3.SendMessage("Can you feel me?");
            user1.SendMessage("Hey you, standing in the aisles");
            Console.WriteLine("\n");

            Player player = new Player();
            player.Shoot();
            GameHistory game = new GameHistory();
            game.History.Push(player.SaveState());
            player.Shoot();
            player.RestoreState(game.History.Pop());
            player.Shoot();
            Console.WriteLine("\n");

            DataStorage dataStor = new DataStorage();
            Bank bank = new Bank("ЮнитБанк", dataStor);
            Broker broker = new Broker("Иван Иваныч", dataStor);
            dataStor.Market();
            broker.StopTrade();
            dataStor.Market();
            Console.WriteLine("\n");

            Water water = new Water(new LiquidWaterState());
            water.Heat();
            water.Frost();
            water.Frost();
            water.Frost();
            Console.WriteLine("\n");
        }
    }
}
