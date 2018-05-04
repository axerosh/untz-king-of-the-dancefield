using Directions;
using PointClass;

public class MilkTheCowLeftCard : DanceCard {

    public Direction direction
    {
        get
        {
            return Direction.STAY;
        }

    }

    Point[] DanceCard.damagePoints
    {
        get
        {
            return new Point[] { new Point(1, 0) };
        }
    }

    float DanceCard.damage
    {
        get
        {
            return 1;
        }
    }
}
