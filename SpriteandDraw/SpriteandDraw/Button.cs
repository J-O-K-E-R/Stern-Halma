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
        static Texture2D back;
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
            back = content.Load<Texture2D>("BackButton");

        }
        public void Draw(SpriteBatch spriteBatch) { 
            switch (texture_name)
            {
                case "blank":
                    Rectangle stringRectangle = Game1.font.GetStringRectangle(text, position);
                    spriteBatch.Draw(blank, position, null, Color.MediumSeaGreen, 0f, Vector2.Zero, 0.25f, SpriteEffects.None, 0f);
                    spriteBatch.DrawString(Game1.font, text, new Vector2(position.X+75-(stringRectangle.Width/2), position.Y + 13), Color.Black);
                    break;
                case "back":
                    spriteBatch.Draw(back, position, null, Color.White, 0f, Vector2.Zero, 0.03f, SpriteEffects.None, 0f);
                    break;
            }            
        }

    }
}
