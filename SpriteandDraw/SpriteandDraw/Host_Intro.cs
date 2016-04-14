using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonoGame.Extended.BitmapFonts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpriteandDraw {
    class Host_Intro : GameType {
        /// <summary>
        /// Automatic method to load content in monogame
        /// </summary>
        public override void LoadContent() {
            Type = "HIntro";
        }

        public override void Update(GameTime gameTime) { }


        public override void Draw(SpriteBatch spriteBatch) {

            spriteBatch.DrawString(Game1.font, "Click to Play Chess", new Vector2(Game1.ScreenWidth - 550, 213), Color.Black);
            spriteBatch.DrawString(Game1.font, "Click to Play Checkers", new Vector2(Game1.ScreenWidth - 550, 313), Color.Black);
            spriteBatch.DrawString(Game1.font, "Click to Play Sterne-Halma", new Vector2(Game1.ScreenWidth - 550, 413), Color.Black);


        }   
    }
}
