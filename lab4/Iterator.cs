using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab4
{
    class SimpleSet<T> : IEnumerable<T>
    {
        private readonly T[] _storage;
        public SimpleSet(IEnumerable<T> args) => _storage = args.ToArray();

        public IEnumerator<T> GetEnumerator()
        {
            var len = _storage.Length;
            for (int i = 0; i < len; i++)
                yield return _storage[i];
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
