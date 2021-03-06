﻿using System;
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
using System.Diagnostics;

namespace ChaosTriggerShatteredRealityMenus
{
    class Screen
    {
        private bool oldState;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        protected MouseState newState;
        protected string nextScreen;
        protected ButtonCollision exitButton;
        protected ButtonCollision backButton;
        protected ButtonCollision continueButton;
        protected ButtonCollision optionsButton;
        protected SpriteFont font;
        public string currentScreen;
        public SoundEffect buttonClickSound;

        public Screen()
        {
            oldState = true;
        }

        public virtual void Initialize()
        {
            
        }

        public virtual void LoadContent(ContentManager Content)
        {
            currentScreen = "TitleScreen";
            buttonClickSound = Content.Load<SoundEffect>("ButtonClick");
            Debug.WriteLine("Test");
        }

        public virtual void UnloadContent()
        {
            
        }

        public virtual void Update(GameTime gameTime, GraphicsDevice graphicsDevice)
        {
            newState = Mouse.GetState(); //Gets location of the mouse to see if it's colliding with buttons
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {

        }

        public string GetNextScreen()
        {
            return nextScreen;
        }
        public virtual void SetDefaultScreen()
        {
            
        }

        public bool MouseButtonClicked()
        {
            if (newState.LeftButton == ButtonState.Pressed && !oldState)
            {
                oldState = true;
                return true;
            }
            oldState = (newState.LeftButton == ButtonState.Pressed);
            return false;
        }     
    }
}
