using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsVsDinosaurs
{
    class Axe : Weapon
    {

        public Axe(string weaponType) : base(weaponType)
        {
            weaponType = "Axe";
            powerLevel = 4;
        }
    }
}
