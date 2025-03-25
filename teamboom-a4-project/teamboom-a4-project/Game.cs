using System;
using System.Numerics;

namespace MohawkGame2D
{
    public class Game
    {
        Cloud[] clouds = new Cloud[12];   // Array to hold clouds
        Texture2D Lep = Graphics.LoadTexture("../../../../../Assets/Graphics/Lep.png");
        Texture2D BGS = Graphics.LoadTexture("../../../../../Assets/Graphics/BGS.png");
        Texture2D PotofGold = Graphics.LoadTexture("../../../../../Assets/Graphics/PotofGold.png");

        Vector2 cameraPosition = Vector2.Zero; 
        float backgroundX = 0;
        float cameraSpeed = 1f;
        float backgroundSpeed = 0f;

        public void Setup()
        {
            Window.SetTitle("LEAPrechaun");
            Window.SetSize(800, 600);

            
            clouds = new Cloud[]
            {
            new Cloud(new Vector2(20, 200), Cloud.cloudInstance1),
            new Cloud(new Vector2(175, 300), Cloud.cloudInstance2),
            new Cloud(new Vector2(100, 450), Cloud.cloudInstance1),
            new Cloud(new Vector2(275, 550), Cloud.cloudInstance2),
            new Cloud(new Vector2(330,250), Cloud.cloudInstance2),
            new Cloud(new Vector2(400, 450), Cloud.cloudInstance2),
            new Cloud(new Vector2(525, 400), Cloud.cloudInstance1),
            new Cloud(new Vector2(500, 200), Cloud.cloudInstance1),
            new Cloud(new Vector2(700, 500), Cloud.cloudInstance2),
            new Cloud(new Vector2(230, 125), Cloud.cloudInstance2),
            new Cloud(new Vector2(665, 300), Cloud.cloudInstance1),
            new Cloud(new Vector2(630, 100), Cloud.cloudInstance1),
            new Cloud(new Vector2(425, 75), Cloud.cloudInstance1),
            new Cloud(new Vector2(800, 400), Cloud.cloudInstance1),
            new Cloud(new Vector2(765, 175), Cloud.cloudInstance1),
            new Cloud(new Vector2(800, 75), Cloud.cloudInstance1),
            };
        }

        public void Update()
        {
            Window.ClearBackground(Color.OffWhite);
            Graphics.Draw(BGS, backgroundX, 0);
            
            backgroundX += backgroundSpeed;

            cameraPosition.X += cameraSpeed;
            
            for (int i = 0; i < clouds.Length; i++)
            {
                clouds[i].position.X -= cameraSpeed;
               
                if (clouds[i].position.X < -100)  
                {
                    clouds[i].position.X = 800;  
                }
                
                clouds[i].Render();
            }

            Graphics.Draw(Lep, 100, 100);  
        }
    }


}



