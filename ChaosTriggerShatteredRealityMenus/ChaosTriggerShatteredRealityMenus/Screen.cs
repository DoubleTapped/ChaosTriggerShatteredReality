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

namespace ChaosTriggerShatteredRealityMenus
{
    class Screen
    {
        private SpriteFont font;
        private MouseState oldState;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        protected MouseState newState;
        protected string nextScreen;

        public Screen()
        {

        }

        public virtual void Initialize()
        {

        }

        public virtual void LoadContent(ContentManager Content)
        {

        }

        public virtual void UnloadContent()
        {
            
        }

        public virtual void Update(GameTime gameTime)
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
            if (newState.LeftButton == ButtonState.Pressed && oldState.LeftButton == ButtonState.Released)
            {
                oldState = newState;
                return true;
            }
            oldState = newState;
            return false;
        }     
    }
}