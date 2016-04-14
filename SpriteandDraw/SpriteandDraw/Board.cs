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
        public GameType currentGame;
        static string _type = "Checkers";
        static string _gametype = "Checkers";
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

        public void UpdateBoard(string text) {
            if (text.Equals(""))
                return;
            //Console.WriteLine(text);
            string splitter = text;
            string[] separator = { " " };
            string[] split = splitter.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            if (!split[0].ToString().Equals(_type)) {
                _type = split[0].ToString();
                System.Diagnostics.Debug.WriteLine("Board gametype changed to " + split[0].ToString());
                switch (_type) {
                    case "ChineseCheckers":
                        currentGame.Type = "ChineseCheckers";
                        break;
                    case "Checkers":
                        currentGame.Type = "Checkers";
                        break;
                    case "Chess":
                        currentGame.Type = "Chess";
                        break;
                }
            }
            if (split.Length == 5) {
                currentGame.UpdateBoardServer(Int32.Parse(split[1]), Int32.Parse(split[2]), Int32.Parse(split[3]));
            }
        }

        public override void Update(GameTime gameTime) {
            if (!_gametype.Equals(_type)) {
                _gametype = _type;
                currentGame.Type = _gametype;
            }
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
        

        public void MouseClicked(int x, int y) {
            Rectangle mouseRect = new Rectangle(x, y, 1, 1);
            Rectangle backRect = new Rectangle((int)backb.X, (int)backb.Y, 50, 50);
            if (Game1.hosting) {
                Rectangle chessRect = new Rectangle((int)chessb.X, (int)chessb.Y, 150, 50);
                Rectangle checkersRect = new Rectangle((int)checkersb.X, (int)checkersb.Y, 150, 50);
                Rectangle chineseRect = new Rectangle((int)chineseb.X, (int)chineseb.Y, 150, 50);

                if (mouseRect.Intersects(chessRect)) { //player clicks chess
                    
                    Host.Send(" " + "Chess");
                    currentGame.Type = "Chess";
                }
                if (mouseRect.Intersects(checkersRect)) { //player clicks Checkers
                    
                    Host.Send(" " + "Checkers");
                    currentGame.Type = "Checkers";
                }
                if (mouseRect.Intersects(chineseRect)) { //player clicks CCheckers
                    
                    Host.Send(" " + "ChineseCheckers");
                    currentGame.Type = "ChineseCheckers";
                }
            }
            if (mouseRect.Intersects(backRect)) { //player clicks back button
                //Game1.hosting = false;
                //Game1.currentScreen.Type = "Menu";
                if (Game1.hosting)
                    Console.WriteLine("Host gametype" + _type);
                else {
                    Console.WriteLine("Client gametype" + _type);
                }

            }
        }        
    }
}
