using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsVsDinosaurs
{
    class Bite : Weapon
    {
        public Bite(string weaponType) : base(weaponType)
        {
            weaponType = "Bite";
            powerLevel = 10;
        }
    }
}
