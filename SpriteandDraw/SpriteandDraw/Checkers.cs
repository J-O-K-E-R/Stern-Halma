﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ProjectName;

namespace SpriteandDraw {
    class Checkers : GameType {
        Texture2D rectr, rectb;
        SpriteBatch spriteBatch;
        public Checkers() {
            CreateBoard();
        }

        public override void LoadContent() {
            Type = "Checkers";
        }
        public override void Update(GameTime gameTime) {

        }
        public override void Draw(SpriteBatch spriteBatch) {
            this.spriteBatch = spriteBatch;
            spriteBatch.Draw(Game1._backgroundTexture, new Rectangle(0, 0, Game1.graphics.GraphicsDevice.Viewport.Width, Game1.graphics.GraphicsDevice.Viewport.Height), Color.DarkSlateGray);

            for (int i = 1; i <= 8; i++) {
                for (int j = 1; j <= 8; j++) {
                    if ((i + j) % 2 == 0)
                        spriteBatch.Draw(rectr, new Vector2(300 + (100 * i),(100 * j) - 50), Color.White);
                    else
                        spriteBatch.Draw(rectb, new Vector2(300 + (100 * i),(100 * j) - 50), Color.White);
                }
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
    }
}
