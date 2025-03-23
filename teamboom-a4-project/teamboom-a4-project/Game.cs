// Include the namespaces (code libraries) you need below.
using System;
using System.Numerics;

// The namespace your code is in.
namespace MohawkGame2D;

// Add Project
public class Game
{

    Texture2D Lep =
            Graphics.LoadTexture("../../../../Assets/Graphics/Lep.png");


    public void Setup()
    {
        
        Window.SetSize(800, 600);
        Window.SetTitle("Team BOOM"); 

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
       
        
    }
}

