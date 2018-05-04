using Directions;
using PointClass;

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
