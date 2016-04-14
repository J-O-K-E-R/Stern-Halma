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

namespace SpriteandDraw {
    class ChessPiece : GamePiece {
        static Texture2D pawn, pawnb, rook, rookb, bishop, bishopb, knight, knightb, queen, queenb, king, kingb;
        private char _type;

        public ChessPiece() {
            _isPressed = false;
        }

        public ChessPiece(Vector2 position, char _type) {
            this.position = position;
            this._type = _type;
        }

        public override void Draw(SpriteBatch spriteBatch) {
            switch (_type) {
                case 'a': {
                        spriteBatch.Draw(pawn, position, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                        break;
                    }
                case 'b': {
                        spriteBatch.Draw(pawnb, position, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                        break;
                    }
                case 'c': {
                        spriteBatch.Draw(rook, position, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                        break;
                    }
                case 'd': {
                        spriteBatch.Draw(rookb, position, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                        break;
                    }
                case 'e': {
                        spriteBatch.Draw(knight, position, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                        break;
                    }
                case 'f': {
                        spriteBatch.Draw(knightb, position, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                        break;
                    }
                case 'g': {
                        spriteBatch.Draw(bishop, position, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                        break;
                    }
                case 'h': {
                        spriteBatch.Draw(bishopb, position, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                        break;
                    }
                case 'i': {
                        spriteBatch.Draw(queen, position, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                        break;
                    }
                case 'j': {
                        spriteBatch.Draw(queenb, position, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                        break;
                    }
                case 'k': {
                        spriteBatch.Draw(king, position, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                        break;
                    }
                case 'l': {
                        spriteBatch.Draw(kingb, position, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                        break;
                    }
            }
        }

        public static void LoadContent(ContentManager content) {
            pawn = content.Load<Texture2D>("pawn");
            pawnb = content.Load<Texture2D>("pawnB");
            rook = content.Load<Texture2D>("rook");
            rookb = content.Load<Texture2D>("rookB");
            knight = content.Load<Texture2D>("knight");
            knightb = content.Load<Texture2D>("knightB");
            bishop = content.Load<Texture2D>("bishop");
            bishopb = content.Load<Texture2D>("bishopB");
            queen = content.Load<Texture2D>("queen");
            queenb = content.Load<Texture2D>("queenB");
            king = content.Load<Texture2D>("king");
            kingb = content.Load<Texture2D>("kingB");

        }
    }
}
