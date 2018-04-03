using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elemental
{
    class Button
    {

        int height;
        int width;
        public Vector2 position;
        public Texture2D texture;
        public Color color;

        public Button(Vector2 position, int height, int width, Color color, GraphicsDevice graphics) {

            this.position = position;
            this.width = width;
            this.height = height;
            this.color = color;

            texture = new Texture2D(graphics, width, height);
            Color[] button = new Color[width * height];

            for (int i = 0; i < button.Length; i++)
            {
                button[i] = Color.Cyan;

            }
            texture.SetData(button);



        }


    }
}
