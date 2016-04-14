///Authors: Justin Mclennan and Chun-Yip Tang
///Last Updated April 13, 2016
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
        static string _type;
        static string _gametype;
        MouseState previousMouseState;
        Vector2 mposition;//mouse position
        Vector2 backb, chessb, checkersb, chineseb;
        Button back, chess, checkers, chinese;

        /// <summary>
        /// Constructor
        /// Initializes all buttons and board
        /// </summary>
        public Board() {
            //the back button
            backb = new Vector2(0, Game1.ScreenHeight - 50);
            //the Chess Button
            chessb = new Vector2(Game1.ScreenWidth - 200, 200);
            //the Checkers button
            checkersb = new Vector2(Game1.ScreenWidth - 200, 300);
            //The Chinese Checkers or Sterne-Halma button
            chineseb = new Vector2(Game1.ScreenWidth - 200, 400);
            //gives the back button functionality
            back = new Button(backb, "back", "");
            //gives the Chess button functionality
            chess = new Button(chessb, "blank", "Chess");
            //gives the Checkers button functionality
            checkers = new Button(checkersb, "blank", "Checkers");
            //gives the Chinese Checkers or Sterne-Halma button functionality
            chinese = new Button(chineseb, "blank", "Sterne-Halma");
            //initializes to the checkers board
            if (Game1.hosting) {
                currentGame = new Host_Intro();
                _type = "HIntro";
                _gametype = "HIntro";
            }
            else {
                currentGame = new Join_Intro();
                _type = "JIntro";
                _gametype = "JIntro";
            }
        }

        /// <summary>
        /// Abstract Method from extended GameType class that assigns the Type to be "Board"
        /// </summary>
        public override void LoadContent() {
            Type = "Board";
        }

        /// <summary>
        /// Automatic Update method that does things per tick
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime) {
            //tests for if the user has chosen to change the board type and changes it
            if (!_gametype.Equals(_type)) {
                _gametype = _type;
                currentGame.Type = _gametype;
            }
            switch (currentGame.Type) {
                case "HIntro":
                    currentGame = new Host_Intro();
                    break;
                case "JIntro":
                    currentGame = new Join_Intro();
                    break;
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
            //gets the current state of the mouse
            MouseState state = Mouse.GetState();
            mposition.X = state.X;
            mposition.Y = state.Y;

            //if the mouse was clicked
            if (previousMouseState.LeftButton == ButtonState.Pressed && state.LeftButton == ButtonState.Released) {
                MouseClicked((int)mposition.X, (int)mposition.Y);
            }
            previousMouseState = state;
            currentGame.Update(gameTime);
        }
        /// <summary>
        /// Basic Draw method from Monogames
        /// We use it to draw the background and call the boards to be drawn
        /// </summary>
        /// <param name="spriteBatch"></param>
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

        /// <summary>
        /// updates the board when called on from either Join class or Host class
        /// Used to update the board when the other user has moved a piece
        /// </summary>
        /// <param name="text"></param>
        public void UpdateBoard(string text) {
            if (text.Equals(""))
                return;
            string splitter = text;
            string[] separator = { " " };
            string[] split = splitter.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            if (!split[0].ToString().Equals(_type)) {
                _type = split[0].ToString();
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
            if (split.Length == 4) {
                currentGame.UpdateBoardServer(Int32.Parse(split[1]), Int32.Parse(split[2]), Int32.Parse(split[3]));
            }
        }

        /// <summary>
        /// Tells what a mouse click will do
        /// Have to implement with intersects and locations
        /// This one specifically deals with what happens when a change game button is pressed
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void MouseClicked(int x, int y) {
            Rectangle mouseRect = new Rectangle(x, y, 1, 1);
            Rectangle backRect = new Rectangle((int)backb.X, (int)backb.Y, 50, 50);
            if (Game1.hosting) {
                Rectangle chessRect = new Rectangle((int)chessb.X, (int)chessb.Y, 150, 50);
                Rectangle checkersRect = new Rectangle((int)checkersb.X, (int)checkersb.Y, 150, 50);
                Rectangle chineseRect = new Rectangle((int)chineseb.X, (int)chineseb.Y, 150, 50);
                if (mouseRect.Intersects(chessRect)) { //player clicks Chess

                    Host.Send(" " + "Chess");
                    if (_type != "Chess") {
                        currentGame.Type = "Chess";
                        _type = "Chess";
                    }
                }
                if (mouseRect.Intersects(checkersRect)) { //player clicks Checkers

                    Host.Send(" " + "Checkers");
                    if (_type != "Checkers") {
                        currentGame.Type = "Checkers";
                        _type = "Checkers";
                    }
                }
                if (mouseRect.Intersects(chineseRect)) { //player clicks CCheckers

                    Host.Send(" " + "ChineseCheckers");
                    if (_type != "ChineseCheckers") {
                        currentGame.Type = "ChineseCheckers";
                        _type = "ChineseCheckers";
                    }
                }
            }
            if (mouseRect.Intersects(backRect)) { //player clicks back button
                Game1.hosting = false;
                Game1.currentScreen.Type = "Menu";
                if (Game1.hosting)
                    Host.CloseAllSockets();

            }
        }
    }
}
