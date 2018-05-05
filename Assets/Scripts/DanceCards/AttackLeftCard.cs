﻿namespace UnityEngine
{
    public class AttackLeftCard : DanceCard
    {
        public Point movePoint
        {
            get
            {
                return new Point(0,0 );
            }
        }

        public DanceAnim anim
        {
            get
            {
                return DanceAnim.ATTACK_LEFT;
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