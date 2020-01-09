using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsVsDinosaurs
{
    class Gun : Weapon
    {
        public Gun(string weaponType) : base(weaponType)
        {
            weaponType = "Gun";
            powerLevel = 10;
        }
    }
}
