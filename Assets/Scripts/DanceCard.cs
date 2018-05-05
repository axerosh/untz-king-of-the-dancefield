﻿using Directions;
using PointClass;

namespace UnityEngine
{
    public interface DanceCard
    {
        Direction direction
        {
            get;
        }

        //Relative points from the player to apply damage to 
        Point[] damagePoints
        {
            get;
        }

        float damage
        {
            get;
        }
    }
}
    
