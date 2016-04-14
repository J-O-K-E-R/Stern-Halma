///Authors: Justin Mclennan and Chun-Yip Tang
///Last Updated April 13, 2016
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonoGame.Extended.BitmapFonts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

/// <summary>
/// Class to display the choices of games the server side user has after confirming start game
/// </summary>
namespace SpriteandDraw {
    class Host_Intro : GameType {
        /// <summary>
        /// Automatic method to load content in monogame
        /// </summary>
        public override void LoadContent() {
            Type = "HIntro";
        }

        /// <summary>
        /// Doesn't need to do anything, but because is part of the abstract class, needs to be here
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime) { }

        /// <summary>
        /// Simply draws out the 3 button selections for this screen
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch) {

            spriteBatch.DrawString(Game1.font, "Click to Play Chess", new Vector2(Game1.ScreenWidth - 550, 213), Color.Black);
            spriteBatch.DrawString(Game1.font, "Click to Play Checkers", new Vector2(Game1.ScreenWidth - 550, 313), Color.Black);
            spriteBatch.DrawString(Game1.font, "Click to Play Sterne-Halma", new Vector2(Game1.ScreenWidth - 550, 413), Color.Black);


        }   
    }
}
