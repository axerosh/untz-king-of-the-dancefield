using Directions;
using System.Drawing;

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
