using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ProjectName;

namespace SpriteandDraw {
    class Chess : GameType {
        Texture2D rectw, rectb;
        SpriteBatch spriteBatch;
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

        }
        public override void UpdateBoardServer(int pieceno, int xpos, int ypos) {

        }
    }
}
