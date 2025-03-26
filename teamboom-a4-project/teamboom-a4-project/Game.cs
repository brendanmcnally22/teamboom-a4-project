using System;
using System.Numerics;

namespace MohawkGame2D
{
    public class Game
    {
        Texture2D Lep = Graphics.LoadTexture("../../../../../Assets/Graphics/Lep.png");
        Texture2D BGS = Graphics.LoadTexture("../../../../../Assets/Graphics/BGS.png");
        Texture2D PotofGold = Graphics.LoadTexture("../../../../../Assets/Graphics/PotofGold.png");

        Vector2 cameraPosition = Vector2.Zero;
        float cameraSpeed = 1f;
        Cloud[] clouds = new Cloud[12];   // Array to hold clouds
        Player player; // Player instance :D 
        
        float backgroundSpeed = 0f;
        float backgroundX = 0;

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
            new Cloud(new Vector2(500, 200), Cloud.cloudInstance1)
            };

            player = new Player(new Vector2(100, 100), Lep); // Creating "LEP!" (the goaat)
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


            player.playerMovement();
            player.renderPlayer();
     
        }
    }


}



