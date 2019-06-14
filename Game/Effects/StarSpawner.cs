using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Engine.Extensions;
using Engine;

namespace Game
{
    public class StarSpawner : GameObject
    {
        private Random rnd = new Random();
        private bool firstFrame = true;
        private List<Star> stars = new List<Star>();
        
        

        public override void Update(float deltaTime)
        {
            if (firstFrame)
            {
                firstFrame = false;
                FillSpace(1000);
            }
            if(!firstFrame)
            {
                for (int i = 0; i < stars.Count; i++)
                {
                    if(stars[i].Center.X < 0)
                    {
                        var c = stars[i].Center;
                        c.X = rnd.Next(Scene.instance.Width -100, Scene.instance.Width);
                        stars[i].Center = c;
                    }
                }
            }
            Left = Parent.Right;
            //for (int i = 0; i < 200 * deltaTime; i++)
            //{
            //    SpawnStar();
            //}
        }

        private void FillSpace(int numberOfStars)
        {
            for (int i = 0; i < numberOfStars; i++)
            {
                CenterX = rnd.Next(Parent.Left.RoundedToInt(), Parent.Right.RoundedToInt());
                SpawnStar();
            }
        }

        public void SpawnStar()
        {
            Star star = new Star(Properties.Resources.star, rnd.Next(300));
            star.Center = Center;
            Parent.AddChildBack(star);
            stars.Add(star);
            CenterY = rnd.Next(Parent.Top.RoundedToInt(), Parent.Bottom.RoundedToInt());
        }

    }
}
