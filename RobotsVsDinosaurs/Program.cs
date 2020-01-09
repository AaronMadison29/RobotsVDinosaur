using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotsVsDinosaurs
{
    class Program
    {
        static void Main(string[] args)
        {

            Herd dinoHerd = new Herd();
            Fleet roboFleet = new Fleet();


            Battlefield battlefield = new Battlefield(dinoHerd, roboFleet);

            battlefield.setPlayers(dinoHerd, roboFleet);

            battlefield.Battle();

        }
    }
}
