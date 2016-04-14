using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonoGame.Extended.BitmapFonts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.InputListeners;

namespace SpriteandDraw {
    class Credits : Screen {

        Vector2 mposition;//mouse position
        MouseState previousMouseState;
        Vector2 backb;
        Button back;

        /// <summary>
        /// Constructor that sets up the screen with buttons and where they should go
        /// Also tells the system that they are not hosting the game and is not the server
        /// Also adds MouseListenerStettings
        /// </summary>
        public Credits() {
            backb = new Vector2(0, Game1.ScreenHeight - 50);
            back = new Button(backb, "back", "");
            var mouseListener = Game1.inputManager.AddListener(new MouseListenerSettings());

        }

        /// <summary>
        /// Updates per gameTime tick
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime) {
            MouseState state = Mouse.GetState();
            mposition.X = state.X;
            mposition.Y = state.Y;

            /// Logs the position of the mouse click
            if (previousMouseState.LeftButton == ButtonState.Pressed && state.LeftButton == ButtonState.Released) {
                MouseClicked((int)mposition.X, (int)mposition.Y);
            }
            previousMouseState = state;
        }

        /// <summary>
        /// Basic monogame to laod textures and content
        /// </summary>
        public override void LoadContent() {
            Type = "Credits";
        }

        /// <summary>
        /// Draws all assets onto the screen. In this case, draws the buttons and the input box as well as some flavor text string
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch) {

            spriteBatch.Draw(Game1._backgroundTexture, new Rectangle(0, 0, Game1.graphics.GraphicsDevice.Viewport.Width, Game1.graphics.GraphicsDevice.Viewport.Height), Color.DarkSlateGray);
            back.Draw(spriteBatch);
            spriteBatch.DrawString(Game1.font, "Authors:", new Vector2(Game1.ScreenWidth / 2 - 125, Game1.ScreenHeight / 2 - 118), Color.Black);
            spriteBatch.DrawString(Game1.font, "Justin McLennan", new Vector2(Game1.ScreenWidth / 2 - 125, Game1.ScreenHeight / 2 - 98), Color.Black);
            spriteBatch.DrawString(Game1.font, "Chun-Yip Tang", new Vector2(Game1.ScreenWidth / 2 - 125, Game1.ScreenHeight / 2 - 78), Color.Black);
        }

        /// <summary>
        /// Deals with when the mouse is clicked.
        /// In this case, when each of the buttons is clicked
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void MouseClicked(int x, int y) {

            Rectangle mouseRect = new Rectangle(x, y, 1, 1);
            Rectangle backRect = new Rectangle((int)backb.X, (int)backb.Y, 50, 50);

            if (mouseRect.Intersects(backRect)) { //player clicked back button
                Game1.currentScreen.Type = "Menu";
            }
        }
    }
}
