using System;
using System.Collections.Generic;
using System.Linq;

namespace KnapsackRosetta
{
    class Bag : IEnumerable<Bag.Item>
    {
        List<Item> items;
        const int MaxWeightAllowed = 10;

        public Bag()
        {
            this.items = new List<Item>();
        }

        void AddItem(Item i)
        {
            if ((this.TotalWeight + i.Weight) <= MaxWeightAllowed)
                this.items.Add(i);
        }

        public void Calculate(List<Item> items)
        {
            foreach (Item i in this.Sorte(items))
            {
                this.AddItem(i);
            }
        }

        List<Item> Sorte(List<Item> inputItems)
        {
            List<Item> choosenItems = new List<Item>();
            for (int i = 0; i < inputItems.Count; i++)
            {
                int j = -1;
                if (i == 0)
                {
                    choosenItems.Add(inputItems[i]);
                }
                if (i > 0)
                {
                    if (!this.RecursiveF(inputItems, choosenItems, i, choosenItems.Count - 1, false, ref j))
                    {
                        choosenItems.Add(inputItems[i]);
                    }
                }
            }
            return choosenItems;
        }

        bool RecursiveF(List<Item> knapsackItems, List<Item> choosenItems, int i, int lastBound, bool dec, ref int indxToAdd)
        {
            if (!(lastBound < 0))
            {
                if (knapsackItems[i].ResultWV < choosenItems[lastBound].ResultWV)
                {
                    indxToAdd = lastBound;
                }
                return this.RecursiveF(knapsackItems, choosenItems, i, lastBound - 1, true, ref indxToAdd);
            }
            if (indxToAdd > -1)
            {
                choosenItems.Insert(indxToAdd, knapsackItems[i]);
                return true;
            }
            return false;
        }

        #region IEnumerable<Item> Members
        IEnumerator<Item> IEnumerable<Item>.GetEnumerator()
        {
            foreach (Item i in this.items)
                yield return i;
        }
        #endregion

        #region IEnumerable Members
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.items.GetEnumerator();
        }
        #endregion

        public int TotalWeight
        {
            get
            {
                var sum = 0;
                foreach (Item i in this)
                {
                    sum += i.Weight;
                }
                return sum;
            }
        }

        public class Item
        {
            public string Name { get; set; }
            public int Weight { get; set; }
            public int Value { get; set; }
            public int ResultWV { get { return this.Weight - this.Value; } }
            public override string ToString()
            {
                return "Name : " + this.Name + "        Wieght : " + this.Weight + "       Value : " + this.Value + "     ResultWV : " + this.ResultWV;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Bag.Item> knapsackItems = new List<Bag.Item>();
            knapsackItems.Add(new Bag.Item() { Name = "Beer", Weight = 3, Value = 2 });
            knapsackItems.Add(new Bag.Item() { Name = "Vodka", Weight = 8, Value = 12 });
            knapsackItems.Add(new Bag.Item() { Name = "Cheese", Weight = 4, Value = 2 });
            knapsackItems.Add(new Bag.Item() { Name = "Nuts", Weight = 1, Value = 4 });
            knapsackItems.Add(new Bag.Item() { Name = "Ham", Weight = 2, Value = 3 });
            knapsackItems.Add(new Bag.Item() { Name = "Whiskey", Weight = 8, Value = 13 });

            Bag b = new Bag();
            b.Calculate(knapsackItems);
            b.All(x => { Console.WriteLine(x); return true; });
            Console.WriteLine(b.Sum(x => x.Weight));
            Console.WriteLine(b.Sum(x => x.Value));
            Console.ReadKey();
        }
    }
}
