using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prep
{
    public interface IRobot
    {
        void Walk();
        void ChargeBatteries();
    }

    class Robot : IRobot
    {
        public void Walk()
        {

        }

        public void ChargeBatteries()
        {

        }
    }

    class ServerRobot : Robot
    {
        public void ServeFood()
        {

        }

        public void GetFood()
        {

        }
    }

}
