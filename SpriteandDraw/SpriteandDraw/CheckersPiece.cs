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
    class CheckersPiece : GamePiece {
        static Texture2D pieceB, pieceR;
        private char _type;

        public CheckersPiece() {
            _isPressed = false;
        }

        public CheckersPiece(Vector2 position, char _type) {
            this.position = position;
            this._type = _type;
        }

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

        public static void LoadContent(ContentManager content) {
            pieceB = content.Load<Texture2D>("checkerB");
            pieceR = content.Load<Texture2D>("checkerR");
        }
    }
}
