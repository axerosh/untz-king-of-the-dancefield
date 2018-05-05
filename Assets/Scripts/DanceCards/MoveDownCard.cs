using PointClass;
using Directions;

namespace UnityEngine
{
    public class MoveDownCard : DanceCard
    {

        public Direction direction
        {
            get
            {
                return Direction.DOWN;
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

