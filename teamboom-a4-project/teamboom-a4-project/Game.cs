// Include the namespaces (code libraries) you need below.
using System;
using System.Numerics;

// The namespace your code is in.
namespace MohawkGame2D;

// Add Project
public class Game
{
    //Coin Variables
    GoldCoin coin;
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
            Graphics.LoadTexture("../../../../Assets/Graphics/Lep.png");

    public void Setup()
    {
    Window.SetSize(800, 600);
    Window.SetTitle("Team BOOM");
        //Spawning Coins
        GoldCoin[] coins = [
    new GoldCoin(coinPos[1]),
    new GoldCoin(coinPos[2]),
    new GoldCoin(coinPos[3])
    ];
     
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
        coin.Render(coinPos);
        if (Player.Position.X - coinPos[1].X <= 12 && Player.Position.Y - coinPos[1].Y <= 12)
        {
            coinPos[1] = offScreen;
            coinCount += 1;
        }
        if (Player.Position.X - coinPos[2].X <= 12 && Player.Position.Y - coinPos[2].Y <= 12)
        {
            coinPos[2] = offScreen;
            coinCount += 1;
        }
        if (Player.Position.X - coinPos[3].X <= 12 && Player.Position.Y - coinPos[3].Y <= 12)
        {
            coinPos[3] = offScreen;
            coinCount += 1;
        }
        //Coin Counter
        Text.Size = 14;
        Text.Draw($"Coins {coinCount}", 360, 20);
    }
}

