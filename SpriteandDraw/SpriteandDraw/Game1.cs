using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;
using System.Linq;
using MonoGame.Extended;
using MonoGame.Extended.BitmapFonts;
using MonoGame.Extended.InputListeners;
using ProjectName;

namespace SpriteandDraw {

    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game {
        public static GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public static Texture2D logo;
        public static Texture2D _backgroundTexture;
        public static Screen currentScreen;
        public static BitmapFont font;
        public static InputListenerManager inputManager;
        public static int ScreenWidth, ScreenHeight;

        //private double score = 0;

        public Game1() {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1600;  // set this value to the desired width of your window
            ScreenWidth = 1600;
            ScreenHeight = 900;
            graphics.PreferredBackBufferHeight = 900;   // set this value to the desired height of your window
            graphics.ApplyChanges();
            Content.RootDirectory = "Content";

        }
        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize() {
            // TODO: Add your initialization logic here
            inputManager = new InputListenerManager();
            this.IsMouseVisible = true;
            currentScreen = new Menu();
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent() {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Circle.LoadContent(Content);
            Button.LoadContent(Content);
            ChinesePeice.LoadContent(Content);
            logo = Content.Load<Texture2D>("Logo");
            _backgroundTexture = Content.Load<Texture2D>("vignette");
            font = Content.Load<BitmapFont>("alphabet");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent() {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            switch (currentScreen.Type) {
                case "Menu":
                    currentScreen = new Menu();
                    break;
                case "PreGame":
                    currentScreen = new PreGame();
                    break;
                case "Board":
                    currentScreen = new Board();
                    break;
                case "Setup":
                    currentScreen = new Setup();
                    break;
            }
            currentScreen.Update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            currentScreen.Draw(spriteBatch);
            //spriteBatch.DrawString(font, "Menu", new Vector2(735, 100), Color.Black);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
