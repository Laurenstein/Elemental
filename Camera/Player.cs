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

        int element;
        int ground = 360;
        Vector2 speed = new Vector2(0,0);
        Vector2 acceleration = new Vector2(0,1);

        public Player(Vector2 position, int height, int width, int element, GraphicsDevice graphics) : 
            base(position, height,width, graphics)
        {
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
                    
                }
                else if (state.IsKeyDown(Keys.Left))
                {
                    speed.X = -5;
                }

                speed += acceleration;


            }


            position += speed;


            // Player nespadne z podlahy - bug na začátku skoku



            for (int i = 0; i < GameObject.allObjects.Count; i++)
            {
                if (isColliding(GameObject.allObjects[i]) && GameObject.allObjects[i] != this)
                {
                    HandleCollision(GameObject.allObjects[i], speed);

                    if (isStandingOn(GameObject.allObjects[i]))
                    {
                        speed = new Vector2(0, 0);
                    }
                    else
                    {
                        speed = new Vector2(0, 1);
                    }
                    
                    

                }
            }



            // došlo ke kolizi, změna pozice na hodnotu kolize - změna isStanding
            //if(isColliding(a,player))
            //{
            //    position.Y = něco jako position.kolize
            //}


        }
        // zjišťuje, jestli player stojí nebo lítá
        public bool isStandingOn(GameObject a)
        {

            //if (position.Y + height == a.position.Y)
            //{ return true; }
            //else
            //{ return false; }

            return  position.Y + height == a.position.Y;
        }


        public bool isStanding()
        {
            for (int i = 0; i < GameObject.allObjects.Count; i++)
            {
                if (isColliding(GameObject.allObjects[i]) && GameObject.allObjects[i] != this)
                {
                 
                    if(isStandingOn(GameObject.allObjects[i]))
                    {
                        return true;
                    }
                    


                }
            }
            return false;


        }




    }
}

