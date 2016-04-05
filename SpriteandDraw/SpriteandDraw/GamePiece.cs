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
    abstract public class GamePiece {
        public bool _isPressed;
        public Vector2 position;
        public virtual void Draw(SpriteBatch spriteBatch) { }
    }
}
