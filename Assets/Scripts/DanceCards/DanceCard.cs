using UnityEngine;

public enum DanceAnim
{
    IDLE = 0,
    ATTACK_RIGHT = 2,
    ATTACK_LEFT = 3,
    ATTACK_MOVE_RIGHT = 5,
    ATTACK_MOVE_LEFT = 4,
    SPIN = 1
};


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

        DanceAnim anim
        {
            get;
        }
    }
}
    
