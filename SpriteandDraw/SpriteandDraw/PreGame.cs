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

namespace SpriteandDraw {
    class PreGame : Screen {
        Vector2 mposition;//mouse position
        MouseState previousMouseState;
        Vector2 startb = new Vector2(Game1.ScreenWidth / 2 - 75, Game1.ScreenHeight / 2 - 150);
        Button start;
        //Chun this needs to fetch the computer ip instead of the default i put
        private string ip = "192.168.0.1";

        public PreGame() {
            start = new Button(startb, "blank", "Start");
        }

        public override void LoadContent() {
            Type = "PreGame";
        }
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
        public override void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(Game1._backgroundTexture, new Rectangle(0, 0, Game1.graphics.GraphicsDevice.Viewport.Width, Game1.graphics.GraphicsDevice.Viewport.Height), Color.DarkSlateGray);
            spriteBatch.DrawString(Game1.font,"Your IP: " + ip, new Vector2(Game1.ScreenWidth/2 - 110, Game1.ScreenHeight/2 - 200), Color.Black);
            start.Draw(spriteBatch);
        }

        public void MouseClicked(int x, int y) {
            Rectangle mouseRect = new Rectangle(x, y, 1, 1);
            Rectangle startRect = new Rectangle((int)startb.X, (int)startb.Y, 150, 50);
            if (mouseRect.Intersects(startRect)) { //player clicked back button
                System.Diagnostics.Debug.WriteLine("Pressed on button");
                Game1.currentScreen.Type = "Board";
            }
        }
    }
}
