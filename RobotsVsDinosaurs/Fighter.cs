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
        public int health;
        public int attackPower;
        public bool attacker;
        public bool isDino;
        public Weapon weapon;

        public Random random = new Random();

        public Fighter(string inputName, int inputEnergy, int inputHealth, int inputAttackPower, bool isDinoIn)
        {
            name = inputName;
            maxEnergy = inputEnergy;
            energy = maxEnergy;
            health = inputHealth;
            attackPower = inputAttackPower;
            isDino = isDinoIn;
        }

        public virtual void Attack(Fighter fighterTarget, Fighter fighter)
        {

        }

        public virtual void Attack(Fighter fighterTarget, bool player)
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
