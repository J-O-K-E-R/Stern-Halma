///Authors: Justin Mclennan and Chun-Yip Tang
///Last Updated April 13, 2016
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using ProjectName;

/// <summary>
/// Used to define what a chinese checkers or sterne-halma piece is
/// </summary>
namespace SpriteandDraw {
    public class ChinesePeice : GamePiece {
        // Some variables for this object class, i.e. Attributes
        static Texture2D circlered, circleblue, circlegreen, circleyellow, circleblack, circlewhite;
        private char _type;

         /// <summary>
         /// constructor saying that a chinese piece is not pressed the moment it is created
         /// </summary>
        public ChinesePeice() {
            _isPressed = false;
        }

        /// <summary>
        /// Overload constructor to give the chinese piece a type or player color and a starting position
        /// </summary>
        /// <param name="position"></param>
        /// <param name="_type"></param>
        public ChinesePeice(Vector2 position, char _type) {
            this.position = position;
            this._type = _type;
        }

        /// <summary>
        /// Automatic method to load content in monogame
        /// </summary>
        public static void LoadContent(ContentManager content) {
            circlered = content.Load<Texture2D>("circlered");
            circleblue = content.Load<Texture2D>("circleblue");
            circlegreen = content.Load<Texture2D>("circlegreen");
            circleyellow = content.Load<Texture2D>("circleyellow");
            circleblack = content.Load<Texture2D>("circleblack");
            circlewhite = content.Load<Texture2D>("circlewhite");
        }

        /// <summary>
        /// basic draw to draw the pieces onto the board
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch) {
            switch (_type) {
                case 'r': {
                        spriteBatch.Draw(circlered, position, Color.LightGray);
                        break;
                    }
                case 'g': {
                        spriteBatch.Draw(circlegreen, position, Color.LightGray);
                        break;
                    }
                case 'b': {
                        spriteBatch.Draw(circleblack, position, Color.LightGray);
                        break;
                    }
                //v for violet since we beed b for black
                case 'v': {
                        spriteBatch.Draw(circleblue, position, Color.LightGray);
                        break;
                    }
                case 'y': {
                        spriteBatch.Draw(circleyellow, position, Color.LightGray);
                        break;
                    }
                case 'w': {
                        spriteBatch.Draw(circlewhite, position, Color.LightGray);
                        break;
                    }
            }
            
        }

    }
}
