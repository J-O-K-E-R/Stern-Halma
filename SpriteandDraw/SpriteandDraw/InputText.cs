using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectName;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpriteandDraw {
    class InputText {
        Texture2D rect;
        Vector2 coor;

        public InputText(int x, int y) {
            rect = new Texture2D(Game1.graphics.GraphicsDevice, 80, 30);
            Color data = Color.Chocolate;
            coor = new Vector2(x, y);
        }

        public void Draw(SpriteBatch spriteBatch) {

            spriteBatch.Draw(rect, coor, Color.White);
        }
    }
}
