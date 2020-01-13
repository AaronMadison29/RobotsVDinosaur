using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsVsDinosaurs
{
    class Herd : FighterGroup
    {
        public new static List<Fighter> group = new List<Fighter>();


        public Herd() : base(group)
        {
            Dinosaur dinoOne = new Dinosaur("TRex", 2, 100, 3);
            Dinosaur dinoTwo = new Dinosaur("Raptor", 4, 100, 3);
            Dinosaur dinoThree = new Dinosaur("Turkey", 6, 100, 3);

            group.Add(dinoOne);
            group.Add(dinoTwo);
            group.Add(dinoThree);
        }
    }
}
