using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace AssignmentCS2
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D minionBoo;
        Texture2D minionWalk;
        Rectangle booRect;
        Rectangle dstRect;
        Rectangle srcRect;
        
        LastBackground Lastrunning1;
        LastBackground Lastrunning2;

        ForeBackground Forerunning1;
        ForeBackground Forerunning2;
        ForeBackground Forerunning3;

        Middleground Pillar;

        float elapsed;
        float delay = 200f;
        int frames = 0;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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
            minionBoo = Content.Load<Texture2D>("SpriteSheet/MinionBoo");
            minionWalk = Content.Load<Texture2D>("SpriteSheet/MinionSprite");
            Lastrunning1 = new LastBackground(Content.Load<Texture2D>("SpriteSheet/LastBackgroundSprite1"), new Rectangle(0, -500, 1920, 1080));
            Lastrunning2 = new LastBackground(Content.Load<Texture2D>("SpriteSheet/LastBackgroundSprite2"), new Rectangle(1920, -500, 1920, 1080));
            Forerunning1 = new ForeBackground(Content.Load<Texture2D>("SpriteSheet/ForegroundSprite1"), new Rectangle(0, 370, 507, 304));
            Forerunning2 = new ForeBackground(Content.Load<Texture2D>("SpriteSheet/ForegroundSprite2"), new Rectangle(507, 370, 507, 304));
            Forerunning3 = new ForeBackground(Content.Load<Texture2D>("SpriteSheet/ForegroundSprite3"), new Rectangle(1014, 370, 507, 304));
            Pillar = new Middleground(Content.Load<Texture2D>("SpriteSheet/MiddlegroundSprite"), new Rectangle(0,0,600,600));
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            // Front and Back Scrolling Background
            
                if (Lastrunning1.rectangle.X + Lastrunning1.texture.Width <= 0)
                    Lastrunning1.rectangle.X = Lastrunning2.rectangle.X + Lastrunning2.texture.Width;
                if (Lastrunning2.rectangle.X + Lastrunning2.texture.Width <= 0)
                    Lastrunning2.rectangle.X = Lastrunning1.rectangle.X + Lastrunning1.texture.Width;

                if (Pillar.rectangle.X + Pillar.texture.Width <= 0)
                    Pillar.rectangle.X = Pillar.rectangle.X + 1100;

                if (Forerunning1.rectangle.X + Forerunning1.texture.Width <= 0)
                    Forerunning1.rectangle.X = Forerunning2.rectangle.X + Forerunning2.texture.Width;
                if (Forerunning2.rectangle.X + Forerunning2.texture.Width <= 0)
                    Forerunning2.rectangle.X = Forerunning3.rectangle.X + Forerunning3.texture.Width;
                if (Forerunning3.rectangle.X + Forerunning3.texture.Width <= 0)
                    Forerunning3.rectangle.X = Forerunning1.rectangle.X + Forerunning1.texture.Width;

                if (Lastrunning1.rectangle.X - Lastrunning1.texture.Width >= 0)
                    Lastrunning1.rectangle.X = Lastrunning2.rectangle.X - Lastrunning2.texture.Width;
                if (Lastrunning2.rectangle.X - Lastrunning2.texture.Width >= 0)
                    Lastrunning2.rectangle.X = Lastrunning1.rectangle.X - Lastrunning1.texture.Width;

                if (Forerunning1.rectangle.X - Forerunning1.texture.Width >= 0)
                    Forerunning1.rectangle.X = Forerunning2.rectangle.X - Forerunning2.texture.Width;
                if (Forerunning2.rectangle.X - Forerunning2.texture.Width >= 0)
                    Forerunning2.rectangle.X = Forerunning3.rectangle.X - Forerunning3.texture.Width;
                if (Forerunning3.rectangle.X - Forerunning3.texture.Width >= 0)
                    Forerunning3.rectangle.X = Forerunning1.rectangle.X - Forerunning1.texture.Width;

                    Lastrunning1.update();
                    Lastrunning2.update();
                    Forerunning1.update();
                    Forerunning2.update();
                    Forerunning3.update();
                    Pillar.update();

                    elapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                    if (elapsed >= delay)
                    {
                        if (frames >= 8)
                        {
                            frames = 0;
                        }
                        else
                        {
                            frames++;
                        }
                        elapsed = 0;
                    }
                    booRect = new Rectangle(0, 100, minionBoo.Width, minionBoo.Height);
                    dstRect = new Rectangle(120, 330, minionWalk.Width / 8, minionWalk.Height);
                    srcRect = new Rectangle(minionWalk.Width / 8 * frames, 0, minionWalk.Width / 8, minionWalk.Height);
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
            Lastrunning1.draw(spriteBatch);
            Lastrunning2.draw(spriteBatch);
            Pillar.draw(spriteBatch);
            Forerunning1.draw(spriteBatch);
            Forerunning2.draw(spriteBatch);
            Forerunning3.draw(spriteBatch);
            spriteBatch.Draw(minionBoo, booRect, Color.White);
            spriteBatch.Draw(minionWalk, dstRect, srcRect, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
