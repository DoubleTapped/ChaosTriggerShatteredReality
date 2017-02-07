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
    class CognitiveMediaScreen : Screen
    {
        private SpriteFont font;
        private Texture2D titleSprite;
        private Texture2D BrenthesdaLogo;
        private int waitTime;

        public CognitiveMediaScreen()
        {

        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void LoadContent(ContentManager Content)
        {
            font = Content.Load<SpriteFont>("Menu");
            BrenthesdaLogo = Content.Load<Texture2D>("brenlogo");
            nextScreen = "cognitivemediaScreen";
        }

        public override void UnloadContent()
        {

        }

        public override void Update(GameTime gameTime)
        {
            if(waitTime <= 600)
            {
                waitTime++;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            if(waitTime < 200)
            {
                spriteBatch.DrawString(font, "Cognitive Thought Media Presents...", new Vector2(200, 50), Color.Black);
            }
            else if(waitTime < 600)
            {
                spriteBatch.DrawString(font, "A Brenthesda Production...", new Vector2(200, 50), Color.Black);
                spriteBatch.DrawString(font, "Programmers:", new Vector2(200, 100), Color.Black);
                spriteBatch.DrawString(font, "Cameron Abrams", new Vector2(200, 150), Color.Black);
                spriteBatch.DrawString(font, "Cameron Pohl", new Vector2(200, 200), Color.Black);
                spriteBatch.DrawString(font, "Visual Designers:", new Vector2(200, 300), Color.Black);
                spriteBatch.DrawString(font, "Colin Holmes", new Vector2(200, 350), Color.Black);
                spriteBatch.DrawString(font, "Tristan Streeter", new Vector2(200, 400), Color.Black);
                spriteBatch.Draw(BrenthesdaLogo, new Rectangle(0, 150, 200, 200), new Rectangle(0, 0, 700, 700), Color.White);
            }
            else
            {
                nextScreen = "TitleScreen";
            }
            spriteBatch.End();
        }
        public override void SetDefaultScreen()
        {
            nextScreen = "CognitiveMediaScreen";
        }
    }
}
