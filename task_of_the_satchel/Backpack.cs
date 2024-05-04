using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_of_the_satchel
{
    public class Backpack : IEnumerable<Thing>
    {
        public List<Thing> Things { get; set; } = new List<Thing>();
        public decimal TotalPrice { get; set; }
        public uint TotalWeight { get; set; }

        public void Add(Thing thing)
        {
            TotalPrice += thing.Price;
            TotalWeight += thing.Weight;
            Things.Add(thing);
        }

        public IEnumerator<Thing> GetEnumerator() => Things.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
