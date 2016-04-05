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

namespace SpriteandDraw {
    public class Menu : Screen {
        Vector2 mposition;//mouse position
        MouseState previousMouseState;
        int butmid = Game1.ScreenWidth / 2 - 75;
        Vector2 hostb;
        Vector2 joinb;
        Vector2 creditb;
        Button credit, host, join;

        public Menu() {
            hostb = new Vector2(butmid, 300);
            joinb = new Vector2(butmid, 375);
            creditb = new Vector2(butmid, 450);
            host = new Button(hostb, "blank", "Host");
            join = new Button(joinb, "blank", "Join");
            credit = new Button(creditb, "blank", "Credits");

        }
        public override void LoadContent() {
            Type = "Menu";
        }
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
        public override void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(Game1._backgroundTexture, new Rectangle(0, 0, Game1.graphics.GraphicsDevice.Viewport.Width, Game1.graphics.GraphicsDevice.Viewport.Height), Color.DarkSlateGray);
            host.Draw(spriteBatch);
            join.Draw(spriteBatch);
            credit.Draw(spriteBatch);
            Rectangle stringRectangle = Game1.font.GetStringRectangle("Menu", new Vector2(Game1.ScreenWidth/2, 250));
            spriteBatch.DrawString(Game1.font, "Menu", new Vector2(Game1.ScreenWidth/2 - (stringRectangle.Width / 2), 250), Color.Black);

        }
        public void MouseClicked(int x, int y) {
            Rectangle mouseRect = new Rectangle(x, y, 1, 1);
            Rectangle hostRect = new Rectangle((int)hostb.X, (int)hostb.Y, 150, 50);
            Rectangle joinRect = new Rectangle((int)joinb.X, (int)joinb.Y, 150, 50);

            if (mouseRect.Intersects(hostRect)) { //player clicked play button
                Game1.currentScreen.Type = "PreGame";
                System.Diagnostics.Debug.WriteLine("Pressed on button");
            }

            if (mouseRect.Intersects(joinRect)) { //player clicked play button
                Game1.currentScreen.Type = "Setup";
                System.Diagnostics.Debug.WriteLine("Pressed on button");
            }
        }
    }
}
