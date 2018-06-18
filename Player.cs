﻿using Microsoft.Xna.Framework;
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
        Vector2 speed = new Vector2(0,0);
        Vector2 acceleration = new Vector2(0,1);

        public Player(Vector2 position, int height, int width, int hp, int element, GraphicsDevice graphics) : 
            base(position, height,width, graphics)
        {
            this.hp = 100;
            this.element = 1;
        }

        public void Update()
        {
            KeyboardState state = Keyboard.GetState();

            if (isStanding())
            {
                if (state.IsKeyDown(Keys.Up))
                {
                   speed.Y -= 20;

                }
                if (state.IsKeyDown(Keys.Right))
                {

                    speed.X = 5;
                }
                else if (state.IsKeyDown(Keys.Left))
                {
                    speed.X = -5;
                } else
                {
                    speed.X = 0;
                }
            } else
            {
                if (state.IsKeyDown(Keys.Right))
                {

                    speed.X = 5;
                    if(state.IsKeyDown(Keys.Left))
                    {

                        speed.X = -1;
                    }
                }
                else if (state.IsKeyDown(Keys.Left))
                {
                    speed.X = -5;
                }

                speed += acceleration;


            }


            position += speed;
            

            // Player nespadne z podlahy - bug na začátku skoku
            if (position.Y > 360)
            {
                position.Y = 360;
            }


            //if(isColliding(a,player))
            //{
            //    position.Y = něco jako position.kolize
            //}

 
            
            //if (state.IsKeyDown(Keys.Right))

            //camera.setPosition(speed);
            //speed = speed + acceleration;
        }
        public Boolean isStanding()
        {
            //po zprovoznění kolizí se bude ptát, jestli koliduje s něčím, pokud ano, bude stát
            if (position.Y == 360)
            {
                return true;
            } else
            {
                return false;
            }
        }
        // poznámky k téhle podmínce na disku

        public Boolean isColliding(GameObject a, Player player)
        {
           if ((Math.Abs(a.position.X - player.position.X) * 2 < (a.width + player.width)) &&
           (Math.Abs(a.position.Y - player.position.Y) * 2 < (a.height + player.height)))
                {
                return true;
                }
           else
            {
                return false;
            }
        }
    }
}


//Kolize
//    bool DoBoxesIntersect(Box a, Box b)
//{
//    return (abs(a.x - b.x) * 2 < (a.width + b.width)) &&
//           (abs(a.y - b.y) * 2 < (a.height + b.height));
//}

//https://gamedev.stackexchange.com/questions/586/what-is-the-fastest-way-to-work-out-2d-bounding-box-intersection