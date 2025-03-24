using System;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;


namespace MohawkGame2D
{
    class GoldCoin
    {
        public Texture2D texture;
        public Vector2 position;
        
        static Texture2D Coin =
              Graphics.LoadTexture("../../../../Assets/Graphics/Coin.png");
                //the coin is 23x23 pixels
        public GoldCoin(Vector2 position)
        {
            this.position = position;
        }

        public void Render(Vector2[] position)
        {
            Graphics.Draw(texture, position[1]);
            Graphics.Draw(texture, position[2]);
            Graphics.Draw(texture, position[3]);
        }
    }


}
