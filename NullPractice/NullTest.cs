using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prep.NullPractice
{
    public class NullTest
    {
        public NullTest()
        {
            Run();
        }

        public void Run()
        {
            var player = new PlayerCharacter();
            player.Name = "Evan";
            player.DaysSinceLastLogin = 12;


            PlayerDisplayer.Write(player);

            Console.ReadLine();
        }


       

    }
}
