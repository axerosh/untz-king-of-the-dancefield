namespace UnityEngine
{
    public class AttackMoveRightCard : DanceCard
    {
        public Point movePoint
        {
            get
            {
                return new Point(2, 0);
            }
        }

        public DanceAnim anim
        {
            get
            {
                return DanceAnim.ATTACK_MOVE_RIGHT;
            }
        }

        Point[] DanceCard.damagePoints
        {
            get
            {
                return new Point[] { new Point(-1, 0) };
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