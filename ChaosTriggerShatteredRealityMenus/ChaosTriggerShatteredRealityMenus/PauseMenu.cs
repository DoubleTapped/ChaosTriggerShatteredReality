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
    class PauseMenu : Screen
    {
        private SpriteFont font;
        private Texture2D pauseBanner;
        private ButtonCollision backButton;


        public override void Initialize()
        {
            base.Initialize();
        }

        public override void LoadContent(ContentManager Content)
        {
            nextScreen = "PauseMenu"; //Sets the current screen to pause menu
            font = Content.Load<SpriteFont>("Menu");
            backButton = new ButtonCollision(Content, new Vector2(350, 350), "Back Button Highlight", 2, 14, 3);
            pauseBanner = Content.Load<Texture2D>("pause menu");
        }

        public override void UnloadContent()
        {

        }
        
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if(backButton.CheckMouseCollision(newState))
            {
                backButton.Update(2);
                if(MouseButtonClicked())
                {
                    nextScreen = "MainMenu"; //Remember to set the screen to game screen
                }
                else
                {
                    nextScreen = "PauseMenu";
                }
            }
            /*else if(.CheckMouseCollision)
            {

            }*/
            else
            {
                nextScreen = "PauseMenu";
                backButton.ResetFrame();
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(); //Draws banner and buttons
            spriteBatch.Draw(pauseBanner, new Rectangle(0, 0, 800, 200), new Rectangle(0, 0, 652, 253), Color.White);
            backButton.Draw(spriteBatch, Color.White);
            spriteBatch.End();
        }
        public override void SetDefaultScreen()
        {
            nextScreen = "PauseMenu";
        }
    }
}

