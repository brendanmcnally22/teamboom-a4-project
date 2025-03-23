using System;
using System.Numerics;

namespace MohawkGame2D
{
    public class Game
    {
        Cloud[] clouds = new Cloud[12];

        Texture2D Lep =
            Graphics.LoadTexture("../../../../../Assets/Graphics/Lep.png");
        Texture2D BGS =
            Graphics.LoadTexture("../../../../../Assets/Graphics/BGS.png");

        public void Setup()
        {
            Window.SetTitle("LEAPrechaun");
            Window.SetSize(800, 600);



            clouds = new Cloud[]
            {
                new Cloud(new Vector2(20, 200), Cloud.cloudInstance1), //1
                new Cloud(new Vector2(175, 300), Cloud.cloudInstance2),//2
                new Cloud(new Vector2(100, 450), Cloud.cloudInstance1),//3
                new Cloud(new Vector2(275, 550), Cloud.cloudInstance2),//4
                new Cloud(new Vector2(330,250), Cloud.cloudInstance2),//5
                new Cloud(new Vector2(400, 450), Cloud.cloudInstance2),//6
                new Cloud(new Vector2(525, 400), Cloud.cloudInstance1),//7
                new Cloud(new Vector2(500, 200), Cloud.cloudInstance1),//8
                new Cloud(new Vector2(700, 500), Cloud.cloudInstance2),//9
                new Cloud(new Vector2(230, 125), Cloud.cloudInstance2),//10
                new Cloud(new Vector2(665, 300), Cloud.cloudInstance1),//11
                new Cloud(new Vector2(630, 100), Cloud.cloudInstance1),//12
                new Cloud(new Vector2(425, 75), Cloud.cloudInstance1),//12
            };
        }

        public void Update()
        {
            Window.ClearBackground(Color.OffWhite);
            Graphics.Draw(BGS, 0, 0);

            Graphics.Draw(Lep, 100, 100);

            foreach (var cloud in clouds)
            {
                cloud.Render();
            }
        }

    }
}


