using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsVsDinosaurs
{
    class Herd : FighterGroups
    {
        public new static List<Fighter> group = new List<Fighter>();


        public Herd() : base(group)
        {
            Fighter dinoOne = new Dinosaur("TRex", 2, 50, 3, true);
            Fighter dinoTwo = new Dinosaur("Raptor", 4, 50, 3, true);
            Fighter dinoThree = new Dinosaur("Turkey", 6, 50, 3, true);

            group.Add(dinoOne);
            group.Add(dinoTwo);
            group.Add(dinoThree);


        }
    }
}
