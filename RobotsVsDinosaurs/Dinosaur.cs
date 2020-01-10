using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsVsDinosaurs
{
    class Dinosaur
    {
        public string type;
        public int health = 50;
        public int maxEnergy;
        public int energy;
        public bool attacker = false;
        int attackPower = 10;
        Weapon attack;
        Weapon[] attackArray = new Weapon[3];
        Random random = new Random();


        public Dinosaur(string inputType,int inputEnergy)
        {
            type = inputType;
            maxEnergy = inputEnergy;
            energy = maxEnergy;

            Bite bite = new Bite();
            Claw claw = new Claw();
            Tail tail = new Tail();

            attackArray[0] = bite;
            attackArray[1] = claw;
            attackArray[2] = tail;

            attack = new Weapon();
        }

        public void weaponSwap()
        {
            attack = attackArray[random.Next(0, 3)];
        }

        


        public void Attack(Robot roboTarget)
        {
            weaponSwap();
            attacker = true;
            energy--;
            
            if (attack.swing())
            {
                roboTarget.health -= attackPower + attack.attackPower;
                Console.WriteLine("\n" + this.type + " hit " + roboTarget.name + " with " + attack.weaponType + " for " + (attackPower + attack.attackPower) + " damage.");
                if (roboTarget.health <= 0)
                {
                    Console.WriteLine("\nKnockout!");
                }
                else
                {
                    Console.WriteLine(roboTarget.name + " has " + roboTarget.health + " health remaining.\n");
                }
            }
            else
            {
                Console.WriteLine("\n" + type + " attacked " + roboTarget.name + " with " + attack.weaponType + " but missed!");
            }

            
        }
    }
}
