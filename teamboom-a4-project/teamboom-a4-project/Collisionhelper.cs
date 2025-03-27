using System;
using System.Numerics;
using System.Runtime.Intrinsics;


namespace MohawkGame2D
{
    public static class CollisionHelper
    {
        public static bool isColliding(Vector2 pos1,Vector2 size1,Vector2 pos2, Vector2 size2)
        {
            return (pos1.X < pos2.X + size2.X &&
                    pos1.X + size1.X > pos2.X &&
                    pos1.Y < pos2.Y + size2.Y &&
                    pos1.Y + size1.Y > pos2.Y );
        }
    }
}