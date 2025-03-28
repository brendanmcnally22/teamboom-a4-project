using System;
using System.Numerics;

namespace MohawkGame2D
{
    public class Game
    {
        // Assets
        Texture2D Lep = Graphics.LoadTexture("../../../../../Assets/Graphics/Lep.png");
        Texture2D PotofGold = Graphics.LoadTexture("../../../../../Assets/Graphics/PotofGold.png");

        // Screen Assets
        Texture2D StartScreen = Graphics.LoadTexture("../../../../../Assets/Graphics/StartScreen.png");
        Texture2D WinnerScreen = Graphics.LoadTexture("../../../../../Assets/Graphics/WinnerScreen.png");
        Texture2D LoserScreen = Graphics.LoadTexture("../../../../../Assets/Graphics/LoserScreen.png");
        Texture2D BackgroundScreen = Graphics.LoadTexture("../../../../../Assets/Graphics/BackgroundScreen.png");

        // Camera
        Vector2 cameraPosition = Vector2.Zero; 
        float cameraSpeed = 1f; 

        // Classes
        Cloud[] clouds = new Cloud[12];   // Array to hold clouds
        GoldCoin[] goldCoins; // Gold Coins instance
        Player player; // Player instance :D 

        int goldCounter = 0; // Gold Counter

        // Winning/Losing
        bool menuScreen = true;
        bool gameOver = false;
        bool win = false; // Set this to true when player collects all the coins aka wins the game

        // Background
        float backgroundSpeed = 0f;
        float backgroundX = 0;
        
        // Colour for text
        Color DarkGreen = new Color(29, 96, 23);

        Music backgroundMusic;

        public void Setup()
        {
            Window.SetTitle("LEAPrechaun");
            Window.SetSize(800, 600);

            // Main Music
            backgroundMusic = Audio.LoadMusic("../../../../../Assets/Audio/GameSong.MP3");
            Audio.Play(backgroundMusic);

            // Clouds Array
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
            new Cloud(new Vector2(230, 140), Cloud.cloudInstance2),
            new Cloud(new Vector2(665, 300), Cloud.cloudInstance1),
            new Cloud(new Vector2(690, 135), Cloud.cloudInstance1),
            new Cloud(new Vector2(800, 400), Cloud.cloudInstance1),
         };

            player = new Player(new Vector2(100, 100), Lep); // Creating "LEP!" (the goaat)

            // Coin Array
            goldCoins = new GoldCoin[] // Where we draw the Coins 
            {
            new GoldCoin(new Vector2(55, 175)),
            new GoldCoin(new Vector2(210, 275)),
            new GoldCoin(new Vector2(135, 425)),
            new GoldCoin(new Vector2(310, 525)),
            new GoldCoin(new Vector2(365, 225)),
            new GoldCoin(new Vector2(435, 425)),
            new GoldCoin(new Vector2(560, 375)),
            new GoldCoin(new Vector2(535, 175)),
            new GoldCoin(new Vector2(735, 475)),
            new GoldCoin(new Vector2(265, 115)),
            new GoldCoin(new Vector2(700, 275)),
            new GoldCoin(new Vector2(725, 110)),
            new GoldCoin(new Vector2(835, 375))
            };

            goldCounter = 0;
            gameOver = false;

        }
        public void Update()
        {
            Window.ClearBackground(Color.OffWhite);
            Graphics.Draw(BackgroundScreen, backgroundX, 0);
            backgroundX += backgroundSpeed;
            cameraPosition.X += cameraSpeed;
            
            if (menuScreen)
            {
                mainMenuLogic();
                return;
            }
            if (gameOver)
            {
                if (win)
                    winScreen();
                else
                    gameOverScreen();
                return;
            }
            updateClouds();
            updateCoins();
            player.playerMovement();
            player.renderPlayer();
            drawCounter();
            CheckPlatformCollision();
            gameOverLogic();
        }
        public void drawCounter()
        {
            // Draw this niceeee pot of gold in the beautiful top left hand corner of our screen please and thank you
            Vector2 potPos = new Vector2(10, 10);
            Graphics.Draw(PotofGold, potPos);

            // I'll do the coin counter underneath here 
            Text.Draw($"You Have Collected {goldCounter} Gold!", 80, 10);
            Text.Color = (DarkGreen);
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
        private void updateClouds() // Drawing the Clouds
        {
            for (int i = 0; i < clouds.Length; i++)
            {
                clouds[i].position.X -= cameraSpeed;

                if (clouds[i].position.X < -100)
                {
                    clouds[i].position.X = 800;
                }

                clouds[i].Render();
            }
        }
        private void updateCoins() // Drawing the Coins and Doing the coin counter
        {
            foreach (var coin in goldCoins)
            {

                coin.position.X -= cameraSpeed;  // Making the coins stay with the camera
                if (coin.position.X < -100)
                {
                    coin.position.X = 800;
                } 
                
                if (!coin.collected && CollisionHelper.isColliding(player.position, player.GetSize(), coin.position, coin.GetSize()))
                {
                    coin.MakeNoise();
                    coin.collected = true;
                    goldCounter++;
                   
                }
                coin.renderCoin();
            }
        }
        private void gameOverLogic() // Game Over ! 
        {
            // Trying simple Game over Logic like if the player falls of the screen or the coins are all collected? 
            if (player.position.Y > 600)
            {
                gameOver = true;
                win = false;
            }

            if (goldCounter == goldCoins.Length)
            {
                gameOver = true;
                win = true;
            }

        }
        private void mainMenuLogic()
        {
            Graphics.Draw(StartScreen, 0, 0);

            bool IsClicking = Input.IsMouseButtonPressed(MouseInput.Left);
            bool IsOverPlayButton = CollisionHelper.isColliding(Input.GetMousePosition(), Vector2.Zero, new Vector2(272, 376), new Vector2(249, 55));
            
            if ((IsClicking && IsOverPlayButton) || Input.IsKeyboardKeyPressed(KeyboardInput.Enter) || Input.IsKeyboardKeyPressed(KeyboardInput.X) || (Input.IsControllerButtonPressed(0, ControllerButton.RightFaceLeft)))
            {
                menuScreen = false;
                Setup();
            }
            
        }
        private void gameOverScreen()
        {
            Window.ClearBackground(Color.OffWhite);
            Graphics.Draw(LoserScreen, 0, 0);

            Text.Draw("Press R to Restart!", new Vector2(240, 540));
            Text.Color = (DarkGreen);

            if (Input.IsKeyboardKeyPressed(KeyboardInput.R) || Input.IsKeyboardKeyPressed(KeyboardInput.X) || Input.IsControllerButtonPressed(0, ControllerButton.RightFaceLeft))
                {
             // Restart the game pls

                menuScreen = true;
                Setup();
            }
        }
        private void winScreen() // Handle the Win screen input and also draw it aswell!
        {
            Graphics.Draw(WinnerScreen, 0, 0);
            
            Text.Draw("Press R to restart!", new Vector2(255, 570));
            Text.Color = (DarkGreen);
            Text.Draw($"You Collected {goldCounter} Gold!", new Vector2(238, 540));
            Text.Color = (DarkGreen);
            Text.Size = 28;

            if (Input.IsKeyboardKeyPressed(KeyboardInput.R) || Input.IsKeyboardKeyPressed(KeyboardInput.X) || Input.IsControllerButtonPressed(0, ControllerButton.RightFaceLeft))
            {
                menuScreen = true; // Return to the main menu
                Setup();
            }
        }
       
    }
}



