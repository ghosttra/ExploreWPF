using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CarDealership
{
    class Car
    {
        private static int count = 0;
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string _Color { get; set; }
        public bool State { get; set; }
        public short Year { get; set; }

        public Car()
        {
            Id = ++count;
        }

        public override string ToString()
        {
            return $"{Name} ({Year}) {Price}$ | {_Color}";
        }
    }

}
