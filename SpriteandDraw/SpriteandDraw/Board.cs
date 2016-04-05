﻿using System;
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
            currentGame = new Chess();
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
            chess.Draw(spriteBatch);
            checkers.Draw(spriteBatch);
            chinese.Draw(spriteBatch);
        }

        public void MouseClicked(int x, int y) {
            Rectangle mouseRect = new Rectangle(x, y, 1, 1);
            Rectangle backRect = new Rectangle((int)backb.X, (int)backb.Y, 50, 50);
            Rectangle chessRect = new Rectangle((int)chessb.X, (int)chessb.Y, 150, 50);
            Rectangle checkersRect = new Rectangle((int)checkersb.X, (int)checkersb.Y, 150, 50);
            Rectangle chineseRect = new Rectangle((int)chineseb.X, (int)chineseb.Y, 150, 50);
            if (mouseRect.Intersects(backRect)) { //player clicked back button
                Game1.currentScreen.Type = "Menu";
            }
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
    }
}
