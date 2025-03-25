using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;


namespace MohawkGame2D
{
   public class GoldCoin
    {
        public Texture2D texture = Graphics.LoadTexture("../../../../../Assets/Graphics/GoldCoin.png");
        public Vector2 position;

        //the coin is 23x23 pixels
        public GoldCoin(Vector2 position)
        {
            this.position = position;
        }

        public void Render(Vector2 cameraOffset)
        {
            Graphics.Draw(texture, cameraOffset);
        }
    }


}
