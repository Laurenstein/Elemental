using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camera
{
    class GameObject
    {

        public static List<GameObject> allObjects = new List<GameObject>();

        int height;
        int width;
        public Vector2 position;
        public Texture2D texture;

        public GameObject(Vector2 position, int height, int width, GraphicsDevice graphics)
        {
            this.position = position;
            this.width = width;
            this.height = height;

            texture = new Texture2D(graphics, width, height);
            Color[] square = new Color[width*height];
            for (int i = 1; i < square.Length; i++)
            {
                square[i] = Color.Gray;
            }

           texture.SetData(square);

            allObjects.Add(this);


        }
        // detekce kolize - vrací true nebo false
        public bool isColliding(GameObject a)
        {
            //return !()
            return !(
                a.position.X + a.width < position.X ||
                a.position.X > position.X + width ||
                a.position.Y + a.height < position.Y ||
                a.position.Y > position.Y + height
                );
        }
        //vyhazuje z objektu
        public void HandleCollision(GameObject a, Vector2 speed)
        {
            Vector2 B = position; // konečná pozice
            Vector2 A = B - speed;    // počáteční pozice
            // c je interpolovaná pozice na okraji
            // t je interpolovaná hodnota mezi 0,1
            int cx, cy;
            float tx, ty, t;

            if (speed.X == 0) tx = 1;
            // kolize zleva
            else if (A.X + width <= a.position.X && B.X + width > a.position.X)
            {
                cx = (int)a.position.X - width;
                tx = (cx - A.X) / speed.X;
            }
            else if (A.X >= a.position.X + a.width && B.X < a.position.X + a.width)
            {
                cx = (int)a.position.X + a.width;
                tx = (cx - A.X) / speed.X;
            }
            else tx = 1;


            if (speed.Y == 0) ty = 1;
            // kolize při pádu (Y)
            else if (A.Y + height <= a.position.Y && B.Y + height > a.position.Y)
            {
                cy = (int)a.position.Y - height;
                ty = (cy - A.Y) / speed.Y;
                //isStanding() = true;
            }
            // kolize ze spodu (Y)
            else if (A.Y >= a.position.Y + a.height && B.Y < a.position.Y + a.height)
            {
                cy = (int)a.position.Y + a.height;
                ty = (cy - A.Y) / speed.Y;
            }
            else ty = 1;

            t = Math.Min(tx, ty);

            position = A + t * speed;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraPosition)
        {
            spriteBatch.Draw(texture, position - cameraPosition);

        }
        

    }

}
