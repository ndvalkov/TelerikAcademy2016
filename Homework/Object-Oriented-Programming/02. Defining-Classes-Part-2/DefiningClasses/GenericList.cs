using System;
using System.Diagnostics;

namespace DefiningClasses
{
    class GenericList<T>
    {
        private T[] _items;
        private int _count;
        private int _capacity;

        public GenericList(int capacity)
        {
            _capacity = capacity;
            _items = new T[Capacity];
        }

        public int Capacity
        {
            get { return _capacity; }
        }

        public int Count
        {
            get { return _count; }
        }

        // accessing by index
        public T this[int index]
        {
            get { return _items[index]; }
        }

        // adding element
        public void Add(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("List item");
            }

            if (CheckFull())
            {
                Resize();
            }

            _items[_count++] = item;
        }

        // removing element by index
        public void RemoveAt(int index)
        {
            if (index < 0 || index > _count - 1)
            {
                throw new IndexOutOfRangeException("The index is outside the boundaries of the list");
            }

            for (int i = index + 1; i < _count; i++)
            {
                _items[i - 1] = _items[i];
            }

            _items[_count - 1] = default(T);
            _count--;
        }

        // insert at position
        public void Insert(T item, int pos)
        {
            if (item == null)
            {
                throw new ArgumentNullException("List item");
            }

            if (pos < 0 || pos > _count - 1)
            {
                throw new IndexOutOfRangeException("The position is outside the boundaries of the list");
            }

            for (int i = _count - 1; i >= pos; i--)
            {
                _items[i + 1] = _items[i];
            }

            _items[pos] = item;
            _count++;
        }

        // clearing
        public void Clear()
        {
            _items = new T[_capacity];
            _count = 0;
        }

        // find element by value
        public int IndexOf(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("List item");
            }

            for (int i = 0; i < _items.Length; i++)
            {
                if (item.Equals(_items[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        private bool CheckFull()
        {
            if (_count == _capacity)
            {
                return true;
            }

            return false;
        }

        private void Resize()
        {
            _capacity *= 2;
            T[] items = new T[_capacity];

            for (int i = 0; i < _count; i++)
            {
                items[i] = _items[i];
            }

            _items = items;
        }

        public T Max<T>() where T : struct, IComparable<T>
        {
            if (_count == 0)
            {
                throw new InvalidOperationException("Cannot find max value of an empty list");
            }

            T max = (T)(_items[0] as IComparable<T>);

            for (int i = 1; i < _items.Length; i++)
            {
                IComparable<T> item = _items[i] as IComparable<T>;
                if (item.CompareTo(max) > 0)
                {
                    max = (T) item;
                }
            }
                
            return max;
        }

        public T Min<T>() where T : struct, IComparable<T>
        {
            if (_count == 0)
            {
                throw new InvalidOperationException("Cannot find min value of an empty list");
            }

            T min = (T)(_items[0] as IComparable<T>);

            for (int i = 1; i < _items.Length; i++)
            {
                IComparable<T> item = _items[i] as IComparable<T>;
                if (item.CompareTo(min) < 0)
                {
                    min = (T)item;
                }
            }

            return min;
        }

        public override string ToString()
        {
            return string.Join(", ", _items);
        }
    }
}