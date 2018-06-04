﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Camera
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        static SpriteBatch spriteBatch;
        Vector2 speed;
        Vector2 acceleration;

        Camera camera;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferHeight = 400;
            graphics.PreferredBackBufferWidth = 800;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            camera = new Camera();
            speed = new Vector2(0, 0);
            acceleration = new Vector2(0, 0.8f);

            //for (int i = 0; i < 10; i++)
            //for (int j = 0; j < 10; j++)
            //{
            //    for (int i = 0; i < 10; i++)
            //        {
            //        new GameObject(new Vector2(10+j*30, 10+i*30), 20, 20, GraphicsDevice);
            //        }
            //}
            for (int i = 0; i < 50; i++)
            {
                new GameObject(new Vector2(0+i*20, 380), 20, 20, GraphicsDevice);
            }
            for (int i = 0; i < 5; i++)
            {
                new GameObject(new Vector2(250 + i * 20, 300), 20, 20, GraphicsDevice);
            }
            for (int i = 0; i < 5; i++)
            {
                new GameObject(new Vector2(490 + i * 20, 250), 20, 20, GraphicsDevice);
            }



            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Right))
            {

                //camera.position += new Vector2(10, 0);
                speed.X = 5;
               
            }
            if (state.IsKeyDown(Keys.Left))
            {
                //camera.position += new Vector2(-10, 0);
                speed.X = -5;
            }
            if (state.IsKeyDown(Keys.Up))
            {
                //camera.position += new Vector2(0, -10);
                if (camera.position.Y == 380)
                {
                    speed = new Vector2(0, -5);
                }
            }
            if (state.IsKeyDown(Keys.Down))
            {
                //camera.position += new Vector2(0, 10);
                speed.Y = 5;
            }

            if (camera.position.Y >= 380)
            {
                speed = new Vector2(0, 0);
                camera.position.Y = 360;
            }
            camera.position = camera.position + speed;
            speed = speed + acceleration;

            // TODO: Add your update logic here


            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            spriteBatch.Begin();

            for (int i = 0; i < GameObject.allObjects.Count; i++)
            {
                GameObject.allObjects[i].Draw(spriteBatch, camera.position);
            }

            spriteBatch.End();

            
            base.Draw(gameTime);
        }
    }
}
