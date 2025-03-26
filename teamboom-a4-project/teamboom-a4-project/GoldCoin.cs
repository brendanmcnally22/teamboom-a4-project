using System;
using System.Numerics;


namespace MohawkGame2D
{
    public class GoldCoin
    {
        // Coin Variables / Parameters 
        public Vector2 position;
        public bool collected = false;
        public Texture2D texture;
        public float width;
        public float height;

        public GoldCoin(Vector2 pos)
        {
            position = pos;
            texture = Graphics.LoadTexture("../../../../../Assets/Graphics/Coin.png");
            width = texture.Width;
            height = texture.Height;
        }

        public void renderCoin()
        {
            // Only want to render the coin if it hasn't been collected
        }
    }
}
