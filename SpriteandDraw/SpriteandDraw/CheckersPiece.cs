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
/// Class to decide the pieces for the checkers game
/// </summary>
namespace SpriteandDraw {
    class CheckersPiece : GamePiece {
        static Texture2D pieceB, pieceR;
        private char _type;

        /// <summary>
        /// sets all checkers pieces so that they are not pressed
        /// </summary>
        public CheckersPiece() {
            _isPressed = false;
        }

        /// <summary>
        /// gets the position and type of piece for populating the board
        /// </summary>
        /// <param name="position"></param>
        /// <param name="_type"></param>
        public CheckersPiece(Vector2 position, char _type) {
            this.position = position;
            this._type = _type;
        }
        /// <summary>
        /// automatic function to draw the checkers pieces onto the board. Can be either red or black
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw(SpriteBatch spriteBatch) {
            switch (_type) {
                case 'r': {
                        spriteBatch.Draw(pieceR, position, null, Color.White, 0f, Vector2.Zero, 0.16f, SpriteEffects.None, 0f);
                        break;
                    }
                case 'b': {
                        spriteBatch.Draw(pieceB, position, null, Color.White, 0f, Vector2.Zero, 0.16f, SpriteEffects.None, 0f);
                        break;
                    }
            }
        }

        /// <summary>
        /// Automatic function to load the texture in monogame
        /// </summary>
        /// <param name="content"></param>
        public static void LoadContent(ContentManager content) {
            pieceB = content.Load<Texture2D>("checkerB");
            pieceR = content.Load<Texture2D>("checkerR");
        }
    }
}
