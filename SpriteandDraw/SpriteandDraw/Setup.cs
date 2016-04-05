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


        public Setup() {
            test = new InputText(725, 450, 200, 25);
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
            spriteBatch.DrawString(Game1.font, "IP: ", new Vector2(690, 453), Color.Black);
        }

        public void MouseClicked(int x, int y) {

            Rectangle mouseRect = new Rectangle(x, y, 1, 1);
            Rectangle IP = new Rectangle((int)test.coor.X, (int)test.coor.Y, test.width, test.height);

            if (mouseRect.Intersects(IP)) { //player clicked play button
                test._cursor = true;
            }
            else {
                test._cursor = false;
            }
        }
    }
}