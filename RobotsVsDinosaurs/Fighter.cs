using System;

namespace RobotsVsDinosaurs
{
    abstract class Fighter
    {

        public string name;
        public int maxEnergy;
        public int energy;
        public int health;
        public int attackPower;
        public bool attacker;
        public Weapon weapon;

        public Random random = new Random();

        public Fighter(string inputName, int inputEnergy, int inputHealth, int inputAttackPower)
        {
            name = inputName;
            maxEnergy = inputEnergy;
            energy = maxEnergy;
            health = inputHealth;
            attackPower = inputAttackPower;
        }

        public  void Attack(Fighter fighterTarget, bool player)
        {
            WeaponSwap(player);
            attacker = true;
            energy--;

            if (weapon.swing())
            {
                int damage = attackPower + random.Next(1, weapon.attackPower + 1);
                fighterTarget.health -= damage;
                Console.WriteLine("\n" + name + " hit " + fighterTarget.name + " with his " + weapon.weaponType + " for " + damage + " damage.");
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
                Console.WriteLine("\n" + name + " attacked " + fighterTarget.name + " with his " + weapon.weaponType + " but missed!");
            }


        }
        public abstract void WeaponSwap(bool player);

    }
}
