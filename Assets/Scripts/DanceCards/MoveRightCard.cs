using UnityEngine;
using UnityEngine;

namespace UnityEngine
{
    public class MoveRightCard : DanceCard
    {

        public Point movePoint
        {
            get
            {
                return new Point(1, 0);
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