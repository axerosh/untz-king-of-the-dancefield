namespace UnityEngine
{
    public class AttackAllCard : DanceCard
    {
        public Point movePoint
        {
            get
            {
                return new Point(0, 0);
            }
        }


        Point[] DanceCard.damagePoints
        {
            get
            {
                return new Point[] { new Point(-1, 0), new Point(-1, -1), new Point(0, -1), new Point(1, -1), new Point(1, 0), new Point(1, 1), new Point(0, 1), new Point(-1, 1) };
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