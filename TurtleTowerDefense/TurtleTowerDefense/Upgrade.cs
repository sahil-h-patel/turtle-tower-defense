using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleTowerDefense
{
    

    internal class Upgrade
    {
        private Upgrade nextUpgrade;
        private Upgrade previousUpgrade;
        private int cost;

        public Upgrade()
        {

        }

        public Upgrade NextUpgrade { get { return nextUpgrade; } set { nextUpgrade = value; } }
        public Upgrade PreviousUpgrade { get { return previousUpgrade; } set { previousUpgrade = value; } }
    }

   
}
