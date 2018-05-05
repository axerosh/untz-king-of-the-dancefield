﻿namespace UnityEngine
{
    public class AttackRightCard : DanceCard
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
                return new Point[] { new Point(1, 0) };
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