using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsVsDinosaurs
{
    class Sword : Weapon
    {
        public Sword(string weaponType) : base(weaponType)
        {
            weaponType = "Sword";
            powerLevel = 3;
        }
    }
}
