﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsVsDinosaurs
{
    class Robot : Fighter
    {
        List<Weapon> roboWeapons = new List<Weapon>();


        public Robot(string inputName, int inputEnergy, int inputHealth, int inputAttackPower, bool isDinoIn) : base(inputName, inputEnergy, inputHealth, inputAttackPower, isDinoIn)
        {
            name = inputName;
            maxEnergy = inputEnergy;
            energy = maxEnergy;
            health = inputHealth;
            attackPower = inputAttackPower;
            weapon = new Fist();

            Axe axe = new Axe();
            Sword sword = new Sword();
            Gun gun = new Gun();

            roboWeapons.Add(axe);
            roboWeapons.Add(sword);
            roboWeapons.Add(gun);


        }


        public override void WeaponSwap(bool player)
        {
            
            
            if(!player)
            {
                weapon = roboWeapons[random.Next(0, 3)];
                return;
            }
            else
            {
                bool running = true;
                Console.WriteLine("\nWould you like to use a different weapon?(y/n)");
                string choice = Console.ReadLine();
                if (choice == "y")
                {
                    do
                    {
                        Console.WriteLine("\nChoose a weapon: ");
                        foreach (Weapon weapon in roboWeapons)
                        {
                            Console.WriteLine("-" + weapon.weaponType + "-");
                        }
                        string weaponName = Console.ReadLine();


                        foreach (Weapon weapon in roboWeapons)
                        {
                            if (weaponName.ToLower() == weapon.weaponType.ToLower())
                            {
                                this.weapon = weapon;
                                Console.WriteLine("\nBob switched to his " + weapon.weaponType);
                                running = false;
                                break;
                            }
                        }
                        if (running)
                        {
                            Console.WriteLine("\nPlease enter a vaild option.");
                        }
                    } while (running);
                }

                
                
            }   
        }

        public override void Attack(Fighter fighterTarget, Fighter fighter, bool player)
        {
            WeaponSwap(player);
            fighter.attacker = true;
            fighter.energy--;

            if (weapon.swing())
            {
                int damage = attackPower + random.Next(1, weapon.attackPower + 1);
                fighterTarget.health -= damage;
                Console.WriteLine("\n" + name + " hit " + fighterTarget.name + " with his " + weapon.weaponType + " for " + damage + " damage.");
                if (fighterTarget.health <= 0)
                {
                    Console.WriteLine("Knockout!");
                }
                else
                {
                    Console.WriteLine(fighterTarget.name + " has " + fighterTarget.health + " health remaining.\n");
                }
            }
            else
            {
                Console.WriteLine("\n" + name + " attacked " + fighterTarget.name + " with his " + weapon.weaponType + " but missed!");
            }
            
        }
    }
}
