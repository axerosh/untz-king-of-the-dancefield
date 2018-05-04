using Directions;
using PointClass;

public class MoveUpCard : DanceCard {

    public Direction direction
    {
        get
        {
            return Direction.UP;
        }

    }

    Point[] DanceCard.damagePoints
    {
        get
        {
            return new Point[0];
        }
    }

    float DanceCard.damage
    {
        get
        {
            return 0;
        }
    }
}
