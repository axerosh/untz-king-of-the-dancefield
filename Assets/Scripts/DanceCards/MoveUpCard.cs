using Directions;
using PointClass;

namespace DanceCards
{
    public class MoveUpCard : DanceCard
    {

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
}
