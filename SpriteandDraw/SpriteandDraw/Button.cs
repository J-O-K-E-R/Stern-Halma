///Authors: Justin Mclennan and Chun-Yip Tang
///Last Updated April 13, 2016
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

/// <summary>
/// Class that describes what a button is, looks like and behaves
/// </summary>
namespace SpriteandDraw {
    public class Button {

        static Texture2D blank;
        static Texture2D back;
        Vector2 position;
        string texture_name;
        string text;

        /// <summary>
        /// Constructor that takes in a position (X and Y coords), the name of the color and what it will display 
        /// </summary>
        /// <param name="position"></param>
        /// <param name="texture_name"></param>
        /// <param name="text"></param>
        public Button(Vector2 position, string texture_name, string text) {
            this.text = text;
            this.position = position;
            this.texture_name = texture_name;
        }

        /// <summary>
        /// base method that loads the button
        /// </summary>
        /// <param name="content"></param>
        public static void LoadContent(ContentManager content) {
            blank = content.Load<Texture2D>("blank_button");
            back = content.Load<Texture2D>("BackButton");

        }

        /// <summary>
        /// Draws the button to specific dimensions and colors
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch) { 
            switch (texture_name)
            {
                case "blank":
                    Rectangle stringRectangle = Game1.font.GetStringRectangle(text, position);
                    spriteBatch.Draw(blank, position, null, Color.MediumSeaGreen, 0f, Vector2.Zero, 0.25f, SpriteEffects.None, 0f);
                    spriteBatch.DrawString(Game1.font, text, new Vector2(position.X+75-(stringRectangle.Width/2), position.Y + 13), Color.Black);
                    break;
                case "back":
                    spriteBatch.Draw(back, position, null, Color.White, 0f, Vector2.Zero, 0.048f, SpriteEffects.None, 0f);
                    break;
            }            
        }

    }
}
