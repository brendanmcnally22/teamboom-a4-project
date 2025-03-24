// Include the namespaces (code libraries) you need below.
using System;
using System.Numerics;

// The namespace your code is in.
namespace MohawkGame2D;

// Add Project
public class Game
{
    GoldCoin coin;
    public Vector2[] coinPos =
        {
        new Vector2(20, 20),
        new Vector2(30, 30),
        new Vector2(40, 40)
    };

    // Camera to follow the player
    Vector2 cameraOffset;
    float deltaTime = 1f / 60f; // Setting Frame Rate for now 

    Texture2D Lep =
            Graphics.LoadTexture("../../../../Assets/Graphics/Lep.png");

    Texture2D Coin =
                Graphics.LoadTexture("../../../../Assets/Graphics/Coin.png");
    public void Setup()
    {
        Window.SetSize(800, 600);
        Window.SetTitle("Team BOOM");
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

        coin.Render(coinPos);
    }
}

