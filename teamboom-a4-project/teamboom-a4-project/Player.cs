using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MohawkGame2D;

    public class Player
    {

    public Vector2 position;
    public Vector2 velocity;
    public float speed = 5f; // Player speed
    public Texture2D texture;
    public float width;
    public float height;
    public bool onPlatform = false; 

    public Player(Vector2 startPosition, Texture2D playerTexture)
    {
        position = startPosition;
        texture = playerTexture;
        width = texture.Width; 
        height = texture.Height;
        velocity = Vector2.Zero; 

        // I dont Know what happened to my original player class (I thought It was merged in here)
        // :( It is still in my branch, but it is to late to merge now. 
        // Its ok this one will do, And We can make it work :) 
    }

    public void playerMovement()
    {
        if (Input.IsKeyboardKeyDown(KeyboardInput.A))
        {
            position.X -= speed; 
        }
        if (Input.IsKeyboardKeyDown(KeyboardInput.D))
        {
            position.X += speed;
        }

        if (onPlatform && Input.IsKeyboardKeyDown(KeyboardInput.Space)) // basically saying JUMP Only if your on the PLATFORM 
        {
            velocity.Y = -10f;
            onPlatform = false;
        }

        velocity.Y += 0.3f; // Applying Gravity

        position += velocity; // Updating the Position

    }

    public Vector2 GetSize()
    {
        return new Vector2(width, height); // Returns the size of the player for our collision detection :D 
    }


    public void renderPlayer() // Function To render the player in Game.CS 
    {
        Graphics.Draw(texture, position); // Drawing player using the texture and updated position
    }

}


