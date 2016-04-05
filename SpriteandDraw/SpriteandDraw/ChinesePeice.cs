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
    public class ChinesePeice : GamePiece {
        // Some variables for this object class, i.e. Attributes
        static Texture2D circlered;
        static Texture2D circleblue;
        static Texture2D circlegreen;
        static Texture2D circleyellow;
        static Texture2D circleblack;
        static Texture2D circlewhite;
        private char _type;

        public ChinesePeice() {
            _isPressed = false;
        }


        public ChinesePeice(Vector2 position, char _type) {
            this.position = position;
            this._type = _type;
        }

        // Some XNA specific methods
        public static void LoadContent(ContentManager content) {
            circlered = content.Load<Texture2D>("circlered");
            circleblue = content.Load<Texture2D>("circleblue");
            circlegreen = content.Load<Texture2D>("circlegreen");
            circleyellow = content.Load<Texture2D>("circleyellow");
            circleblack = content.Load<Texture2D>("circleblack");
            circlewhite = content.Load<Texture2D>("circlewhite");
        }

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
