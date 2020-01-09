﻿using System;
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
        int powerLevel;
        int attackPower = 5;
        List<Weapon> roboWeapons = new List<Weapon>();
        Random random = new Random();
        Weapon weapon;
        Weapon axe;
        Weapon sword;
        Weapon gun;


        public Robot(string inputName, int inputPowerLevel)
        {
            axe = new Axe("Axe");
            sword = new Sword("Sword");
            weapon = new Weapon("Fist");
            gun = new Gun("Gun");

            name = inputName;
            powerLevel = inputPowerLevel;


        }

        public void weaponSwap(bool player)
        {
            roboWeapons.Add(axe);
            roboWeapons.Add(sword);
            roboWeapons.Add(gun);
            
            if(!player)
            {
                weapon = roboWeapons[random.Next(0, 3)];
                return;
            }

            Console.WriteLine("Choose a weapon: ");
            Console.WriteLine("1: Axe");
            Console.WriteLine("2: Sword");
            Console.WriteLine("3: Gun");
            string weaponName = Console.ReadLine();

            switch (weaponName)
            {
                case "1":
                    weapon = roboWeapons[0];
                    Console.WriteLine("\nBob switched to his " + weapon.weaponType);
                    break;
                case "2":
                    weapon = roboWeapons[1];
                    Console.WriteLine("\nBob switched to his " + weapon.weaponType);
                    break;
                case "3":
                    weapon = roboWeapons[2];
                    Console.WriteLine("\nBob switched to his " + weapon.weaponType);
                    break;
                default:
                    break;
            }
                
        }

        public void Attack(Dinosaur dinoTarget)
        {

            dinoTarget.health -= attackPower + weapon.powerLevel;
            Console.WriteLine("\n" + name + " attacked " + dinoTarget.type + " with " + weapon.weaponType + " for " + (attackPower + weapon.powerLevel) + " damage.");
            if (dinoTarget.health <= 0)
            {
                Console.WriteLine("Knockout!");
            }
            else
            {
                Console.WriteLine(dinoTarget.type + " has " + dinoTarget.health + " health remaining.\n");
            }
        }
    }
}
