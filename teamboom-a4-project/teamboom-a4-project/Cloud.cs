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


        // Loading Texture for the clouds 
        static Texture2D cloudTexture1 =
            Graphics.LoadTexture("../../../../../Assets/Graphics/Cloud1.png");
        static Texture2D cloudTexture2 =
            Graphics.LoadTexture("../../../../../Assets/Graphics/Cloud2.png");


        // Predefined Cloud Instances
        public static Cloud cloudInstance1;
        public static Cloud cloudInstance2; 
        public static Cloud cloudInstance3;
        public static Cloud cloudInstance4; 
        public static Cloud cloudInstance5; 
        public static Cloud cloudInstance6; 
        public static Cloud cloudInstance7;
        public static Cloud cloudInstance8;
        public static Cloud cloudInstance9;
        public static Cloud cloudInstance10;
        public static Cloud cloudInstance11;
        public static Cloud cloudInstance12;
        static Cloud()
        {
            cloudInstance1 = new Cloud(96, cloudTexture1);
            cloudInstance2 = new Cloud(96, cloudTexture2);
            cloudInstance3 = new Cloud(96, cloudTexture1);
            cloudInstance4 = new Cloud(96, cloudTexture2);
            cloudInstance5 = new Cloud(96, cloudTexture1);
            cloudInstance6 = new Cloud(96, cloudTexture2);
            cloudInstance7 = new Cloud(96, cloudTexture1);
            cloudInstance8 = new Cloud(96, cloudTexture2);
            cloudInstance9 = new Cloud(96, cloudTexture1);
            cloudInstance10 = new Cloud(96, cloudTexture2);
            cloudInstance11 = new Cloud(96, cloudTexture1);
            cloudInstance12 = new Cloud(96, cloudTexture2);
        }

        Cloud(float width, Texture2D texture) // Constructor used for static Instance 
        {
            position = Vector2.Zero;
            this.width = width;
            this.texture = texture;
        }
        public Cloud(Vector2 position, Cloud cloud) // Public constructor for creating New cloud instances. 
        {
            this.position = position;
            this.width = cloud.width;
            this.texture = cloud.texture;
        }

        public void Render()
        {
            Graphics.Draw(texture, position);
        }
    }
}


