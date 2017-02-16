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
    class LoadMenu : Screen
    {
        private ButtonCollision loadButton;
        private ButtonCollision newGameButton;
        private Texture2D loadMenuBanner;
        private Texture2D loadBackground;

        public LoadMenu()
        {

        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void LoadContent(ContentManager Content)
        {
            font = Content.Load<SpriteFont>("Menu");
            nextScreen = "LoadMenu";
            loadButton = new ButtonCollision(Content, new Vector2(350, 250), "Load Sheet 2x14", 2, 14, 3);
            newGameButton = new ButtonCollision(Content, new Vector2(350, 300), "New Highlight Sheet", 2, 14, 3);
            continueButton = new ButtonCollision(Content, new Vector2(350, 350), "Continue Highlight Sheet", 4, 7, 3);
            backButton = new ButtonCollision(Content, new Vector2(350, 400), "Back Button Highlight", 2, 14, 3);
            loadMenuBanner = Content.Load<Texture2D>("banner_gm");
            loadBackground = Content.Load<Texture2D>("Amrored Turtle");
        }

        public override void UnloadContent()
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
           
            if(newGameButton.CheckMouseCollision(newState))
            {
                newGameButton.Update(2);
                if(MouseButtonClicked())
                {
                    nextScreen = "Gameplay";
                }
                else
                {
                    nextScreen = "LoadMenu";
                }                
            }
            else if(loadButton.CheckMouseCollision(newState))
            {
                loadButton.Update(2);
                if(MouseButtonClicked())
                {
                    nextScreen = "MainMenu";
                }
                else
                {
                    nextScreen = "LoadMenu";
                }
            }
            else if(backButton.CheckMouseCollision(newState))
            {
                backButton.Update(2);
                if(MouseButtonClicked())
                {
                    nextScreen = "MainMenu";
                }
                else
                {
                    nextScreen = "LoadMenu";
                }
            }
            else if(continueButton.CheckMouseCollision(newState))
            {
                continueButton.Update(2);
                if(MouseButtonClicked())
                {
                    nextScreen = "MainMenu";
                }
                else
                {
                    nextScreen = "LoadMenu";
                }
            }
            else
            {
                nextScreen = "LoadMenu";
                newGameButton.ResetFrame();
                loadButton.ResetFrame();
                continueButton.ResetFrame();
                backButton.ResetFrame();
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(font, "Welcome to CHAOS_TRIGG3R: SHATT3R3D R3ALTIY", new Vector2(150, 50), Color.Black);
            loadButton.Draw(spriteBatch, Color.White);
            newGameButton.Draw(spriteBatch, Color.White);
            continueButton.Draw(spriteBatch, Color.White);
            backButton.Draw(spriteBatch, Color.White);
            spriteBatch.Draw(loadMenuBanner, new Rectangle(0, 0, 800, 200), new Rectangle(0, 0, 652, 253), Color.White);
            spriteBatch.Draw(loadBackground, new Rectangle(100, 200, 112, 82), new Rectangle(100, 200, 224, 164), Color.White);
            spriteBatch.End();
        }
        public override void SetDefaultScreen()
        {
            nextScreen = "LoadMenu";
        }
    }
}



