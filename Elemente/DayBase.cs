using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_Code.Elemente
{
    public abstract class DayBase
    {
        public int Year;
        public int Day;
        public PartBase Part1 = new PartBase();
        public PartBase Part2 = new PartBase();

        public abstract void DoPart1();
        public abstract void DoPart2();
    }
}
