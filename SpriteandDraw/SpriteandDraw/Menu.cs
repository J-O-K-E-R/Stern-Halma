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
        Vector2 hostb = new Vector2(735, 300);
        Vector2 joinb = new Vector2(735, 375);
        Vector2 creditb = new Vector2(735, 450);
        Button credit, host, join;

        public Menu() {
            host = new Button(hostb, "blank");
            join = new Button(joinb, "blank");
            credit = new Button(creditb, "blank");
            
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
            if(previousMouseState.LeftButton == ButtonState.Pressed && state.LeftButton == ButtonState.Released)
            {
                MouseClicked((int)mposition.X, (int)mposition.Y);
            }
            previousMouseState = state;
            base.Update(gameTime);
        }
        public override void Draw(SpriteBatch spriteBatch) {
            host.Draw(spriteBatch);
            join.Draw(spriteBatch);
            credit.Draw(spriteBatch);
            spriteBatch.DrawString(Game1.font, "Menu", new Vector2(785, 250), Color.Black);
            spriteBatch.DrawString(Game1.font, "Host", new Vector2(790, 315), Color.Black);
            spriteBatch.DrawString(Game1.font, "Join", new Vector2(790, 390), Color.Black);
            spriteBatch.DrawString(Game1.font, "Credits", new Vector2(780, 465), Color.Black);

        }
        public void MouseClicked(int x, int y) {
            Rectangle mouseRect = new Rectangle(x, y, 1, 1);
            Rectangle hostRect = new Rectangle((int)hostb.X, (int)hostb.Y, 150, 50);
            Rectangle joinRect = new Rectangle((int)joinb.X, (int)joinb.Y, 150, 50);

            if (mouseRect.Intersects(hostRect)) { //player clicked play button
                Game1.currentScreen.Type = "Host";
                System.Diagnostics.Debug.WriteLine("Pressed on button");
            }

            if (mouseRect.Intersects(joinRect))
            { //player clicked play button
                Game1.currentScreen.Type = "Join";
                System.Diagnostics.Debug.WriteLine("Pressed on button");
            }
        }
    }
}
