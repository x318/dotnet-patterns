using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab4
{
    interface IChat
    {
        void SendMessage(string message, User user);
        void AppendUser(User user);
    }

    class ChatMediator : IChat
    {
        private List<User> _users;
        public ChatMediator() => _users = new List<User>();
        public void AppendUser(User user) => _users.Add(user);
        public void SendMessage(string message, User me)
        {
            _users.Where(user => user != me)
                 .ToList()
                 .ForEach(e => e.PrintMessage(message));
           Console.WriteLine("====");
        }
    }

    class User
    {
        private IChat _chatroom;
        private string _nickname;
        public string Nickname => _nickname;
        public User(IChat chat, string nick)
        {
            _chatroom = chat;
            _nickname = nick;
        }

        public void SendMessage(string text) { _chatroom.SendMessage(text, this); }
        public void PrintMessage(string text) { Console.WriteLine($"{_nickname}: {text}"); }
    }
}
