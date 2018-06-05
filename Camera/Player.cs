using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camera
{
    class Player : GameObject
    {

        int hp;
        int element;
        float speed;
        Vector2 gravity = new Vector2(0,0.8f);

        public Player(Vector2 position, int height, int width, int hp, float speed, int element, GraphicsDevice graphics) : 
            base(position, height,width, graphics)
        {
            this.hp = 100;
            this.element = 1;
            this.speed = speed;
        }

        public void Update()
        {
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Right))
            {
                position = position + new Vector2(speed, 0);
            }
            if (state.IsKeyDown(Keys.Left))
            {
                position = position + new Vector2(-speed, 0);
            }
            if (state.IsKeyDown(Keys.Up))
            {
                position = position + new Vector2(0, -speed);
            }
            // opravit speed a akceleraci
            position = position + new Vector2(0, gravity);
            //if (state.IsKeyDown(Keys.Right))

            //camera.setPosition(speed);
            //speed = speed + acceleration;
        }
    }
}
