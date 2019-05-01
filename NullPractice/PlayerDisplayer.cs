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
            // Null coalesce that provides a default value
            int days1 = player.DaysSinceLastLogin ?? -1;

            // Ternary to return a default value if null
            int days2 = player.DaysSinceLastLogin.HasValue ? player.DaysSinceLastLogin.Value : -1;

            // If value == null, it returns a default value
            int days3 = player.DaysSinceLastLogin.GetValueOrDefault(-1);



            if (string.IsNullOrWhiteSpace(player.Name))
                Console.WriteLine("Player name was blank");
            else
                Console.WriteLine(player.Name);

            if (player.DaysSinceLastLogin.HasValue)
                Console.WriteLine(player.DaysSinceLastLogin.Value);
            else
                Console.WriteLine("No value for days since last login");

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
