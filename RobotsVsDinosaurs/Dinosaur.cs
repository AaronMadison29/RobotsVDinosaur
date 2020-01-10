using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsVsDinosaurs
{
    class Dinosaur : Fighter
    {
        public new string name;
        public new int health;
        public new int maxEnergy;
        public new int energy;
        public new bool attacker = false;
        int attackPower;
        Weapon attack;
        Weapon[] attackArray = new Weapon[3];
        Random random = new Random();


        public Dinosaur(string inputName,int inputEnergy, int inputHealth, int inputAttackPower, bool isDinoIn) : base(inputName, inputEnergy, inputHealth, inputAttackPower, isDinoIn)
        {
            name = inputName;
            maxEnergy = inputEnergy;
            energy = maxEnergy;
            health = inputHealth;
            attackPower = inputAttackPower;
            attack = new Weapon();

            Bite bite = new Bite();
            Claw claw = new Claw();
            Tail tail = new Tail();

            attackArray[0] = bite;
            attackArray[1] = claw;
            attackArray[2] = tail;

        }

        public override void WeaponSwap()
        {
            attack = attackArray[random.Next(0, 3)];
        }

        


        public override void Attack(Fighter fighterTarget, Fighter fighter)
        {
            WeaponSwap();
            fighter.attacker = true;
            fighter.energy--;

            if (attack.swing())
            {
                int damage = attackPower + random.Next(1, attack.attackPower + 1);
                fighterTarget.health -= damage;
                Console.WriteLine("\n" + this.name + " hit " + fighterTarget.name + " with his " + attack.weaponType + " for " + damage + " damage.");
                if (fighterTarget.health <= 0)
                {
                    Console.WriteLine("\nKnockout!");
                }
                else
                {
                    Console.WriteLine(fighterTarget.name + " has " + fighterTarget.health + " health remaining.\n");
                }
            }
            else
            {
                Console.WriteLine("\n" + name + " attacked " + fighterTarget.name + " with his " + attack.weaponType + " but missed!");
            }


        }
    }
}
