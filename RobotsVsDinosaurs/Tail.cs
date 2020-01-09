using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsVsDinosaurs
{
    class Tail : Weapon
    {
        public Tail(string weaponType) : base(weaponType)
        {
            weaponType = "Tail";
            powerLevel = 6;
        }
    }
}
