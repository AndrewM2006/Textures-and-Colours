using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Runtime.CompilerServices;

namespace Textures_and_Colours
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D dinoTexture;
        Texture2D starTexture;
        Texture2D astronautTexture;
        Texture2D sunTexture;
        Texture2D space1Texture;
        Texture2D space2Texture;
        int xValue, yValue, background;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = 800; // window width
            _graphics.PreferredBackBufferHeight = 500; // window height
            _graphics.ApplyChanges();
            this.Window.Title = "DINO IN SPACE"; // Changes title
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Random generator = new Random();
            
            background = generator.Next(2);
            base.Initialize();
            xValue = generator.Next(_graphics.PreferredBackBufferWidth - astronautTexture.Width);
            yValue = generator.Next(_graphics.PreferredBackBufferHeight - astronautTexture.Height);

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            dinoTexture = Content.Load<Texture2D>("dino");
            starTexture = Content.Load<Texture2D>("star");
            astronautTexture = Content.Load<Texture2D>("Astronaut");
            sunTexture = Content.Load<Texture2D>("Sun");
            space1Texture = Content.Load<Texture2D>("Space1");
            space2Texture = Content.Load<Texture2D>("Space2");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.IndianRed); //Changes default colour

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            if (background == 0)
            {
                _spriteBatch.Draw(space1Texture, new Vector2(0, 0), Color.White);
            }
            else
            {
                _spriteBatch.Draw(space2Texture, new Vector2(0, 0), Color.White);
            }
            _spriteBatch.Draw(dinoTexture, new Vector2 (10, 10), Color.White);
            for (int i = 0; i < 160; i += 32)
            {
                for (int j = 0; j < 170; j += 34)
                {
                    _spriteBatch.Draw(starTexture, new Vector2(j + 10, i + 325), Color.White);
                }
            }
            _spriteBatch.Draw(sunTexture, new Vector2(450, 10), Color.White);
            _spriteBatch.Draw(astronautTexture, new Vector2(xValue, yValue), Color.White);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}