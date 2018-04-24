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
                square[i] = Color.Red;
            }

           texture.SetData(square);

            allObjects.Add(this);


        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraPosition)
        {
            spriteBatch.Draw(texture, position-cameraPosition);

        }

    }

}
