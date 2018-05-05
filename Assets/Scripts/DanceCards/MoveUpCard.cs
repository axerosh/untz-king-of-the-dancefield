using UnityEngine;
using UnityEngine;

namespace UnityEngine
{
    public class MoveUpCard : DanceCard
    {

        public Point movePoint
        {
            get
            {
                return new Point(0, -1);
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
