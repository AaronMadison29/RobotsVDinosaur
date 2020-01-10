using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsVsDinosaurs
{
    class Axe : Weapon
    {

        public Axe() : base()
        {
            weaponType = "Axe";
            attackPower = 4;
            hitChance = 75;
        }
    }
}
