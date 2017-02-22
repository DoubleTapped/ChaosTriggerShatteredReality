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
        private Texture2D armoredTurtle;

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void LoadContent(ContentManager Content)
        {
            base.LoadContent(Content);
            nextScreen = "MainMenu";
            playButton = new ButtonCollision(Content, new Vector2(350, 250), "Actual Play Highlight", 2, 14, 3);
            optionsButton = new ButtonCollision(Content, new Vector2(350, 300), "Options Highlight", 2, 14, 3);
            backButton = new ButtonCollision(Content, new Vector2(350, 350), "Back Button Highlight", 2, 14, 3);
            armoredTurtle = Content.Load<Texture2D>("Amrored Turtle");
            mainMenuBanner = Content.Load<Texture2D>("banner_mm");
            mainMenuBackground = Content.Load<Texture2D>("introbackground");
        }

        public override void UnloadContent()
        {
            
        }
        /// <summary>
        /// Updates screen if mouse collision is detected and mouse button clicked
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime, GraphicsDevice graphicsDevice)
        {
            base.Update(gameTime, graphicsDevice);

            if(playButton.CheckMouseCollision(newState))
            {
                playButton.Update(2);
                if(MouseButtonClicked())
                {
                    buttonClickSound.Play();
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
                    buttonClickSound.Play();
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
                if(MouseButtonClicked())
                {
                    buttonClickSound.Play();
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
            spriteBatch.Draw(mainMenuBackground, new Rectangle(0, 0, 800, 700), new Rectangle(0, 0, 800, 700), Color.White);
            spriteBatch.Draw(mainMenuBanner, new Rectangle(0, 0, 800, 200), new Rectangle(0, 0, 652, 253), Color.White);
            spriteBatch.Draw(armoredTurtle, new Rectangle(0, 400, 97, 91), new Rectangle(0, 400, 287, 273), Color.White);
            playButton.Draw(spriteBatch, Color.White);
            backButton.Draw(spriteBatch, Color.White);
            optionsButton.Draw(spriteBatch, Color.White);
            spriteBatch.End();
            //287x273
        }
        public override void SetDefaultScreen()
        {
            nextScreen = "MainMenu";
        }
    }
}
