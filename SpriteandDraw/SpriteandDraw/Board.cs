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
        public static GameType currentGame;
        MouseState previousMouseState;
        Vector2 mposition;//mouse position
        Vector2 backb, chessb, checkersb, chineseb;
        Button back, chess, checkers, chinese;

        public Board() {
            backb = new Vector2(0, Game1.ScreenHeight - 50);
            chessb = new Vector2(Game1.ScreenWidth - 200, 200);
            checkersb = new Vector2(Game1.ScreenWidth - 200, 300);
            chineseb = new Vector2(Game1.ScreenWidth - 200, 400);
            back = new Button(backb, "back", "");
            chess = new Button(chessb, "blank", "Chess");
            checkers = new Button(checkersb, "blank", "Checkers");
            chinese = new Button(chineseb, "blank", "Sterne-Halma");
            currentGame = new Checkers();
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
                case "Chess":
                    currentGame = new Chess();
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
            if (Game1.hosting) {
                chess.Draw(spriteBatch);
                checkers.Draw(spriteBatch);
                chinese.Draw(spriteBatch);
            }
            
        }
        public void UpdateBoard(string text) {
            string splitter = text;
            string[] separator = { " " };
            string[] split = splitter.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            currentGame.Type = split[0];
            currentGame.UpdateBoardServer(Int32.Parse(split[1]), Int32.Parse(split[2]), Int32.Parse(split[3]));
        }
        public void MouseClicked(int x, int y) {
            Rectangle mouseRect = new Rectangle(x, y, 1, 1);
            Rectangle backRect = new Rectangle((int)backb.X, (int)backb.Y, 50, 50);
            if (Game1.hosting) {
                Rectangle chessRect = new Rectangle((int)chessb.X, (int)chessb.Y, 150, 50);
                Rectangle checkersRect = new Rectangle((int)checkersb.X, (int)checkersb.Y, 150, 50);
                Rectangle chineseRect = new Rectangle((int)chineseb.X, (int)chineseb.Y, 150, 50);

                if (mouseRect.Intersects(chessRect)) { //player clicked back button
                    currentGame.Type = "Chess";
                }
                if (mouseRect.Intersects(checkersRect)) { //player clicked back button
                    currentGame.Type = "Checkers";
                }
                if (mouseRect.Intersects(chineseRect)) { //player clicked back button
                    currentGame.Type = "ChineseCheckers";
                }
            }
            if (mouseRect.Intersects(backRect))
            { //player clicked back button
                Game1.hosting = false;
                Game1.currentScreen.Type = "Menu";
            }

            }
        
    }
}
