using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace ChaosTriggerShatteredRealityMenus
{
    class OptionsMenu : Screen
    {
        private SpriteFont font;
        private Texture2D optionsMenuBanner;
        private Texture2D optionsBackground;
        private ButtonCollision backButton;
        private ButtonCollision plusButton;
        private ButtonCollision minusButton;
        private const int APP_COMMAND_MUTE = 0x80000;
        private const int APP_COMMAND_VOLUME_UP = 0xA0000;
        private const int APP_COMMAND_VOLUME_DOWN = 0x90000;
        private const int WM_APPCOMMAND = 0x319;


        public OptionsMenu()
        {

        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void LoadContent(ContentManager Content)
        {
            nextScreen = "OptionsMenu"; //Sets the current screen to options menu
            backButton = new ButtonCollision(Content, new Vector2(350, 350), "Back Button Highlight", 2, 14, 3); //Loads the back button
            plusButton = new ButtonCollision(Content, new Vector2(525, 300), "Plus Button", 2, 14, 3);
            minusButton = new ButtonCollision(Content, new Vector2(225, 300), "Minus Button", 2, 14, 3);
            font = Content.Load<SpriteFont>("Menu");
            optionsMenuBanner = Content.Load<Texture2D>("banner_op");
            optionsBackground = Content.Load<Texture2D>("background options");
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
                    nextScreen = "MainMenu";
                }
                else
                {
                    nextScreen = "OptionsMenu";
                }
            }
            else if(minusButton.CheckMouseCollision(newState))
            {
                minusButton.Update(2);
                if(MouseButtonClicked())
                {
                    MediaPlayer.Volume -= .1f; //Lowers music volume if minus button is clicked
                }
                else
                {
                    nextScreen = "OptionsMenu";
                }
            }
            else if(plusButton.CheckMouseCollision(newState))
            {
                plusButton.Update(2);
                if(MouseButtonClicked())
                {
                    MediaPlayer.Volume += .1f; //Raises music volume is plus button is clicked
                }
                else
                {
                    nextScreen = "OptionsMenu";
                }
            }
            else
            {
                nextScreen = "OptionsMenu"; //Resets the frames of the buttons if mouse isn't colliding with them
                backButton.ResetFrame();
                minusButton.ResetFrame();
                plusButton.ResetFrame();
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(); //Draws banner and buttons
            spriteBatch.Draw(optionsMenuBanner, new Rectangle(0, 0, 800, 200), new Rectangle(0, 0, 652, 253), Color.White);
            spriteBatch.Draw(optionsBackground, new Rectangle(0, 200, 800, 400), new Rectangle(0, 200, 800, 400), Color.White);
            spriteBatch.DrawString(font, "Volume", new Vector2(352, 300), Color.Black);
            minusButton.Draw(spriteBatch, Color.White);
            plusButton.Draw(spriteBatch, Color.White);
            backButton.Draw(spriteBatch, Color.White);
            spriteBatch.End();
        }
        public override void SetDefaultScreen()
        {
            nextScreen = "OptionsMenu";
        }
    }
}
