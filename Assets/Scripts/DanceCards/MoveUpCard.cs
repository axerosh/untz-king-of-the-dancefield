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

        public DanceAnim anim
        {
            get
            {
                return DanceAnim.IDLE;
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
