using System;
using System.Numerics;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Transactions;

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
        GoldCoin[] goldCoins;
        Player player; // Player instance :D 
        int goldCounter = 0;


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

            goldCoins = new GoldCoin[]
            {
                new GoldCoin(new Vector2(200,340)),
                new GoldCoin(new Vector2(250,300)),
                new GoldCoin(new Vector2(230,400))
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


            player.playerMovement();
            player.renderPlayer();
            drawCounter();
            CheckPlatformCollision();

            foreach (var coin in goldCoins)
            {
                if (!coin.collected && CollisionHelper.isColliding(player.position, player.GetSize(), coin.position, coin.GetSize()))
                {
                    coin.collected = true;
                    goldCounter++;
                    Console.WriteLine($"you now have {goldCounter} gold");
                }
                coin.renderCoin();
            }


            
        }
        public void drawCounter()
        {
            // Draw this niceeee pot of gold in the beautiful top left hand corner of our screen please and thank you
            Vector2 potPos = new Vector2(10, 10);
            Graphics.Draw(PotofGold, potPos);
            // I'll do the coin counter underneath here 
         
            Text.Draw($"You Have Collected {goldCounter} gold!", 80, 20);
            
        }
        private void CheckPlatformCollision()
        {

            float marginX = 5f; // Trying to define the margins to shrink the collision box
            float marginY = 40f; 
            float verticalSnapTolerance = 10f;
            float dynamicTolerance = verticalSnapTolerance + player.velocity.Y * 0.5f; // Ok this is literally awesome ngl here im gonna use a dynamic tolerance based on fall speed,
                                                                                       // basically if the player is falling fast or velocity.Y is larger the tolerance INCREASES, 
                                                                                       // making it more likely that the collision will be caught EVEN IF the pen depth is bigger.


            foreach (Cloud platform in clouds)
            {
                //Shifting and Reducing the Collision box to try make it less jarring and more smooth
                Vector2 adjustedPlatformPos = new Vector2(platform.position.X + marginX, platform.position.Y +marginY);
                Vector2 adjustedPlatformSize = new Vector2(platform.width - 2 * marginX, platform.GetSize().Y - marginY);


                if (CollisionHelper.isColliding(
                    player.position, new Vector2(player.width, player.height),
                                                adjustedPlatformPos,adjustedPlatformSize))
                {
                    
                    float playerBottom = player.position.Y + player.height;
                    float platTop = adjustedPlatformPos.Y;
                    float diff = playerBottom - platTop;


               // Trying a different way of collision to make it more smooth hopefully
                    if (player.velocity.Y > 0 && diff >= 0 && diff <= dynamicTolerance)
                    {
                        player.position = new Vector2(player.position.X, platTop - player.height);
                        player.velocity = new Vector2(player.velocity.X, 0);
                        player.onPlatform = true;
                    }
                }
            }
        }


    }
}



