    using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;


namespace MohawkGame2D
{
   public class GoldCoin
    {
        public static Texture2D texture =
              Graphics.LoadTexture("../../../../Assets/Graphics/Coin.png");
        public static Vector2 position;

        //the coin is 23x23 pixels
        public GoldCoin(Vector2 position)
        {
            GoldCoin.position = position;
        }

        public static void Render(Vector2[] position)
        {
            Graphics.Draw(texture, position[1]);
            Graphics.Draw(texture, position[2]);
            Graphics.Draw(texture, position[3]);
        }
    }


}
