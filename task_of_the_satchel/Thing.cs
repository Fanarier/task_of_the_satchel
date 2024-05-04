using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_of_the_satchel
{
    public class Thing
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public uint Weight { get; set; }

        public override string ToString() => Name;
    }
}
