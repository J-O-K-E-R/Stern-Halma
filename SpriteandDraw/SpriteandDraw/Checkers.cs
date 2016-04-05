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
    class Checkers : GameType {
        Texture2D rectr, rectb;
        SpriteBatch spriteBatch;
        CheckersPiece[] pieces = new CheckersPiece[24];
        Rectangle[] list = new Rectangle[24];
        GamePiece current = new CheckersPiece();
        MouseState previousMouseState;
        Vector2 mposition;//mouse position

        public Checkers() {
            CreateBoard();
            AddPiece();
        }

        public override void LoadContent() {
            Type = "Checkers";
        }
        public override void Update(GameTime gameTime) {
            MouseState state = Mouse.GetState();
            mposition.X = state.X;
            mposition.Y = state.Y;

            if (previousMouseState.LeftButton == ButtonState.Pressed && state.LeftButton == ButtonState.Pressed) {

                current.position.X = mposition.X - 50;
                current.position.Y = mposition.Y - 50;
                string sending = "Checkers" + " " + current.pieceNo + " " + current.position.X + " " + current.position.Y;
                if (Game1.hosting == true) {
                    //System.Diagnostics.Debug.WriteLine("Host sending");
                    Host.Send(sending);
                }
                else {
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

        public override void UpdateBoardServer(int pieceno, int xpos, int ypos)
        {
            while (pieces[pieceno].position.X != xpos && pieces[pieceno].position.Y != ypos)
            {
                pieces[pieceno].position.X = xpos;
                pieces[pieceno].position.Y = ypos;
            }
        }

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
        public void AddPiece() {
            System.Diagnostics.Debug.WriteLine("Created Pieces");
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
            System.Diagnostics.Debug.WriteLine(count);
        }
        public void MousePressed(int x, int y) {
            Rectangle mouseRect = new Rectangle(x, y, 1, 1);
            for (int i = 0; i < pieces.Length; i++) {
                list[i] = (new Rectangle((int)pieces[i].position.X, (int)pieces[i].position.Y, 100, 100));
            }

            for (int i = 0; i < list.Length; i++) {
                if (mouseRect.Intersects(list[i])) {
                    System.Diagnostics.Debug.WriteLine("pressed peice: " + i);
                    current = pieces[i];
                    current._isPressed = true;
                    break;
                }
            }
        }
    }
}
