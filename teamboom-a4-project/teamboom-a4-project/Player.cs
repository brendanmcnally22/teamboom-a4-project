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
        Vector2 plPosition = new Vector2(24, 24);
        Vector2 plVelocity;
        float plGravSpeed;
        public bool isJumping = false;


        public void Render()
        {
            //replace draw with asset loading here
            Draw.FillColor = Color.Blue;
            Draw.Circle(plPosition, 10);
        }

        public void Update()
        {
            plVelocity.Y += Time.DeltaTime * plGravSpeed;
            plPosition += plVelocity;
        }
    }
}
