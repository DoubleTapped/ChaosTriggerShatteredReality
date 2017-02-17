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
    class TitleScreen : Screen
    {
        private Texture2D titleSprite;
        private Texture2D titleScreenBackground;

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void LoadContent(ContentManager Content) //Loads title screen with sprites and buttons
        {
            base.LoadContent(Content);
            nextScreen = "TitleScreen";
            font = Content.Load<SpriteFont>("Menu");
            titleSprite = Content.Load<Texture2D>("CTSR Title WIP");
            exitButton = new ButtonCollision(Content, new Vector2(25, 400), "Exit Highlight", 2, 14, 3);
            titleScreenBackground = Content.Load<Texture2D>("background");
        }

        public override void UnloadContent()
        {
            
        }

        public override void Update(GameTime gameTime, GraphicsDevice graphicsDevice) //Checks for either the enter key to be pressed or the Exit button to be clicked
        {
            base.Update(gameTime, graphicsDevice);
            KeyboardState state = Keyboard.GetState();
            if(state.IsKeyDown(Keys.Enter))
            {
                nextScreen = "MainMenu";
            }
            else if(exitButton.CheckMouseCollision(newState))
            {
                exitButton.Update(2);
                if(MouseButtonClicked())
                {
                    MediaPlayer.IsRepeating = false;
                    buttonClickSound.Play();
                    Environment.Exit(0);
                }
                else //If previous conditions are not met, screen stays the same
                {
                    nextScreen = "TitleScreen";
                }
            }
            else //Resets the button sprite when there is no collision
            {
                exitButton.ResetFrame();
            }
        }

        public override void Draw(SpriteBatch spriteBatch) //Draws sprites
        {
            spriteBatch.Begin(); //Draws exit button and background sprites
            spriteBatch.Draw(titleScreenBackground, new Rectangle(0, 0, 800, 510), new Rectangle(0, 0, 700, 710), Color.White);
            spriteBatch.Draw(titleSprite, new Rectangle(0, 0, 752, 151), Color.White);
            exitButton.Draw(spriteBatch, Color.White);

            spriteBatch.End();
        }
        public override void SetDefaultScreen()
        {
            nextScreen = "TitleScreen";
        }
    }
}
