﻿///Authors: Justin Mclennan and Chun-Yip Tang
///Last Updated April 13, 2016
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.BitmapFonts;
using ProjectName;

/// <summary>
/// Screen for when the user clicks on host from the main menu
/// </summary>
namespace SpriteandDraw {
    class PreGame : Screen {
        Vector2 mposition;//mouse position
        MouseState previousMouseState;
        Vector2 startb = new Vector2(Game1.ScreenWidth / 2 - 75, Game1.ScreenHeight / 2 - 150);
        Button start;
        Vector2 backb;
        Button back;
        private string ip;

        /// <summary>
        /// Constructor that places the buttons and creates a Host object 
        /// Also gets the ip address to start connections
        /// </summary>
        public PreGame() {
            backb = new Vector2(0, Game1.ScreenHeight - 50);
            back = new Button(backb, "back", "");
            start = new Button(startb, "blank", "Start");
            Host host = new Host();
            host.Create();
            ip = Host.hostAddress.ToString();
        }

        /// <summary>
        /// Basic monogame to load texture content
        /// </summary>
        public override void LoadContent() {
            Type = "PreGame";
        }

        /// <summary>
        /// Updates on gameTime tick
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime) {
            MouseState state = Mouse.GetState();
            mposition.X = state.X;
            mposition.Y = state.Y;

            //System.Diagnostics.Debug.WriteLine(mposition.X.ToString() +
            //                      "," + mposition.Y.ToString());
            if (previousMouseState.LeftButton == ButtonState.Pressed && state.LeftButton == ButtonState.Released) {
                MouseClicked((int)mposition.X, (int)mposition.Y);
            }
            previousMouseState = state;
        }

        /// <summary>
        /// Draws the IP string and the start game button
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(Game1._backgroundTexture, new Rectangle(0, 0, Game1.graphics.GraphicsDevice.Viewport.Width, Game1.graphics.GraphicsDevice.Viewport.Height), Color.DarkSlateGray);
            spriteBatch.DrawString(Game1.font,"Your IP: " + ip, new Vector2(Game1.ScreenWidth/2 - 110, Game1.ScreenHeight/2 - 200), Color.Black);
            start.Draw(spriteBatch);
            back.Draw(spriteBatch);
        }

        /// <summary>
        /// Method deals with when the mouse is clicked
        /// In this case, when the backRect is clicked and when startRect is clicked
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void MouseClicked(int x, int y) {
            Rectangle mouseRect = new Rectangle(x, y, 1, 1);
            Rectangle startRect = new Rectangle((int)startb.X, (int)startb.Y, 150, 50);
            Rectangle backRect = new Rectangle((int)backb.X, (int)backb.Y, 50, 50);

            if (mouseRect.Intersects(backRect)) { //player clicked back button
                Game1.currentScreen.Type = "Menu";
                Host.CloseAllSockets();
            }
            if (mouseRect.Intersects(startRect)) { //player clicked back button
                Game1.hosting = true;
                Game1.currentScreen.Type = "Board";

            }
        }
    }
}
