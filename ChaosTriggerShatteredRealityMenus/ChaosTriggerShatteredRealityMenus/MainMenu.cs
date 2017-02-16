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
    class MainMenu : Screen
    {
        private ButtonCollision playButton;
        private ButtonCollision optionsButton;
        private Texture2D mainMenuBanner;
        private Texture2D mainMenuBackground;

        public MainMenu()
        {

        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void LoadContent(ContentManager Content)
        {
            nextScreen = "MainMenu";
            playButton = new ButtonCollision(Content, new Vector2(350, 250), "Actual Play Highlight", 2, 14, 3);
            optionsButton = new ButtonCollision(Content, new Vector2(350, 300), "Options Highlight", 2, 14, 3);
            backButton = new ButtonCollision(Content, new Vector2(350, 350), "Back Button Highlight", 2, 14, 3);
            mainMenuBanner = Content.Load<Texture2D>("banner_mm");
        }

        public override void UnloadContent()
        {
            
        }
        /// <summary>
        /// Updates screen if mouse collision is detected and mouse button clicked
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if(playButton.CheckMouseCollision(newState))
            {
                playButton.Update(2);
                if(MouseButtonClicked())
                {
                    nextScreen = "LoadMenu";
                }
                else
                {
                    nextScreen = "MainMenu";                   
                }
            }
            else if(optionsButton.CheckMouseCollision(newState))
            {
                optionsButton.Update(2);
                if (MouseButtonClicked())
                {
                    nextScreen = "OptionsMenu";
                }
                else
                {
                    nextScreen = "MainMenu";
                }
            }
            else if(backButton.CheckMouseCollision(newState))
            {
                backButton.Update(2);
                if (MouseButtonClicked())
                {
                    nextScreen = "TitleScreen";
                }
                else
                {
                    nextScreen = "MainMenu";
                }
            }
            else
            {
                nextScreen = "MainMenu";
                optionsButton.ResetFrame();
                playButton.ResetFrame();
                backButton.ResetFrame();
            }
        }

        public override void Draw(SpriteBatch spriteBatch) //Draws buttons and backgrounds on screen
        {
            spriteBatch.Begin();
            spriteBatch.Draw(mainMenuBanner, new Rectangle(0, 0, 800, 200), new Rectangle(0, 0, 652, 253), Color.White);
            playButton.Draw(spriteBatch, Color.White);
            backButton.Draw(spriteBatch, Color.White);
            optionsButton.Draw(spriteBatch, Color.White);
            spriteBatch.End();
        }
        public override void SetDefaultScreen()
        {
            nextScreen = "MainMenu";
        }
    }
}
