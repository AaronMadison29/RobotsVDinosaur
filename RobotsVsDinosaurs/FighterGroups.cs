using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsVsDinosaurs
{
    class FighterGroups
    {
        public bool player;
        public List<Fighter> group = new List<Fighter>();



        public FighterGroups(List<Fighter> group)
        {
            this.group = group;
        }

        public void Recharge(Fighter fighterIn)
        {
            foreach (Fighter fighter in group)
            {
                if (!fighter.attacker)
                {
                    if (fighter.energy < fighter.maxEnergy)
                    {
                        fighter.energy++;
                    }
                }
                else
                {
                    fighterIn.attacker = false;
                }
            }
        }

        public string GetStats()
        {
            string stats = "";

            foreach (Fighter fighter in group)
            {
                if (fighter.health <= 0)
                {
                    stats = stats + fighter.name + ":KO ";
                }
                else
                {
                    stats = stats + fighter.name + ":" + fighter.health + "HP " + fighter.energy + "P ";
                }

            }

            return stats;
        }

        public bool CheckHealth(Fighter fighterIn)
        {
            if (fighterIn.health <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckEnergy(Fighter fighterIn)
        {
            if (fighterIn.energy <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public virtual void AttackSequence(FighterGroups fighters)
        {

        }
    }
}
