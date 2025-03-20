using System.Numerics;
using System;

namespace MohawkGame2D
{
    public class Player
    {
        public Vector2 Position;
        Vector2 velocity;
        float speed = 200f;
        float jumpPower = 300f;
        float gravity = 500f;
        float jumpDelay = 0.2f;
        float jumpTimer = 0f;

        public Player(Vector2 startPosition)
        {
            Position = startPosition;
        }

        

        public void movePlayer(float deltaTime) // Function to handle Player Movement 
        {

            // Movement for the player
            if (Input.IsKeyboardKeyDown(KeyboardInput.A))
            { velocity.X = -speed; }

            else if (Input.IsKeyboardKeyDown(KeyboardInput.D))
            {
                   velocity.X = speed;
            }
            else velocity.X = 0;


        }
    }
}
