using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsVsDinosaurs
{
    class Robot
    {
        public string name;
        public int health = 100;
        public int powerLevel = 5;
        public int maxPower;
        public bool attacker = false;
        int attackPower = 5;
        List<Weapon> roboWeapons = new List<Weapon>();
        Random random = new Random();
        Weapon weapon;


        public Robot(string inputName, int inputPowerLevel)
        {
            name = inputName;
            maxPower = inputPowerLevel;
            powerLevel = maxPower;

            Axe axe = new Axe();
            Sword sword = new Sword();
            Gun gun = new Gun();

            roboWeapons.Add(axe);
            roboWeapons.Add(sword);
            roboWeapons.Add(gun);

            weapon = new Fist();
        }


        public void weaponSwap(bool player)
        {
            
            
            if(!player)
            {
                weapon = roboWeapons[random.Next(0, 3)];
                return;
            }
            else
            {
                Console.WriteLine("\nWould you like to use a different weapon?(y/n)");
                string choice = Console.ReadLine();
                if (choice == "y")
                {

                    Console.WriteLine("\nChoose a weapon: ");
                    foreach (Weapon weapon in roboWeapons)
                    {
                        Console.WriteLine("-" + weapon.weaponType + "-");
                    }
                    string weaponName = Console.ReadLine();

                    foreach(Weapon weapon in roboWeapons)
                    {
                        if(weaponName.ToLower() == weapon.weaponType.ToLower())
                        {
                            this.weapon = weapon;
                            Console.WriteLine("\nBob switched to his " + weapon.weaponType);
                            break;
                        }
                    }
                }
            }   
        }

        public void Attack(Dinosaur dinoTarget, bool player)
        {
            weaponSwap(player);
            attacker = true;
            powerLevel--;

            if (weapon.swing())
            {
                int damage = attackPower + random.Next(1, weapon.attackPower + 1);
                dinoTarget.health -= attackPower + damage;
                Console.WriteLine("\n" + name + " hit " + dinoTarget.type + " with his " + weapon.weaponType + " for " + damage + " damage.");
                if (dinoTarget.health <= 0)
                {
                    Console.WriteLine("Knockout!");
                }
                else
                {
                    Console.WriteLine(dinoTarget.type + " has " + dinoTarget.health + " health remaining.\n");
                }
            }
            else
            {
                Console.WriteLine("\n" + name + " attacked " + dinoTarget.type + " with his " + weapon.weaponType + " but missed!");
            }
            
        }
    }
}
