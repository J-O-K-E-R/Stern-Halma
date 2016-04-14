///Authors: Justin Mclennan and Chun-Yip Tang
///Last Updated April 13, 2016
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using ProjectName;

/// <summary>
/// used to create a checkers game and populate the board
/// </summary>
namespace SpriteandDraw {
    class Checkers : GameType {
        GameType currentGame;
        Texture2D rectr, rectb;
        SpriteBatch spriteBatch;
        static CheckersPiece[] pieces = new CheckersPiece[24];
        static Rectangle[] list = new Rectangle[24];
        static GamePiece current = new CheckersPiece();
        MouseState previousMouseState;
        Vector2 mposition;//mouse position

        /// <summary>
        /// Constructor that creates the board and adds the pieces to the board
        /// </summary>
        public Checkers() {
            CreateBoard();
            AddPiece();
        }

        /// <summary>
        /// Automatic method to load content in monogame
        /// </summary>
        public override void LoadContent() {
            Type = "Checkers";
        }
        /// <summary>
        /// updates the game based on gametime
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime) {
            MouseState state = Mouse.GetState();
            mposition.X = state.X;
            mposition.Y = state.Y;
            if (previousMouseState.LeftButton == ButtonState.Pressed && state.LeftButton == ButtonState.Pressed && current._isPressed) {

                current.position.X = mposition.X - 50;
                current.position.Y = mposition.Y - 50;
                ///Doesn't work if we have just 1 big string at the top for some reason
                if (Game1.hosting == true) {
                    string sending = " " + "Checkers" + " " + current.pieceNo + " " + current.position.X + " " + current.position.Y + " ";
                    Host.Send(sending);
                }
                else {
                    string sending = " " + "Checkers" + " " + current.pieceNo + " " + current.position.X + " " + current.position.Y + " ";
                    Join.Send(sending);
                }
            }
            ///What happens if a piece is pressed
            if (state.LeftButton == ButtonState.Pressed && !current._isPressed) {
                MousePressed((int)mposition.X, (int)mposition.Y);
            }
            ///What happens when a piece is released
            if (previousMouseState.LeftButton == ButtonState.Pressed && state.LeftButton == ButtonState.Released) {
                current._isPressed = false;
                current = new CheckersPiece();
            }
            previousMouseState = state;
        }

        /// <summary>
        /// Automatic method to draw all the pieces on the board 
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch) {
            this.spriteBatch = spriteBatch;
            spriteBatch.Draw(Game1._backgroundTexture, new Rectangle(0, 0, Game1.graphics.GraphicsDevice.Viewport.Width, Game1.graphics.GraphicsDevice.Viewport.Height), Color.DarkSlateGray);

            for (int i = 1; i <= 8; i++) {
                for (int j = 1; j <= 8; j++) {
                    if ((i + j) % 2 == 0)
                        spriteBatch.Draw(rectr, new Vector2(300 + (100 * i), (100 * j) - 50), Color.White);
                    else
                        spriteBatch.Draw(rectb, new Vector2(300 + (100 * i), (100 * j) - 50), Color.White);
                }
            }
            for (int i = 0; i < pieces.Length; i++)
                pieces[i].Draw(spriteBatch);

        }

        /// <summary>
        /// Updates the board from the client server
        /// </summary>
        /// <param name="pieceno"></param>
        /// <param name="xpos"></param>
        /// <param name="ypos"></param>
        public override void UpdateBoardServer(int pieceno, int xpos, int ypos) {
            pieces[pieceno].position.X = xpos;
            pieces[pieceno].position.Y = ypos;
        }

        /// <summary>
        /// Creates a new Checkers board
        /// </summary>
        public void CreateBoard() {
            Color[] red = new Color[100 * 100];
            rectr = new Texture2D(Game1.graphics.GraphicsDevice, 100, 100);
            for (int i = 0; i < red.Length; i++)
                red[i] = Color.DarkRed;
            rectr.SetData(red);

            Color[] black = new Color[100 * 100];
            rectb = new Texture2D(Game1.graphics.GraphicsDevice, 100, 100);
            for (int i = 0; i < black.Length; i++)
                black[i] = Color.Black;
            rectb.SetData(black);
        }

        /// <summary>
        /// Adds the pieces to the board
        /// </summary>
        public void AddPiece() {
            int count = 0;
            for (int i = 1; i <= 8; i++) {
                for (int j = 1; j < 4; j++) {
                    if ((i + j) % 2 != 0) {
                        pieces[count] = (new CheckersPiece(new Vector2(300 + (100 * i), (100 * j) - 50), 'b'));
                        pieces[count].pieceNo = count;
                        count++;
                    }
                }
            }
            for (int i = 8; i >= 1; i--) {
                for (int j = 8; j > 5; j--) {
                    if ((i + j) % 2 != 0) {
                        pieces[count] = (new CheckersPiece(new Vector2(300 + (100 * i), (100 * j) - 50), 'r'));
                        pieces[count].pieceNo = count;
                        count++;
                    }
                }
            }
        }

        /// <summary>
        /// What happens on mouse press
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void MousePressed(int x, int y) {
            Rectangle mouseRect = new Rectangle(x, y, 1, 1);
            for (int i = 0; i < pieces.Length; i++) {
                list[i] = (new Rectangle((int)pieces[i].position.X, (int)pieces[i].position.Y, 100, 100));
            }

            for (int i = 0; i < list.Length; i++) {
                if (mouseRect.Intersects(list[i])) {
                    current = pieces[i];
                    current._isPressed = true;
                    break;
                }
            }
        }
    }
}
