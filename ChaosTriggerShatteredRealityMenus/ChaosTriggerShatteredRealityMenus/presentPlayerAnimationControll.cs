using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace ChaosTriggerShatteredRealityMenus
{
    class presentPlayerAnimationControll
    {
        public Texture2D TextureAttack1 { get; set; }
        public Texture2D TextureAttack2 { get; set; }
        public Texture2D TextureWalkRight { get; set; }
        public Texture2D TextureWalkLeft { get; set; }
        public Texture2D TextureJumpRight { get; set; }
        public Texture2D TextureJumpLeft { get; set; }
        public Texture2D TextureCur { get; set; }

        public int AtkRows1 { get; set; }
        public int AtkColumns1 { get; set; }

        public int AtkRows2 { get; set; }
        public int AtkColumns2 { get; set; }

        public int WalkRightRows { get; set; }
        public int WalkRightColumns { get; set; }

        public int WalkLeftRows { get; set; }
        public int WalkLeftColumns { get; set; }

        public int JumpLeftRows { get; set; }
        public int JumpLeftColumns { get; set; }

        public int JumpRightRows { get; set; }
        public int JumpRightColumns { get; set; }

        public int atkTotalFrames1;
        public int atkTotalFrames2;
        public int walkRTotalFrames;
        public int walkLTotalFrames;
        public int jumpRTotalFrames;
        public int jumpLTotalFrames;

        public int currentFrame;
        public int curTextureTotalFrames;
        public int curTextureRows;
        public int curTextureColumns;

        public int counter = 0;


        public presentPlayerAnimationControll(Texture2D textureAttack, int atkRows, int atkColumns, Texture2D textureWalkRight, int walkRightRows, int walkRightColumns, Texture2D textureWalkLeft, int walkLeftRows, int walkLeftColumns, Texture2D textureAttack2, int atkRows2, int atkColumns2, Texture2D textureJumpRight, int jumpRightRows, int jumpRightColumns, Texture2D textureJumpLeft, int jumpLeftRows, int jumpLeftColumns)
        {
            TextureAttack1 = textureAttack;
            AtkRows1 = atkRows;
            AtkColumns1 = atkColumns;
            atkTotalFrames1 = AtkRows1 * AtkColumns1;

            TextureAttack2 = textureAttack2;
            AtkRows2 = atkRows2;
            AtkColumns2 = atkColumns2;
            atkTotalFrames2 = AtkRows2 * AtkColumns2;

            TextureWalkRight = textureWalkRight;
            WalkRightRows = walkRightRows;
            WalkRightColumns = walkRightColumns;
            walkRTotalFrames = WalkRightRows * WalkRightColumns;

            TextureWalkLeft = textureWalkLeft;
            WalkLeftRows = walkLeftRows;
            WalkLeftColumns = walkLeftColumns;
            walkLTotalFrames = WalkLeftRows * WalkLeftColumns;

            TextureJumpRight = textureJumpRight;
            JumpRightColumns = jumpRightColumns;
            JumpRightRows = jumpRightRows;
            jumpRTotalFrames = JumpRightRows * JumpRightColumns;

            TextureJumpLeft = textureJumpLeft;
            JumpLeftRows = jumpLeftRows;
            JumpLeftColumns = jumpLeftColumns;
            jumpLTotalFrames = JumpLeftRows * JumpLeftColumns;

            TextureCur = TextureAttack1;
            currentFrame = 0;

            curTextureTotalFrames = atkTotalFrames1;
            curTextureRows = AtkRows1;
            curTextureColumns = AtkColumns1;
        }

        public void ChangeCurrentTexture(bool rightKeyDown, bool leftKeyDown, bool atkKeyDown, bool jumpKeyDown, bool isFacingRight, bool isFacingLeft)
        {
            if (rightKeyDown == true && TextureCur != TextureWalkRight)
            {
                TextureCur = TextureWalkRight;
                curTextureRows = WalkRightRows;
                curTextureColumns = WalkRightColumns;
                curTextureTotalFrames = walkRTotalFrames;
            }
            else if (leftKeyDown == true && TextureCur != TextureWalkLeft)
            {
                TextureCur = TextureWalkLeft;
                curTextureRows = WalkLeftRows;
                curTextureColumns = WalkLeftColumns;
                curTextureTotalFrames = walkLTotalFrames;
            }
            else if (atkKeyDown == true && (TextureCur != TextureAttack1 || TextureCur != TextureAttack2))
            {
                if (isFacingRight == true)
                {
                    TextureCur = TextureAttack1;
                    curTextureRows = AtkRows1;
                    curTextureColumns = AtkColumns1;
                    curTextureTotalFrames = atkTotalFrames1;
                }
                else if (isFacingLeft == true)
                {
                    TextureCur = TextureAttack2;
                    curTextureRows = AtkRows2;
                    curTextureColumns = AtkColumns2;
                    curTextureTotalFrames = atkTotalFrames2;
                }
            }
            else if (jumpKeyDown == true  && (TextureCur != TextureJumpRight || TextureCur != TextureJumpLeft))
            {
                if (isFacingRight == true)
                {
                    TextureCur = TextureJumpRight;
                    curTextureRows = JumpRightRows;
                    curTextureColumns = JumpRightColumns;
                    curTextureTotalFrames = jumpRTotalFrames;
                }
                else if (isFacingLeft == true)
                {
                    TextureCur = TextureJumpLeft;
                    curTextureRows = JumpLeftRows;
                    curTextureColumns = JumpLeftColumns;
                    curTextureTotalFrames = jumpLTotalFrames;
                }
            }
            else
            {

            }
        }

        public void Update()
        {
            if (TextureCur == TextureJumpRight || TextureCur == TextureJumpLeft)
            {
                currentFrame = 0;
            }
            else
            {
                currentFrame++;

                if (currentFrame == curTextureTotalFrames)
                {
                    currentFrame = 0;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int width = TextureCur.Width / curTextureColumns;
            int height = TextureCur.Height / curTextureRows;
            int row = (int)((float)currentFrame / (float)curTextureColumns);
            int column = currentFrame % curTextureColumns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

            spriteBatch.Begin();
            spriteBatch.Draw(TextureCur, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
