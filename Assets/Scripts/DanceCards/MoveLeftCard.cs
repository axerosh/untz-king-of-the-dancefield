using UnityEngine;
using UnityEngine;

namespace UnityEngine
{
    public class MoveLeftCard : DanceCard
    {

        public Direction direction
        {
            get
            {
                return Direction.LEFT;
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