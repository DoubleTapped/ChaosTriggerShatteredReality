using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace ChaosTriggerShatteredRealityMenus
{
    public class ScreenManager : Microsoft.Xna.Framework.Game
    {
        public Song menuMusic;
        public Song bossMusic;
        public Song bossPrefightMusic;
        public Song gameMusic;
        public Song openingMusic;
        public Song tutorialMusic;
        public Song victoryMusic;
        private SpriteFont font;
        private int score = 0;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D newHighlightSheet;
        MainMenu mainMenu;
        LoadMenu loadMenu;
        Screen currentScreen;
        Screen previousScreen;
        OptionsMenu optionsMenu;
        TitleScreen titleScreen;
        CognitiveMediaScreen cognitiveMediaScreen;
        PauseMenu pauseMenu;
        Gameplay gameplay;

        public ScreenManager()
        {
            //Enables mouse
            this.IsMouseVisible = true;

            //Initializes menu classes
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            mainMenu = new MainMenu();
            loadMenu = new LoadMenu();
            optionsMenu = new OptionsMenu();
            titleScreen = new TitleScreen();
            cognitiveMediaScreen = new CognitiveMediaScreen();
            pauseMenu = new PauseMenu();
            gameplay = new Gameplay();    
        }

        protected override void Initialize()
        {
            base.Initialize();
        }
        /// <summary>
        /// Loading in classes and game music (later loads in backgrounds and buttons)
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            mainMenu.LoadContent(Content);
            loadMenu.LoadContent(Content);
            optionsMenu.LoadContent(Content);
            titleScreen.LoadContent(Content);
            cognitiveMediaScreen.LoadContent(Content);
            pauseMenu.LoadContent(Content);
            gameplay.LoadContent(Content);
            MediaPlayer.IsRepeating = true;
            menuMusic = Content.Load<Song>("Menu Music");
            bossMusic = Content.Load<Song>("Boss Music");
            bossPrefightMusic = Content.Load<Song>("Final Boss Prefight");
            gameMusic = Content.Load<Song>("Game Music");
            openingMusic = Content.Load<Song>("March of the C's");
            tutorialMusic = Content.Load<Song>("Tutorial Music");
            victoryMusic = Content.Load<Song>("Victory");
            currentScreen = cognitiveMediaScreen;
            Content.Load<Texture2D>("New Highlight Sheet");
            MediaPlayer.Play(this.menuMusic);
        }

        protected override void UnloadContent()
        {
            
        }

        /// <summary>
        /// Updates location of mouse and checks for button collision (then updates the screen if button collsion and click is detected)
        /// </summary>
        /// <param name="gameTime"></param>
        protected override void Update(GameTime gameTime)
        {        
            previousScreen = currentScreen;
            string oldScreen = currentScreen.GetNextScreen();
            currentScreen.Update(gameTime, GraphicsDevice);
            if(currentScreen.GetNextScreen() == "MainMenu")
            {
                optionsMenu.previousScreen = "MainMenu";
                currentScreen = mainMenu;
            }

            else if(currentScreen.GetNextScreen() == "LoadMenu")
            {               
                currentScreen = loadMenu;
            }

            else if(currentScreen.GetNextScreen() == "OptionsMenu")
            {
                currentScreen = optionsMenu;
            }

            else if(currentScreen.GetNextScreen() == "TitleScreen")
            {
                currentScreen = titleScreen;
            }

            else if(currentScreen.GetNextScreen() == "cognitivemediaScreen")
            {
                currentScreen = cognitiveMediaScreen;
            }

            else if(currentScreen.GetNextScreen() == "PauseMenu")
            {
                optionsMenu.previousScreen = "PauseMenu";
                currentScreen = pauseMenu;
            }

            else if(currentScreen.GetNextScreen() == "Gameplay")
            {
                currentScreen = gameplay;
            }

            string newScreen = currentScreen.GetNextScreen();
            if(oldScreen != newScreen)
            {
                previousScreen.SetDefaultScreen();
            }

        }

        protected override void Draw(GameTime gameTime) //Draws basic window and content on screen
        {
            GraphicsDevice.Clear(Color.DarkTurquoise);
            currentScreen.Draw(spriteBatch);
            base.Draw(gameTime);
        }
    }
}
