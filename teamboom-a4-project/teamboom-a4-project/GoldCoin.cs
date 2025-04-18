﻿using System;
using System.Numerics;


namespace MohawkGame2D
{
    public class GoldCoin
    {
        // Coin Variables / Parameters 
        public Vector2 position;
        public bool collected = false;
        public Texture2D texture;
        public float width;
        public float height;
        
        Sound CoinSound = Audio.LoadSound("../../../../../Assets/Audio/CoinSound.MP3");
        public GoldCoin(Vector2 pos)
        {
            position = pos;
            texture = Graphics.LoadTexture("../../../../../Assets/Graphics/GoldCoin.png"); // Taija I found your gold issue :D 
            width = texture.Width;
            height = texture.Height;
        }
        public void renderCoin()
        {
            // Only want to render the coin if it hasn't been collected
            if (!collected)
            {
                Graphics.Draw(texture, position);
            }
        }
        public void MakeNoise()
        {
            Audio.Play(CoinSound);
        }
        public Vector2 GetSize()
        {
            return new Vector2(width, height);
        }
    }
}
