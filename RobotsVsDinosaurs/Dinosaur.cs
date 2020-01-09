using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsVsDinosaurs
{

    //Has:
    //Type: the type of dinosaur in the current instance
    //Health: The hitpoints of the current instance
    //Attack Power: The amount of base damage a dinosaur does when it attacks
    //Weapon Type: The type of weapon the dinosaur is using to attack in this instance

    //Does:
    //Creates a dinosaur with given parameters
    //Can attack the given robot


    class Dinosaur
    {
        public string type;
        public int health = 50;
        int attackPower = 10;
        int energy;
        Weapon attack;
        Weapon[] attackArray = new Weapon[3];
        Weapon bite = new Weapon("Bite");
        Weapon claw = new Weapon("Claw");
        Weapon tail = new Weapon("Tail");
        Random random = new Random();


        public Dinosaur(string inputType,int inputEnergy)
        {
            type = inputType;
            energy = inputEnergy;
        }

        public void weaponSwap()
        {
            attackArray[0] = bite;
            attackArray[1] = claw;
            attackArray[2] = tail;

            attack = attackArray[random.Next(0, 2)];
        }

        public void Attack(Robot roboTarget)
        {
            weaponSwap();

            roboTarget.health -= attackPower + attack.powerLevel;
            Console.WriteLine("\n" + this.type + " attacked " + roboTarget.name + " with " + attack.weaponType + " for " + (attackPower + attack.powerLevel) + " damage.");
            if(roboTarget.health <= 0)
            {
                Console.WriteLine("\nKnockout!");
            }
            else
            {
                Console.WriteLine(roboTarget.name + " has " + roboTarget.health + " health remaining.\n");
            }

            
        }
        

        //public void dinoAttackSwap(string typeInput)
        //{
        //    Console.WriteLine("Weapon options:");
        //    foreach (string weapon in dinoWeapons)
        //    {
        //        Console.WriteLine(weapon);
        //    }
        //    Console.WriteLine("Choice: ");
        //    weaponType = Console.ReadLine();
        //}
    }
}
