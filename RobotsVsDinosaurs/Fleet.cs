using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsVsDinosaurs
{
    class Fleet : FighterGroups
    {

        public new static List<Fighter> group = new List<Fighter>();

        public Fleet() : base(group)
        {
            Fighter roboOne = new Robot("Bob", 1, 100, 5, false);
            Fighter roboTwo = new Robot("Frank", 3, 100, 5, false);
            Fighter roboThree = new Robot("Jim", 5, 100, 5, false);



            group.Add(roboOne);
            group.Add(roboTwo);
            group.Add(roboThree);
        }

    }
}
