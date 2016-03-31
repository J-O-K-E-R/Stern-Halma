using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ProjectName;

namespace SpriteandDraw {
    class Join : Screen {
        InputText test;
        public Join() {
            test = new InputText(50, 50);
        }
        public override void LoadContent() {
            Type = "Join";
        }

        public override void Update(GameTime gameTime) {
        }

        public override void Draw(SpriteBatch spriteBatch) {
            test.Draw(spriteBatch);
            spriteBatch.DrawString(Game1.font, "Join", new Vector2(790, 390), Color.Black);
        }
    }
}
