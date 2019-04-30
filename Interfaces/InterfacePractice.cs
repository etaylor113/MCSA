using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prep.Interfaces
{
    class InterfacePractice
    {
        public InterfacePractice()
        {
            Run();
        }

        private void Run()
        {
            var square = new Square(5);
            DisplayPolygon("Square", square);

            var triangle = new Triangle(4);
            DisplayPolygon("Triangle", triangle);

        }

        public void DisplayPolygon(string polygonType, dynamic polygon)
        {
            Console.WriteLine("Shape: " + polygonType);



        }

    }
}
