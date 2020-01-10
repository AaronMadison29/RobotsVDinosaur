using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsVsDinosaurs
{
    class Weapon
    {

        public string weaponType;
        public int attackPower;
        public double hitChance;
        Random ran = new Random();

        public Weapon()
        {
            hitChance = 100;
            attackPower = 0;
        }

        public bool swing()
        {
            if(ran.Next(101) > hitChance)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        
    }
}
