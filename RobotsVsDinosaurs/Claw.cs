using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsVsDinosaurs
{
    class Claw : Weapon
    {
        public Claw(string weaponType) : base(weaponType)
        {
            weaponType = "Claw";
            powerLevel = 9;
        }
    }
}
