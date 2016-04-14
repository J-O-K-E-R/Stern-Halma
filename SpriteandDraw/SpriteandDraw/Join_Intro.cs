using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonoGame.Extended.BitmapFonts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpriteandDraw {
    class Join_Intro : GameType {
        private static string text = "Wait for host to choose a gamemode";
        private int counter = 0;

        /// <summary>
        /// Automatic method to load content in monogame
        /// </summary>
        public override void LoadContent() {
            Type = "JIntro";
        }

        public override void Update(GameTime gameTime) {
            counter++;
            if (counter % 60 == 0) {
                text += ".";
                
            }
            if(counter == 240)
            {
                counter = 0;
                text = text.Substring(0, text.Length - 4);
            }
        }
            
        public override void Draw(SpriteBatch spriteBatch) {

            spriteBatch.DrawString(Game1.font, text, new Vector2(Game1.ScreenWidth/2 - 200, Game1.ScreenHeight/2), Color.Black);
        }
    }
}
