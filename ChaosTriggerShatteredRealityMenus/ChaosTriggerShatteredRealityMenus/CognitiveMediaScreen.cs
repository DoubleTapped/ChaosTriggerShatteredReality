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
        private Texture2D cognitiveMediaBackground;
        private int waitTime = 0;

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void LoadContent(ContentManager Content)
        {
            font = Content.Load<SpriteFont>("Menu");
            cognitiveMediaBackground = Content.Load<Texture2D>("introbackground");
            BrenthesdaLogo = Content.Load<Texture2D>("brenlogo");
            nextScreen = "cognitivemediaScreen";
        }

        public override void UnloadContent()
        {

        }

        public override void Update(GameTime gameTime, GraphicsDevice graphicsDevice)
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
                spriteBatch.Draw(cognitiveMediaBackground, new Rectangle(0, 0, 800, 700), Color.White);
                spriteBatch.DrawString(font, "Cognitive Thought Media Presents...", new Vector2(200, 50), Color.DarkCyan);
            }
            else if(waitTime < 600)
            {
                spriteBatch.Draw(cognitiveMediaBackground, new Rectangle(0, 0, 800, 700), Color.White);
                spriteBatch.DrawString(font, "A Brenthesda Production...", new Vector2(200, 50), Color.DarkCyan);
                spriteBatch.DrawString(font, "Programmers:", new Vector2(100, 100), Color.DarkCyan);
                spriteBatch.DrawString(font, "Cameron Abrams", new Vector2(100, 150), Color.Cyan);
                spriteBatch.DrawString(font, "Cameron Pohl", new Vector2(100, 200), Color.Cyan);
                spriteBatch.DrawString(font, "Visual Designers:", new Vector2(100, 300), Color.DarkCyan);
                spriteBatch.DrawString(font, "Colin Holmes", new Vector2(100, 350), Color.Cyan);
                spriteBatch.DrawString(font, "Tristan Streeter", new Vector2(100, 400), Color.Cyan);
                spriteBatch.Draw(BrenthesdaLogo, new Rectangle(600, 25, 200, 200), new Rectangle(0, 0, 700, 700), Color.White);
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
