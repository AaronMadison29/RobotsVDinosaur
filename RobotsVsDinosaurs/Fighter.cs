using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsVsDinosaurs
{
    class Fighter
    {

        public string name;
        public int maxEnergy;
        public int energy;
        public bool attacker;
        public int health;
        int attackPower;

        public Fighter(string inputName, int inputEnergy, int inputHealth, int inputAttackPower)
        {
            name = inputName;
            maxEnergy = inputEnergy;
            energy = maxEnergy;
            health = inputHealth;
            attackPower = inputAttackPower;
        }

        public virtual void Attack(Fighter fighterTarget, Fighter fighter)
        {

        }

        public virtual void Attack(Fighter fighterTarget, Fighter fighter, bool player)
        {

        }

        public virtual void WeaponSwap(bool player)
        {

        }

        public virtual void WeaponSwap()
        {

        }
    }
}
