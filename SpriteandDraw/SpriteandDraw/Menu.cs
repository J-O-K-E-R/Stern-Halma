using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ProjectName;

namespace SpriteandDraw {
    public class Menu : Screen {
        Vector2 mposition;//mouse position
        MouseState previousMouseState;
        Vector2 playb = new Vector2(735, 300);
        Vector2 hostb = new Vector2(735, 375);
        Vector2 joinb = new Vector2(735, 450);
        Button play, host, join;

        public Menu() {
            play = new Button(playb, "blank");
            host = new Button(hostb, "blank");
            join = new Button(joinb, "blank");
            
        }
        public override void LoadContent() {
            Type = "Menu";
        }
        public override void Update(GameTime gameTime) {

            // Update our sprites position to the current cursor location
            MouseState state = Mouse.GetState();
            mposition.X = state.X;
            mposition.Y = state.Y;

            //System.Diagnostics.Debug.WriteLine(position.X.ToString() +
            //                       "," + position.Y.ToString());
            if(previousMouseState.LeftButton == ButtonState.Pressed && state.LeftButton == ButtonState.Released)
            {
                MouseClicked((int)mposition.X, (int)mposition.Y);
            }
            previousMouseState = state;
            base.Update(gameTime);
        }
        public override void Draw(SpriteBatch spriteBatch) {
            play.Draw(spriteBatch);
            host.Draw(spriteBatch);
            join.Draw(spriteBatch);
            spriteBatch.DrawString(Game1.font, "Menu", new Vector2(785, 250), Color.Black);
            spriteBatch.DrawString(Game1.font, "Host", new Vector2(790, 315), Color.Black);
            spriteBatch.DrawString(Game1.font, "Join", new Vector2(790, 390), Color.Black);
            spriteBatch.DrawString(Game1.font, "Credits", new Vector2(780, 465), Color.Black);

        }
        public void MouseClicked(int x, int y) {
            Rectangle mouseRect = new Rectangle(x, y, 1, 1);
            Rectangle playRect = new Rectangle((int)playb.X, (int)playb.Y, 150, 50);

            if (mouseRect.Intersects(playRect)) { //player clicked play button
                Game1.currentScreen.Type = "Board";
                System.Diagnostics.Debug.WriteLine("Pressed on button");
            }
        }
    }
}
