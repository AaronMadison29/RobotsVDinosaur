using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsVsDinosaurs
{
    class Tail : Weapon
    {
        public Tail()
        {
            weaponType = "Tail";
            attackPower = 6;
            hitChance = 85;
        }
    }
}
