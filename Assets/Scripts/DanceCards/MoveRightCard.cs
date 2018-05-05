using Directions;
using PointClass;

namespace UnityEngine
{
    public class MoveRightCard : DanceCard
    {

        public Direction direction
        {
            get
            {
                return Direction.RIGHT;
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