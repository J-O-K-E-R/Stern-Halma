using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.BitmapFonts;
using MonoGame.Extended.InputListeners;
using ProjectName;

namespace SpriteandDraw {
    class Setup : Screen {
        InputText test;
        Vector2 mposition;//mouse position
        MouseState previousMouseState;
        Join joining = new Join();
        Button Connect;
        Vector2 joinb;
        Vector2 backb;
        Button back;

        public Setup() {
            joinb = new Vector2(Game1.ScreenWidth / 2 - 75, Game1.ScreenHeight/2 - 55);
            Connect = new Button(joinb, "blank", "Connect");
            test = new InputText(Game1.ScreenWidth/2 - 90, Game1.ScreenHeight/2 - 100, 200, 25);
            backb = new Vector2(0, Game1.ScreenHeight - 50);
            back = new Button(backb, "back", "");
            var mouseListener = Game1.inputManager.AddListener(new MouseListenerSettings());

        }
        public override void LoadContent() {
            Type = "Setup";
        }

        public override void Update(GameTime gameTime) {
            MouseState state = Mouse.GetState();
            mposition.X = state.X;
            mposition.Y = state.Y;

            if (previousMouseState.LeftButton == ButtonState.Pressed && state.LeftButton == ButtonState.Released) {
                MouseClicked((int)mposition.X, (int)mposition.Y);
            }
            previousMouseState = state;
            test.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch) {

            spriteBatch.Draw(Game1._backgroundTexture, new Rectangle(0, 0, Game1.graphics.GraphicsDevice.Viewport.Width, Game1.graphics.GraphicsDevice.Viewport.Height), Color.DarkSlateGray);
            test.Draw(spriteBatch);
            Connect.Draw(spriteBatch);
            back.Draw(spriteBatch);
            spriteBatch.DrawString(Game1.font, "IP: ", new Vector2(Game1.ScreenWidth/2 - 125, Game1.ScreenHeight/2 - 98), Color.Black);
        }

        public void MouseClicked(int x, int y) {

            Rectangle mouseRect = new Rectangle(x, y, 1, 1);
            Rectangle IP = new Rectangle((int)test.coor.X, (int)test.coor.Y, test.width, test.height);
            Rectangle joinRect = new Rectangle((int)joinb.X, (int)joinb.Y, 150, 50);
            Rectangle backRect = new Rectangle((int)backb.X, (int)backb.Y, 50, 50);

            if (mouseRect.Intersects(backRect)) { //player clicked back button
                Game1.currentScreen.Type = "Menu";
            }

            if (mouseRect.Intersects(IP)) { //player clicked play button
                test._cursor = true;
            }
            else {
                test._cursor = false;
            }
            if (mouseRect.Intersects(joinRect)) { //player clicked play button
                //this gets the ip intered when connect is hit
                string ta = test.tempstring;

                //this is where you connect it
                //this will switch the screen to the board if successful
                //test for string for ip
                joining.ConnectToServer(ta);
                Game1.currentScreen.Type = "Board";
                System.Diagnostics.Debug.WriteLine(ta.Length);
            }
        }
    }
}