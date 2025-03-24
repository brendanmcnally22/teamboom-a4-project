using System;
using System.Numerics;


namespace MohawkGame2D
{
    class GoldCoin
    {
        public Vector2[] positions =
        {
            new Vector2(20, 10),
            new Vector2(300, 30),
            new Vector2(60, 1000),
            new Vector2(400, 400),
            new Vector2(200, 200),
            new Vector2(100, 100),
        };
        public Texture2D texture;


        static Texture2D Coin =
              Graphics.LoadTexture("../../../../Assets/Graphics/Coin.png");


        public void Render()
        {
            Graphics.Draw(texture, positions[0]);
            Graphics.Draw(texture, positions[1]);
            Graphics.Draw(texture, positions[2]);
            Graphics.Draw(texture, positions[3]);
            Graphics.Draw(texture, positions[4]);
            Graphics.Draw(texture, positions[5]);
        }
    }


}
