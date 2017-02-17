using System;
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
        private pastPlayerAnimationControll pastPlayerAnimationControll;

        Texture2D atkAnimation1;
        Texture2D walkRightAnimation;
        Texture2D walkLeftAnimation;
        Texture2D atkAnimation2;

        Vector2 startingPoint = new Vector2(200, 200);

        bool isRightKeyDown;
        bool isLeftKeyDown;
        bool isAtkKeyDown;
        bool facingLeft;
        bool facingRight;

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
        protected virtual void Initialize()
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
            spriteBatch = new SpriteBatch(graphics);

            // TODO: use this.Content to load your game content here
            atkAnimation1 = Content.Load<Texture2D>("Sword");
            walkRightAnimation = Content.Load<Texture2D>("Walking");
            walkLeftAnimation = Content.Load<Texture2D>("Walking2");
            atkAnimation2 = Content.Load<Texture2D>("sword2");

            pastPlayerAnimationControll = new pastPlayerAnimationControll(atkAnimation1, 1, 2, walkRightAnimation, 1, 3, walkLeftAnimation, 1, 3, atkAnimation2, 1, 2);
            playerSpriteBounds = new Rectangle((int)startingPoint.X, (int)startingPoint.Y, pastPlayerAnimationControll.TextureCur.Width / pastPlayerAnimationControll.curTextureColumns, pastPlayerAnimationControll.TextureCur.Height / pastPlayerAnimationControll.curTextureRows);

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected void UnloadContent(ContentManager Content)
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            Vector2 oldPosition = startingPoint;
            // Allows the game to exit

            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                isRightKeyDown = false;
                isLeftKeyDown = true;
                isAtkKeyDown = false;
                facingRight = false;
                facingLeft = true;
                pastPlayerAnimationControll.ChangeCurrentTexture(isRightKeyDown, isLeftKeyDown, isAtkKeyDown, facingRight, facingLeft);
                startingPoint.X -= 4;
                pastPlayerAnimationControll.Update();
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                isRightKeyDown = true;
                isLeftKeyDown = false;
                isAtkKeyDown = false;
                facingRight = true;
                facingLeft = false;
                pastPlayerAnimationControll.ChangeCurrentTexture(isRightKeyDown, isLeftKeyDown, isAtkKeyDown, facingRight, facingLeft);
                startingPoint.X += 4;
                pastPlayerAnimationControll.Update();
            }

            else if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                startingPoint.Y -= 4;
            }

            else if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                startingPoint.Y += 4;
            }

            else if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                isRightKeyDown = false;
                isLeftKeyDown = false;
                isAtkKeyDown = true;
                pastPlayerAnimationControll.ChangeCurrentTexture(isRightKeyDown, isLeftKeyDown, isAtkKeyDown, facingRight, facingLeft);
                pastPlayerAnimationControll.Update();
            }

            else
            {
                if (isRightKeyDown == true)
                {
                    pastPlayerAnimationControll.currentFrame = 1;
                }
                else if (isLeftKeyDown == true)
                {
                    pastPlayerAnimationControll.currentFrame = 1;
                }
                else if (isAtkKeyDown == true)
                {
                    pastPlayerAnimationControll.currentFrame = 0;
                }
            }

            playerSpriteBounds.X = (int)startingPoint.X;
            playerSpriteBounds.Y = (int)startingPoint.Y;

            // TODO: Add your update logic here
            if (!graphics.Viewport.Bounds.Contains(playerSpriteBounds))
            {
                startingPoint = oldPosition;
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Draw(SpriteBatch spriteBatch)
        {
            graphics.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            pastPlayerAnimationControll.Draw(spriteBatch, startingPoint);

            base.Draw(spriteBatch);
        }
    }
}
