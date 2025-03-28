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
    public float speed = 4f; // Player speed
    public Texture2D texture;
    public float width;
    public float height;
    public bool onPlatform = false;

    private float jumpTimer = 0f; // Jump Timer 
    private const float jumpCooldown = 0.5f;

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
    

    public void playerMovement()
    {
        float moveX = Input.GetControllerAxis(0, ControllerAxis.LeftX);
        velocity.X = moveX * speed; 

        if (Input.IsKeyboardKeyDown(KeyboardInput.Left))
        {
            position.X -= speed; 
        }
        if (Input.IsKeyboardKeyDown(KeyboardInput.Right))
        {
            position.X += speed;
        }

        if (onPlatform && jumpTimer <= 0 && (Input.IsKeyboardKeyPressed(KeyboardInput.Space) || Input.IsControllerButtonPressed(0,ControllerButton.LeftTrigger1))) // basically saying JUMP Only if your on the PLATFORM 
        {
            velocity.Y = -10f;
            jumpTimer = jumpCooldown; 
            onPlatform = false;
           
        }
        velocity.Y += 0.4f; // Applying Gravity
        position += velocity; // Updating the Position

        if(jumpTimer >0)
        {

            jumpTimer -= 0.016f;
            if (jumpTimer < 0)
                jumpTimer = 0;
        }
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


