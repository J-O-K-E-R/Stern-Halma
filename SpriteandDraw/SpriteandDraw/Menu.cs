using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProjectName;

namespace SpriteandDraw {
    public class Menu : Screen {
        public Menu() {
            Button play = new Button();
        }
        public override void LoadContent() {
            Type = "Menu";
        }
        public override void Draw(SpriteBatch spriteBatch) {
            //play.Draw(spriteBatch);
            spriteBatch.DrawString(Game1.font, "Chung what the hell are you doing: ", new Vector2(100, 100), Color.Black);
            
        }
    }
}
