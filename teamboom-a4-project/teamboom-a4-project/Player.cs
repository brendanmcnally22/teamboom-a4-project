using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MohawkGame2D
{
    public class Player
    {
        //variables here
        public Vector2 plPosition = new Vector2(24, 24);
        public Vector2 plVelocity;
        public float plGravSpeed = 1000;
        public bool isJumping = false;


        public void Render(Vector2 position, Vector2 velocity, float gravity)
        {
            //replace draw with asset loading here
            Draw.FillColor = Color.Blue;
            Draw.Circle(position, 10);
        }

        public void Update()
        {
            plVelocity.Y += Time.DeltaTime * plGravSpeed;
            plPosition += plVelocity;
        }
    }
}
