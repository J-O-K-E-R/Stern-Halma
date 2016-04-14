///Authors: Justin Mclennan and Chun-Yip Tang
///Last Updated April 13, 2016
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

/// <summary>
/// basic class that gives definition to what a game board should be and how it should look with basic monogame methods.
/// is also an abstract class
/// </summary>
namespace SpriteandDraw {
    abstract public class GameType {

        public virtual string Type { get; set; }
        public virtual void LoadContent() { }
        public virtual void Update(GameTime gameTime) { }
        public virtual void Draw(SpriteBatch spriteBatch) { }
        public virtual void UpdateBoardServer(int pieceno, int xpos, int ypos) { }
        
    }
}
