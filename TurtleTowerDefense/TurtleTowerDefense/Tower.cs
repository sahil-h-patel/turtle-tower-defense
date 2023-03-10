﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurtleTowerDefense
{

    enum Type
    {
        BasicUnit,
        DebuffUnit,

    }

    internal class Tower : GameObject
    {

        // Fields
        private UpgradeTree upgradeTree;
        private double detectionRadius;
        private int spaceRadius;
        private int cost;

        public Tower(Texture2D image, Rectangle hitbox) 
            : base(image, hitbox)
        {
            
        }

    }
}
