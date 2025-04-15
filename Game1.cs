using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Monogame_5._5___Particle_Effects
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        ParticleSystem particleSystem;
        List<Texture2D> particleTextures;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            particleTextures = new List<Texture2D>();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            particleTextures.Add(Content.Load<Texture2D>("Images/circle"));
            particleTextures.Add(Content.Load<Texture2D>("Images/star"));
            particleTextures.Add(Content.Load<Texture2D>("Images/diamond"));

            particleSystem = new ParticleSystem(particleTextures, new Vector2(400, 240));
        }

        protected override void Update(GameTime gameTime)
        {
            particleSystem._emitterLocation = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);

            particleSystem.Update();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            particleSystem.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
