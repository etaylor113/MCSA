using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prep.NullPractice
{
    class PlayerDisplayer
    {
        public static void Write(PlayerCharacter player)
        {
            if (string.IsNullOrWhiteSpace(player.Name))
                Console.WriteLine("Player name was blank");
            else
                Console.WriteLine(player.Name);

            if (player.DaysSinceLastLogin == null)
                Console.WriteLine("No value for days since last login");
            else
                Console.WriteLine(player.DaysSinceLastLogin);

            if (player.DateOfBirth == null)
                Console.WriteLine("No DOB specified");
            else
                Console.WriteLine(player.DateOfBirth);

            if (player.IsNoob == null)
                Console.WriteLine("Newbie status is unknown");
            else if (player.IsNoob == true)
                Console.WriteLine("Player is a noob");
             else
                Console.WriteLine("Player is not a noob");



        }

    }
}
