using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using ProjectName;

namespace SpriteandDraw {
    public class Board : Screen {
        GameType currentGame;
        MouseState previousMouseState;
        Vector2 mposition;//mouse position
        Vector2 backb;
        Button back;

        public Board() {
            backb = new Vector2(0, Game1.ScreenHeight - 30);
            back = new Button(backb, "back", "");
            currentGame = new ChineseCheckers();
        }
        public override void LoadContent() {
            Type = "Board";
        }

        public override void Update(GameTime gameTime) {
            switch (currentGame.Type) {
                case "ChineseCheckers":
                    currentGame = new ChineseCheckers();
                    break;
                case "Checkers":
                    currentGame = new Checkers();
                    break;

            }
            MouseState state = Mouse.GetState();
            mposition.X = state.X;
            mposition.Y = state.Y;
            
            if (previousMouseState.LeftButton == ButtonState.Pressed && state.LeftButton == ButtonState.Released) {
                MouseClicked((int)mposition.X, (int)mposition.Y);
            }
            previousMouseState = state;
            currentGame.Update(gameTime);
        }
        public override void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(Game1._backgroundTexture, new Rectangle(0, 0, Game1.ScreenWidth, Game1.ScreenHeight), Color.DarkSlateGray);
            currentGame.Draw(spriteBatch);
            back.Draw(spriteBatch);
        }

        public void MouseClicked(int x, int y) {
            Rectangle mouseRect = new Rectangle(x, y, 1, 1);
            Rectangle backRect = new Rectangle((int)backb.X, (int)backb.Y, 30, 30);
            if (mouseRect.Intersects(backRect)) { //player clicked back button
                Game1.currentScreen.Type = "Menu";
            }
        }        
    }
}
