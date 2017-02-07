using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace ChaosTriggerShatteredRealityMenus
{
    class CreditsScreen : Screen
    {
        private SpriteFont font;

        public CreditsScreen()
        {

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>

        public override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>

        public override void LoadContent(ContentManager Content)
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            font = Content.Load<SpriteFont>("Menu");
            nextScreen = "CreditsScreen";
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>

        public override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>

        public override void Update(GameTime gameTime)
        {
            KeyboardState state = Keyboard.GetState();
            if(state.IsKeyDown(Keys.Escape))
            {
                nextScreen = "MainMenu";
            }
            else
            {
                nextScreen = "CreditsScreen";
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(font, "Creators of the game:", new Vector2(150, 50), Color.Black);
            spriteBatch.DrawString(font, "Cameron Abrams", new Vector2(150, 150), Color.Black);
            spriteBatch.DrawString(font, "Cameron Pohl", new Vector2(150, 200), Color.Black);
            spriteBatch.DrawString(font, "Colin Holmes", new Vector2(150, 250), Color.Black);
            spriteBatch.DrawString(font, "Tristan Streeter", new Vector2(150, 300), Color.Black);
            spriteBatch.DrawString(font, ">>Main Menu: Press [Esc]", new Vector2(10, 450), Color.Black);
            spriteBatch.End();

        }
    }
}
