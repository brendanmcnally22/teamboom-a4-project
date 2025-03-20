using System.Numerics;
using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MohawkGame2D
{
    public static class Player
    {
        public static Vector2 Position;
        static Vector2 velocity;
        static float speed = 200f;
        static float jumpPower = 300f;
        static float gravity = 500f;
        static float jumpDelay = 0.2f;
        static float jumpTimer = 0f;

        public static void movePlayer(float deltaTime) // Function to handle Player Movement 
        {

            // Movement for the player
            if (Input.IsKeyboardKeyDown(KeyboardInput.A))
            { velocity.X = -speed; }

            else if (Input.IsKeyboardKeyDown(KeyboardInput.D))
            {
                   velocity.X = speed;
            }
            else velocity.X = 0;

            jumpTimer += deltaTime;

            // Jump using Space
            if (jumpTimer > jumpDelay && Input.IsKeyboardKeyPressed(KeyboardInput.Space))
            {
                velocity.Y = -jumpPower;
                jumpTimer = 0f;
            }

            velocity.Y += gravity * deltaTime; // Apply Gravity 
            Position += velocity * deltaTime;  // Update Player Position

        }

        public static void renderPlayer()
        {
            Draw.FillColor = Color.Red;
            Draw.Circle(Position,25);
        }
    }
}
