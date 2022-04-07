using System;

namespace lab2
{
    class ArrayRandomInt
    {
        private int[] _arr;

        public ArrayRandomInt(int count, int min, int max)
        {
            Random rnd = new();

            _arr = new int [count];
            for (int i = 0; i < count; i++)
            {
                _arr[i] = rnd.Next(min, max + 1);
            }
        }

        public int[] GetArrayInt() => _arr;
    }

    class ArrayRandomChar
    {
        private char[] _arr;

        public ArrayRandomChar(int count)
        {
            Random rnd = new();

            _arr = new char[count];
            for (int i = 0; i < count; i++)
            {
                _arr[i] = (char)(rnd.Next((int)('Z' - 'A' + 1)) + (int)'A');
            }
        }

        public char[] GetArrayChar() => _arr;
    }

    class Builder
    {
        virtual public void BuildArrayInt(int count, int min, int max) {}
        virtual public void BuildArrayChar(int count) {}

        virtual public ArrayRandomInt GetResInt() => null;
        virtual public ArrayRandomChar GetResChar() => null;
    }

    class BuilderRandomInt : Builder
    {
        private ArrayRandomInt _arr;
        public override void BuildArrayInt(int count, int min, int max)
        {
            _arr = new ArrayRandomInt(count, min, max);
        }

        public override ArrayRandomInt GetResInt() => _arr;
    }

    class BuilderRandomChar : Builder
    {
        private ArrayRandomChar _arr;
        public override void BuildArrayChar(int count)
        {
            _arr = new ArrayRandomChar(count);
        }

        public override ArrayRandomChar GetResChar() => _arr;
    }

    class Director
    {
        private Builder _builder;

        public Director(Builder builder)
        {
            _builder = builder;
        }

        public void ConstructInt()
        {
            _builder.BuildArrayInt(10, 5, 15);
        }

        public void ConstructChar()
        {
            _builder.BuildArrayChar(15);
        }
    }
}
