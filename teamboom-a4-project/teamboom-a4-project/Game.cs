// Include the namespaces (code libraries) you need below.
using System;
using System.Numerics;

// The namespace your code is in.
namespace MohawkGame2D;

// Add Project
public class Game
{
    //Coin Variables
    //GoldCoin coin;
    //GoldCoin[] coins;
    GoldCoin[] coins = Array.Empty<GoldCoin>();
    public int coinCount = 0;
    public Vector2[] coinPos =
        {
        new Vector2(20, 20),
        new Vector2(30, 30),
        new Vector2(40, 40)
    };
    public Vector2 offScreen = new Vector2(0, 2000);


    // Camera to follow the player
    Vector2 cameraOffset;
    float deltaTime = 1f / 60f; // Setting Frame Rate for now 

    Texture2D Lep =
            Graphics.LoadTexture("../../../../../Assets/Graphics/Lep.png");

    public void Setup()
    {
    Window.SetSize(800, 600);
    Window.SetTitle("Team BOOM");
        //Spawning Coins
        //GoldCoin[] coins;
        coins = new GoldCoin[]
        {
                new GoldCoin(coinPos[0]),
                new GoldCoin(coinPos[1]),
                new GoldCoin(coinPos[2])
        };

     
    }
    public void Update()
    {
        Window.ClearBackground(Color.White);

        Player.movePlayer(deltaTime); // Player movement

        //Update camera 
        cameraOffset = new Vector2(

        Player.Position.X - Window.Width / 2,
        Player.Position.Y - Window.Height / 2 );

        Player.renderPlayer(cameraOffset);

        Draw.FillColor = Color.Yellow;
        Draw.Circle(new Vector2(400, 400) - cameraOffset, 25);

        //Coin Collision & Rending
        foreach (GoldCoin coin in coins)
        {
            coin.Render(cameraOffset);
        }

        for (int i = 0; i < coins.Length; i++)
            {
                if (Math.Abs(Player.Position.X - coinPos[i].X) <= 12 &&
             Math.Abs(Player.Position.Y - coinPos[i].Y) <= 12)
                {
                    coins[i].position = offScreen;
                    coinCount ++ ;
                }
            }
        

        //Coin Counter
        Text.Size = 14;
        Text.Draw($"Coins {coinCount}", 720, 20);
    }
}

