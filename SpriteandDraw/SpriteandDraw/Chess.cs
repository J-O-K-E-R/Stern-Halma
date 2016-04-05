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
        ChessPiece[] pieces = new ChessPiece[8];
        Rectangle[] list = new Rectangle[32];
        GamePiece current = new CheckersPiece();
        MouseState previousMouseState;
        Vector2 mposition;//mouse position

        public Chess() {
            CreateBoard();
            AddPiece();
        }

        public override void LoadContent() {
            Type = "Chess";
        }
        public override void Update(GameTime gameTime) {

        }
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

                }
            }

        }
        public override void UpdateBoardServer(int pieceno, int xpos, int ypos) {

        }
    }
}
