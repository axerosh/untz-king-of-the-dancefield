namespace UnityEngine
{
    public class AttackMoveLeftCard : DanceCard
    {
        public Point movePoint
        {
            get
            {
                return new Point(-2, 0);
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