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
        float start_jump = 0;
        Vector2 acceleration = new Vector2(0,0.9f);

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

                start_jump = position.Y;
                position = new Vector2(position.X, start_jump) + new Vector2(0, -speed);
                
                
            }
            // opravit speed a akceleracii
            position = position + acceleration;

            // Player nespadne z podlahy
            if (position.Y > 360)
            {
                position.Y = 360;
            }
            //if (state.IsKeyDown(Keys.Right))

            //camera.setPosition(speed);
            //speed = speed + acceleration;
        }
    }
}
