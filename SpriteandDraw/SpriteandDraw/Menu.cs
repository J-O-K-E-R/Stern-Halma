///Authors: Justin Mclennan and Chun-Yip Tang
///Last Updated April 13, 2016
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.BitmapFonts;
using ProjectName;

/// <summary>
/// The menu for the game
/// Shows the buttons of the screen on starting the program
/// </summary>
namespace SpriteandDraw {
    public class Menu : Screen {
        Vector2 mposition;//mouse position
        MouseState previousMouseState;
        int butmid = Game1.ScreenWidth / 2 - 75;
        Vector2 hostb;
        Vector2 joinb;
        Vector2 creditb;
        Button credit, host, join;

        /// <summary>
        /// Constructor that creates the location and buttons
        /// </summary>
        public Menu() {
            hostb = new Vector2(butmid, 300);
            joinb = new Vector2(butmid, 375);
            creditb = new Vector2(butmid, 450);
            host = new Button(hostb, "blank", "Host");
            join = new Button(joinb, "blank", "Join");
            credit = new Button(creditb, "blank", "Credits");

        }

        /// <summary>
        /// Basic load content of monogame
        /// </summary>
        public override void LoadContent() {
            Type = "Menu";
            
        }

        /// <summary>
        /// Updates the game per game tick
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime) {

            // Update our sprites position to the current cursor location
            MouseState state = Mouse.GetState();
            mposition.X = state.X;
            mposition.Y = state.Y;

            //System.Diagnostics.Debug.WriteLine(mposition.X.ToString() +
            //                      "," + mposition.Y.ToString());
            if (previousMouseState.LeftButton == ButtonState.Pressed && state.LeftButton == ButtonState.Released) {
                MouseClicked((int)mposition.X, (int)mposition.Y);
            }
            previousMouseState = state;
            base.Update(gameTime);
        }

        /// <summary>
        /// Draws the button onto the screen as well as the logo
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(Game1._backgroundTexture, new Rectangle(0, 0, Game1.graphics.GraphicsDevice.Viewport.Width, Game1.graphics.GraphicsDevice.Viewport.Height), Color.DarkSlateGray);
            host.Draw(spriteBatch);
            join.Draw(spriteBatch);
            credit.Draw(spriteBatch);
            spriteBatch.Draw(Game1.logo, new Vector2(Game1.ScreenWidth / 2 - 248, 175), null, Color.LightSeaGreen, 0f, Vector2.Zero, 1.0f, SpriteEffects.None, 0f);

        }

        /// <summary>
        /// Deals with when the mouse is clicked
        /// In this case, deals with what happens when hostRect is clicked, or joinRect is clicked
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void MouseClicked(int x, int y) {
            Rectangle mouseRect = new Rectangle(x, y, 1, 1);
            Rectangle hostRect = new Rectangle((int)hostb.X, (int)hostb.Y, 150, 50);
            Rectangle joinRect = new Rectangle((int)joinb.X, (int)joinb.Y, 150, 50);

            if (mouseRect.Intersects(hostRect)) { //player clicked play button
                Game1.currentScreen.Type = "PreGame";
            }

            if (mouseRect.Intersects(joinRect)) { //player clicked play button
                Game1.currentScreen.Type = "Setup";
            }
        }
    }
}
