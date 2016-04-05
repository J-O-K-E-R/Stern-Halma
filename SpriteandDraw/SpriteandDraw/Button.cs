using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using MonoGame.Extended.BitmapFonts;

namespace SpriteandDraw {
    public class Button {

        static Texture2D blank;
        static Texture2D gear;
        private Rectangle stringRectangle;
        Vector2 position;
        string texture_name;
        string text;

        public Button(Vector2 position, string texture_name, string text) {
            this.text = text;
            this.position = position;
            this.texture_name = texture_name;
        }
        public static void LoadContent(ContentManager content) {
            blank = content.Load<Texture2D>("blank_button");
            gear = content.Load<Texture2D>("gear_icon");

        }
        public void Draw(SpriteBatch spriteBatch) {
            stringRectangle = Game1.font.GetStringRectangle(text, position);
            switch (texture_name)
            {
                case "blank":
                    spriteBatch.Draw(blank, position, null, Color.MediumSeaGreen, 0f, Vector2.Zero, 0.25f, SpriteEffects.None, 0f);
                    spriteBatch.DrawString(Game1.font, text, new Vector2(position.X+75-(stringRectangle.Width/2), position.Y + 13), Color.Black);
                    break;
                case "gear":
                    spriteBatch.Draw(gear, position, null, Color.White, 0f, Vector2.Zero, 0.1f, SpriteEffects.None, 0f);
                    break;
            }            
        }

    }
}
