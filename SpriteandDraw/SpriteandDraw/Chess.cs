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

namespace SpriteandDraw {
    class Chess : GameType {
        Texture2D rectw, rectb;
        SpriteBatch spriteBatch;
        ChessPiece[] pieces = new ChessPiece[32];
        Rectangle[] list = new Rectangle[32];
        GamePiece current = new CheckersPiece();
        MouseState previousMouseState;
        Vector2 mposition;//mouse position
        /// <summary>
        /// Constructor that creates the board and adds the pieces to the board
        /// </summary>
        public Chess() {
            CreateBoard();
            AddPiece();
        }
        /// <summary>
        /// Automatic method to load content in monogame
        /// </summary>
        public override void LoadContent() {
            Type = "Chess";
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
                if (Game1.hosting == true) {
                    string sending = "Chess" + " " + current.pieceNo + " " + current.position.X + " " + current.position.Y + " ";
                    //System.Diagnostics.Debug.WriteLine("Host sending");
                    Host.Send(sending);
                }
                else {
                    string sending = "Chess" + " " + current.pieceNo + " " + current.position.X + " " + current.position.Y + " ";
                    //System.Diagnostics.Debug.WriteLine("Client sending");
                    Join.Send(sending);
                }

            }
            if (state.LeftButton == ButtonState.Pressed && !current._isPressed) {
                MousePressed((int)mposition.X, (int)mposition.Y);
            }
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
                        spriteBatch.Draw(rectw, new Vector2(300 + (100 * i), (100 * j) - 50), Color.White);
                    else
                        spriteBatch.Draw(rectb, new Vector2(300 + (100 * i), (100 * j) - 50), Color.White);
                }
            }
            for (int i = 0; i < pieces.Length; i++)
                pieces[i].Draw(spriteBatch);

        }
        /// <summary>
        /// Creates a new Checkers board
        /// </summary>
        public void CreateBoard() {
            Color[] white = new Color[100 * 100];
            rectw = new Texture2D(Game1.graphics.GraphicsDevice, 100, 100);
            for (int i = 0; i < white.Length; i++)
                white[i] = Color.White;
            rectw.SetData(white);

            Color[] black = new Color[100 * 100];
            rectb = new Texture2D(Game1.graphics.GraphicsDevice, 100, 100);
            for (int i = 0; i < black.Length; i++)
                black[i] = Color.Black;
            rectb.SetData(black);
        }
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
        /// <summary>
        /// Adds the pieces to the board
        /// </summary>
        public void AddPiece() {
            int count = 0;
            for (int i = 1; i <= 8; i++) {
                for(int j=1; j <= 8; j++) {
                    if((i == 1 && j == 1) || (i == 1 && j == 8)) {
                        pieces[count] = new ChessPiece(new Vector2(300 + (j * 100), 50), 'd');
                        pieces[count].pieceNo = count;
                        count++;

                    }
                    if ((i == 1 && j == 2) || (i == 1 && j == 7)) {
                        pieces[count] = new ChessPiece(new Vector2(300 + (j * 100), 50), 'f');
                        pieces[count].pieceNo = count;
                        count++;
                    }
                    if((i == 1 && j == 3) || (i == 1 && j == 6)) {
                        pieces[count] = new ChessPiece(new Vector2(300 + (j * 100), 50), 'h');
                        pieces[count].pieceNo = count;
                        count++;
                    }
                    if(i == 1 && j == 4) {
                        pieces[count] = new ChessPiece(new Vector2(300 + (j * 100), 50), 'j');
                        pieces[count].pieceNo = count;
                        count++;
                    }
                    if (i == 1 && j == 5) {
                        pieces[count] = new ChessPiece(new Vector2(300 + (j * 100), 50), 'l');
                        pieces[count].pieceNo = count;
                        count++;
                    }
                    if(i == 2) {
                        pieces[count] = new ChessPiece(new Vector2(300 + (j * 100), 150), 'b');
                        pieces[count].pieceNo = count;
                        count++;
                    }
                    //
                    if ((i == 8 && j == 8) || (i == 8 && j == 1)) {
                        pieces[count] = new ChessPiece(new Vector2(300 + (j * 100), 750), 'c');
                        pieces[count].pieceNo = count;
                        count++;

                    }
                    if ((i == 8 && j == 2) || (i == 8 && j == 7)) {
                        pieces[count] = new ChessPiece(new Vector2(300 + (j * 100), 750), 'e');
                        pieces[count].pieceNo = count;
                        count++;
                    }
                    if ((i == 8 && j == 3) || (i == 8 && j == 6)) {
                        pieces[count] = new ChessPiece(new Vector2(300 + (j * 100), 750), 'g');
                        pieces[count].pieceNo = count;
                        count++;
                    }
                    if (i == 8 && j == 5) {
                        pieces[count] = new ChessPiece(new Vector2(300 + (j * 100), 750), 'i');
                        pieces[count].pieceNo = count;
                        count++;
                    }
                    if (i == 8 && j == 4) {
                        pieces[count] = new ChessPiece(new Vector2(300 + (j * 100), 750), 'k');
                        pieces[count].pieceNo = count;
                        count++;
                    }
                    if (i == 7) {
                        pieces[count] = new ChessPiece(new Vector2(300 + (j * 100), 650), 'a');
                        pieces[count].pieceNo = count;
                        count++;
                    }

                }
            }

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
    }
}
