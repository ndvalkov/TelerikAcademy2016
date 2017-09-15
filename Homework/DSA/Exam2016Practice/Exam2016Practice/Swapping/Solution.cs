using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swapping
{
    class Solution
    {
        static void Main()
        {
            var N = int.Parse(Console.ReadLine());
            var sequence = Console.ReadLine();
            var nums = new DoublyLinkedNode<int>[N + 1];
            var list = new DoublyLinkedList<int>();

            for (int i = 1; i <= N; i++)
            {
                var node = new DoublyLinkedNode<int>(i);
                list.PushBack(node);
                nums[i] = node;
            }

            var seq = sequence.Split(' ').ToList();
            seq.ForEach((x) =>
            {
                // var res = string.Join(" ", list);
                var number = int.Parse(x);
                var nodeToSwap = nums[number];

                var first = list.First;
                var last = list.Last;
                var newLast = nodeToSwap.Prev;
                var newFirst = nodeToSwap.Next;

                nodeToSwap.Dettach();
                last.Link(nodeToSwap);
                nodeToSwap.Link(first);

                list.First = newFirst;
                list.First = newFirst;

            });

            Console.WriteLine(string.Join(" ", list));

        }

        public class DoublyLinkedNode<T>
        {
            public T Value { get; set; }
            public DoublyLinkedNode<T> Prev { get; internal set; }
            public DoublyLinkedNode<T> Next { get; internal set; }

            internal DoublyLinkedNode(T value)
            {
                Value = value;
                Prev = null;
                Next = null;
            }

            public void Link(DoublyLinkedNode<T> node)
            {
                Next = node;
                node.Prev = this;
            }

            public void Dettach()
            {
                if (this.Prev != null)
                {
                    this.Prev.Next = null;
                }

                if (this.Next != null)
                {
                    this.Next.Prev = null;
                }

                this.Prev = null;
                this.Next = null;
            }
        }

        public class DoublyLinkedList<T> : IEnumerable<T>
        {
            public DoublyLinkedList()
            {
                First = null;
                Last = null;
                Size = 0;
            }

            public int Size { get; private set; }

            public DoublyLinkedNode<T> First { get; set; }

            public DoublyLinkedNode<T> Last { get; set; }

            public void PushFront(DoublyLinkedNode<T> value)
            {
                if (First == null)
                {
                    ++Size;
                    First = Last = value;
                    return;
                }
                InsertBefore(First, value);
            }

            public void PushFront(T value)
            {
                if (First == null)
                {
                    ++Size;
                    First = Last = new DoublyLinkedNode<T>(value);
                    return;
                }
                InsertBefore(First, value);
            }

            public void InsertBefore(DoublyLinkedNode<T> node, DoublyLinkedNode<T> value)
            {
                ++Size;

                var newNode = value;
                newNode.Next = node;
                newNode.Prev = node.Prev;

                newNode.Next.Prev = newNode;
                if (newNode.Prev != null)
                {
                    newNode.Prev.Next = newNode;
                }
                else
                {
                    First = newNode;
                }
            }

            public void PushBack(DoublyLinkedNode<T> value)
            {
                if (Last == null)
                {
                    ++Size;
                    First = Last = value;
                    return;
                }
                InsertAfter(Last, value);
            }

            public void InsertAfter(DoublyLinkedNode<T> node, DoublyLinkedNode<T> value)
            {
                ++Size;

                var newNode = value;
                newNode.Prev = node;
                newNode.Next = node.Next;

                newNode.Prev.Next = newNode;
                if (newNode.Next != null)
                {
                    newNode.Next.Prev = newNode;
                }
                else
                {
                    Last = newNode;
                }
            }

            public void PushBack(T value)
            {
                if (Last == null)
                {
                    ++Size;
                    First = Last = new DoublyLinkedNode<T>(value);
                    return;
                }
                InsertAfter(Last, value);
            }

            public void InsertBefore(DoublyLinkedNode<T> node, T value)
            {
                ++Size;

                var newNode = new DoublyLinkedNode<T>(value);
                newNode.Next = node;
                newNode.Prev = node.Prev;

                newNode.Next.Prev = newNode;
                if (newNode.Prev != null)
                {
                    newNode.Prev.Next = newNode;
                }
                else
                {
                    First = newNode;
                }
            }

            public void InsertAfter(DoublyLinkedNode<T> node, T value)
            {
                ++Size;

                var newNode = new DoublyLinkedNode<T>(value);
                newNode.Prev = node;
                newNode.Next = node.Next;

                newNode.Prev.Next = newNode;
                if (newNode.Next != null)
                {
                    newNode.Next.Prev = newNode;
                }
                else
                {
                    Last = newNode;
                }
            }

            public void PopFront()
            {
                Remove(First);
            }

            public void PopBack()
            {
                Remove(Last);
            }

            public void Remove(DoublyLinkedNode<T> node)
            {
                --Size;

                if (node.Prev != null)
                {
                    node.Prev.Next = node.Next;
                }
                else
                {
                    First = node.Next;
                }

                if (node.Next != null)
                {
                    node.Next.Prev = node.Prev;
                }
                else
                {
                    Last = node.Prev;
                }
            }
        
            

            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }

            public IEnumerator<T> GetEnumerator()
            {
                if (Size != 0)
                {
                    yield return First.Value;
                    while (First.Next != null)
                    {
                        yield return First.Next.Value;
                        First = First.Next;
                    }
                }
            }
        }
    }
}
