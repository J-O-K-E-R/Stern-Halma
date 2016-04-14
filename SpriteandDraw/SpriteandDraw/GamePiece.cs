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
/// gives basic definition to all game pieces and is an abstract class
/// </summary>
namespace SpriteandDraw {
    abstract public class GamePiece {
        public int pieceNo;
        public bool _isPressed;
        public Vector2 position;
        public virtual void Draw(SpriteBatch spriteBatch) { }
    }
}
