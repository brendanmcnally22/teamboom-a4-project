// Include the namespaces (code libraries) you need below.
using System;
using System.Numerics;

// The namespace your code is in.
namespace MohawkGame2D;

// Add Project
public class Game
{
    Player player;



    public void Setup()
    {
        Window.SetSize(800, 600);
        Window.SetTitle("Team BOOM"); // Hey I want to Merge this to Main
        player = new Player();
    }


    public void Update()
    {
        Window.ClearBackground(Color.OffWhite);
        player.Render();

    }
}

