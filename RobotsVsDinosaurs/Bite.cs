using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsVsDinosaurs
{
    class Bite : Weapon
    {
        public Bite()
        {
            weaponType = "Bite";
            attackPower = 10;
            hitChance = 100;
        }
    }
}
