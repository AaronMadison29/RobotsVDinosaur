using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsVsDinosaurs
{
    class Dinosaur : Fighter
    {
        Weapon[] attackArray = new Weapon[3];
        public Dinosaur(string inputName,int inputEnergy, int inputHealth, int inputAttackPower) : base(inputName, inputEnergy, inputHealth, inputAttackPower)
        {
            name = inputName;
            maxEnergy = inputEnergy;
            energy = maxEnergy;
            health = inputHealth;
            attackPower = inputAttackPower;
            weapon = new Weapon();

            Bite bite = new Bite();
            Claw claw = new Claw();
            Tail tail = new Tail();

            attackArray[0] = bite;
            attackArray[1] = claw;
            attackArray[2] = tail;

        }
        public override void WeaponSwap(bool player)
        {
            weapon = attackArray[random.Next(0, 3)];
        }
    }
}
