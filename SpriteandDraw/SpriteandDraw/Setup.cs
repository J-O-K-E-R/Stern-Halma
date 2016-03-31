using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.BitmapFonts;
using ProjectName;

namespace SpriteandDraw {
    class Setup : Screen {
        InputText test;
        

        public Setup() {
            test = new InputText(50, 50);
        }
        public override void LoadContent() {
            Type = "Setup";
        }

        public override void Update(GameTime gameTime) {
            test.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch) {
            
            test.Draw(spriteBatch);
            //790, 390
            //spriteBatch.DrawString(Game1.font, "Setup", new Vector2(450, 390), Color.Black);
            spriteBatch.DrawString(Game1.font, "Hello", new Vector2(450, 390), Color.Black);
        }
    }
}