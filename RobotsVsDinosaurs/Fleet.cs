using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsVsDinosaurs
{
    class Fleet : FighterGroup
    {

        public new static List<Fighter> group = new List<Fighter>();

        public Fleet() : base(group)
        {
            Robot roboOne = new Robot("Bob", 1, 100, 5);
            Robot roboTwo = new Robot("Frank", 3, 100, 5);
            Robot roboThree = new Robot("Jim", 15, 100, 5);

            group.Add(roboOne);
            group.Add(roboTwo);
            group.Add(roboThree);
        }

    }
}
