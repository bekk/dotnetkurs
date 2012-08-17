using System.Collections.Generic;
using System.Linq;

namespace Bekk.dotnetintro.TDD.Stack
{
    public class Stack<T>
    {
        private readonly List<T> _stack = new List<T>();

        public bool IsEmpty()
        {
            return _stack.Count == 0;
        }

        public void Push(T element)
        {
            _stack.Insert(0, element);
        }

        public T Pop()
        {
            var top = Top();
            _stack.Remove(top);

            return top;
        }

        public T Top()
        {
            return _stack.First();
        }
    }
}
