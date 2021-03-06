﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    class Gameplay : Screen
    {
        GraphicsDevice graphics;
        SpriteBatch spriteBatch;
        private presentPlayerAnimationControll player;

        Texture2D atkAnimation1;
        Texture2D walkRightAnimation;
        Texture2D walkLeftAnimation;
        Texture2D atkAnimation2;
        Texture2D jumpingRight;
        Texture2D jumpingLeft;

        Texture2D BackGroundPresent;
        Rectangle backGround = new Rectangle(0, -120, 1600, 600);

        Texture2D brokenFireRight;
        Texture2D brokenFireLeft;
        Texture2D brokenJumpLeft;
        Texture2D brokenJumpRight;
        Texture2D brokenWalkLeft;
        Texture2D brokenWalkRight;

        Texture2D robotBlasterBullet;
        Texture2D robotFireLeft;
        Texture2D robotFireRight;
        Texture2D robotJumpLeft;
        Texture2D robotJumpRight;
        Texture2D robotWalkLeft;
        Texture2D robotWalkRight;
        Texture2D robot;

        Texture2D fShadowAttackLeft;
        Texture2D fShadowAttackRight;
        Texture2D fShadowJump;
        Texture2D fShadowWalkLeft;
        Texture2D fShadowWalkRight;

        Texture2D pShadowAttackLeft;
        Texture2D pShadowAttackRight;
        Texture2D pShadowJump;
        Texture2D pShadowWalkLeft;
        Texture2D pShadowWalkRight;

        Texture2D presentShadowAttackLeft;
        Texture2D presentShadowAttackRight;
        Texture2D presentShadowJump;
        Texture2D presentShadowWalkLeft;
        Texture2D presentShadowWalkRight;

        Texture2D skull1Left;
        Texture2D skull2Left;
        Texture2D skull1Right;
        Texture2D skull2Right;
        Texture2D skullProjectileLeft;
        Texture2D skullProjecctileRight;

        Vector2 startingPoint = new Vector2(200, 200);


        Vector2 Flame1Position = new Vector2(-500, -500);
        Vector2 Flame2Position = new Vector2(-500, -500);

        bool isRightKeyDown;
        bool isLeftKeyDown;
        bool isAtkKeyDown;
        bool facingLeft;
        bool facingRight;
        bool jumpKeyDown;

        public Rectangle playerSpriteBounds;
        public Rectangle enemySpriteBounds;

        public Gameplay()
        {
            //graphics = new GraphicsDeviceManager(this);
            //Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        public override void LoadContent(ContentManager Content)
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            //spriteBatch = new SpriteBatch(graphics);

            // TODO: use this.Content to load your game content here
            BackGroundPresent = Content.Load<Texture2D>("Present Map Layout");

            atkAnimation1 = Content.Load<Texture2D>("present slash right");
            walkRightAnimation = Content.Load<Texture2D>("present walking right");
            walkLeftAnimation = Content.Load<Texture2D>("present walking left");
            atkAnimation2 = Content.Load<Texture2D>("present slash left");
            jumpingRight = Content.Load<Texture2D>("presentjumpright");
            jumpingLeft = Content.Load<Texture2D>("presentjumpleft");

            player = new presentPlayerAnimationControll(atkAnimation1, 1, 2, walkRightAnimation, 1, 3, walkLeftAnimation, 1, 3, atkAnimation2, 1, 2, jumpingRight, 1, 1, jumpingLeft, 1, 1);
            playerSpriteBounds = new Rectangle((int)startingPoint.X, (int)startingPoint.Y, player.TextureCur.Width / player.curTextureColumns, player.TextureCur.Height / player.curTextureRows);

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        public void UnloadContent(ContentManager Content)
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime, GraphicsDevice graphicsDevice)
        {
            Vector2 oldPosition = startingPoint;
            // Allows the game to exit

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                isRightKeyDown = false;
                isLeftKeyDown = true;
                isAtkKeyDown = false;
                jumpKeyDown = false;
                facingRight = false;
                facingLeft = true;
                player.ChangeCurrentTexture(isRightKeyDown, isLeftKeyDown, isAtkKeyDown, jumpKeyDown, facingRight, facingLeft);
                startingPoint.X -= 2;
                player.Update();
                if (backGround.X <= 800)
                {
                    backGround.X += 4;
                }
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                isRightKeyDown = true;
                isLeftKeyDown = false;
                isAtkKeyDown = false;
                jumpKeyDown = false;
                facingRight = true;
                facingLeft = false;
                player.ChangeCurrentTexture(isRightKeyDown, isLeftKeyDown, isAtkKeyDown, jumpKeyDown, facingRight, facingLeft);
                startingPoint.X += 2;
                player.Update();
                if (backGround.X >= -800)
                {
                    backGround.X -= 4;
                }
            }

            else if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                isRightKeyDown = false;
                isLeftKeyDown = false;
                isAtkKeyDown = false;
                jumpKeyDown = true;

                player.ChangeCurrentTexture(isRightKeyDown, isLeftKeyDown, isAtkKeyDown, jumpKeyDown, facingRight, facingLeft);
                startingPoint.Y -= 2;
                player.Update();
            }

            else if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                startingPoint.Y += 2;
            }

            else if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                isRightKeyDown = false;
                isLeftKeyDown = false;
                isAtkKeyDown = true;
                jumpKeyDown = false;
                player.ChangeCurrentTexture(isRightKeyDown, isLeftKeyDown, isAtkKeyDown, jumpKeyDown, facingRight, facingLeft);
                player.Update();
            }

            else
            {
                if (isRightKeyDown == true)
                {
                    player.currentFrame = 1;
                }
                else if (isLeftKeyDown == true)
                {
                    player.currentFrame = 1;
                }
                else if (isAtkKeyDown == true)
                {
                    player.currentFrame = 0;
                }
            }

            playerSpriteBounds.X = (int)startingPoint.X;
            playerSpriteBounds.Y = (int)startingPoint.Y;

            // TODO: Add your update logic here
            /*if (!graphics.Viewport.Bounds.Contains(playerSpriteBounds))
            {
                startingPoint = oldPosition;
            }*/
            if (startingPoint.Y < 600)
            {
                startingPoint.Y += 4;
            }
            base.Update(gameTime, graphicsDevice);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            //graphics.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            

            spriteBatch.Begin();

            spriteBatch.Draw(BackGroundPresent, backGround, Color.White);

            spriteBatch.End();

            player.Draw(spriteBatch, startingPoint);

            base.Draw(spriteBatch);
        }
    }
}
