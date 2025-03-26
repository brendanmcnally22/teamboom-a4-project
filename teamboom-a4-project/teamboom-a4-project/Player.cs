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

        // Yeah I'm cooking here, This is looking very efficient! 
        // Now I will try to create a Player Movement.

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

        if (onPlatform && Input.IsKeyboardKeyDown(KeyboardInput.Space))
        {
            velocity.Y = -10f;
            onPlatform = false;
        }

    }

    }


