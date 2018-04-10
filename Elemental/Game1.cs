using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Elemental
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D texture;
        Vector2 position;
        Vector2 speed;
        Button tlacitko;
        Vector2 acceleration;
        int width = 50;
        int height = 50;

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

            position = new Vector2(1, 350);
            speed = new Vector2(0, 0);
            acceleration = new Vector2(0,0.5f);
            texture = new Texture2D(this.GraphicsDevice, width, height);
            Color[] square = new Color[width * height];

            // naplníme square barvou

            tlacitko = new Button(new Vector2(10, 10), 10, 10, Color.AntiqueWhite, GraphicsDevice);

            for (int i = 1; i < square.Length; i++)
            {
                square[i] = Color.Khaki;
            }

            texture.SetData(square);
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

           // tlacitko.texture = Content.Load<Texture2D>("texture");

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
            KeyboardState state = Keyboard.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (state.IsKeyDown(Keys.Right))
                speed.X = 10;
            if (state.IsKeyDown(Keys.Left))
                speed.X = -10;
            if (state.IsKeyDown(Keys.Up))
            {
                if (position.Y == 350)
                {
                    speed = new Vector2(0, -10);
                }

            }

            if (state.IsKeyDown(Keys.Down))
                speed.Y = 20;


            // TODO: Add your update logic here

            
            
            position = position + speed;
            speed = speed + acceleration;

            if (position.Y >= 350)
            {
                speed = new Vector2(0, 0);
                position.Y = 350;
            }
                
            
            base.Update(gameTime);

        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.DarkSlateGray);

            // TODO: Add your drawing code here

            

            spriteBatch.Begin();
            spriteBatch.Draw(texture, position);
            spriteBatch.Draw(tlacitko.texture, tlacitko.position);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
