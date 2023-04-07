using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleTowerDefense
{
    internal class UpgradeNode
    {
        private UpgradeNode right;
        private UpgradeNode left;
        private int level;
        private int count;

        UpgradeNode() { }

        public int Count { get { return count; } }

        public void AddUpgrade()
        {
            // Adds Upgrade based on some sorting algorithim
        }

        public void InsertUpgrade()
        {
            // Inserts an Upgrade
        }

        public UpgradeNode NextUpgrade(UpgradeNode current)
        {
            // Should return the Upgrade preceding the one that it is at
        }

        public UpgradeNode GetUpgrade(string name)
        {
            // Gets the upgrade based on name
        }

        private UpgradeNode Search(string name)
        {
            // Searches the Tree for a specifc upgrade with a name given        
        }
        

    }
}
