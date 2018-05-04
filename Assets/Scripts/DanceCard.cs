using Directions;
using PointClass;

public interface DanceCard
{
    Direction direction
    {
        get;
        set;
    }

    Point[] damagePoints
    {
        get;
        set;
    }
}
