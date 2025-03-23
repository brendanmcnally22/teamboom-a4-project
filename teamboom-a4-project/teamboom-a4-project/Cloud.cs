using System;
using System.Numerics;


namespace MohawkGame2D
{
    class Cloud
    {
        public Vector2 position;
        public float width;
        public float height = 10;
        public Texture2D texture;

        static Texture2D cloudTexture1 =
            Graphics.LoadTexture("../../../../Assets/Graphics/Cloud1.png");

        static Texture2D cloudTexture2 =
            Graphics.LoadTexture("../../../../Assets/Graphics/Cloud2.png");

        public static Cloud cloudInstance1;
        public static Cloud cloudInstance2;

        static Cloud()
        {
            cloudInstance1 = new Cloud(96, cloudTexture1);
            cloudInstance2 = new Cloud(96, cloudTexture2);
        }

        public Cloud(float width, Texture2D texture)
        {
            position = Vector2.Zero;
            this.width = width;
            this.texture = texture;
        }

        public void Render()
        {
            Graphics.Draw(texture, position);
        }
    }
}
