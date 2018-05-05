using UnityEngine;

namespace UnityEngine
{
    public interface DanceCard
    {
        Point movePoint
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
    
