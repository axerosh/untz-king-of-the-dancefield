namespace UnityEngine
{
    public class AttackDownCard : DanceCard
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
                return DanceAnim.ATTACK_DOWN;
            }
        }

        Point[] DanceCard.damagePoints
        {
            get
            {
                return new Point[] { new Point(0, 1) };
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