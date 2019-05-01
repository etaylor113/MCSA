using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prep.NullPractice
{
    public class NullTest
    {
        public static void Start()
        {
            var player1 = new PlayerCharacter(new DiamondSkinDefense())
            {
                Name = "Evan"
            };

            var player2 = new PlayerCharacter(new IronBonesDefense())
            {
                Name = "Mike"
            };

            var player3 = new PlayerCharacter(SpecialDefense.Null)
            {
                Name = "John"
            };

            player1.Hit(10);
            player2.Hit(10);
            player3.Hit(10);

            Console.ReadLine();
        }
    }
}
