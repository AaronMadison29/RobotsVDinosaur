using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsVsDinosaurs
{
    class Sword : Weapon
    {
        public Sword()
        {
            weaponType = "Sword";
            attackPower = 3;
            hitChance = 85;
        }
    }
}
