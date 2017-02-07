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
    class ButtonCollision
    {
        private Texture2D buttonImage;
        private Rectangle buttonCollision;
        private Vector2 buttonPosition;
        private Vector2 mousePosition;
        private int rows;
        private int columns;
        private int currentFrame;
        private int totalFrames;
        private int counter = 0;
        int SPRITE_GAP = 3;

        public ButtonCollision(ContentManager Content, Vector2 ButtonPosition, string ButtonImage, int Columns, int Rows,int spriteGap)
        {
            rows = Rows;
            columns = Columns;
            currentFrame = 0;
            totalFrames = Rows * Columns;
            buttonPosition = ButtonPosition;
            buttonImage = Content.Load<Texture2D>(ButtonImage);
            SPRITE_GAP = spriteGap;
            buttonCollision = new Rectangle((int)ButtonPosition.X, (int)ButtonPosition.Y, buttonImage.Width/columns-SPRITE_GAP, buttonImage.Height/rows- SPRITE_GAP); 
        }

        public bool CheckMouseCollision(MouseState mousePosition)
        {
            return buttonCollision.Contains(mousePosition.X, mousePosition.Y);
        }

        public void Update(int delay)
        {
            if(counter >= delay)
            {
                currentFrame++;
                counter = 0;
                if (currentFrame == totalFrames)
                {
                    currentFrame = 0;
                }
            }
            counter++;
        }

        public void ResetFrame()
        {
            currentFrame = 0;
        }

        public void Draw (SpriteBatch spriteBatch, Color color)
        {
            spriteBatch.Draw(buttonImage, buttonCollision, color);

            int width  = buttonImage.Width / columns;
            int height = buttonImage.Height / rows;
            int row = (int)((float)currentFrame / (float)columns);
            int column = currentFrame % columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width-SPRITE_GAP, height- SPRITE_GAP);

            spriteBatch.Draw(buttonImage, buttonCollision, sourceRectangle, Color.White);
        }
    }
}
