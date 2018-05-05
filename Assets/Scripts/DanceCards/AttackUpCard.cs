namespace UnityEngine
{
    public class AttackUpCard : DanceCard
    {
        public Point movePoint
        {
            get
            {
                return new Point(0, 0);
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
                return new Point[] { new Point(0, -1) };
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
}