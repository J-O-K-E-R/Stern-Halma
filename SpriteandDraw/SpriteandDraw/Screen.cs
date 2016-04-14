using System;
using System.Collections.Generic;
using System.Linq;
///Authors: Justin Mclennan and Chun-Yip Tang
///Last Updated April 13, 2016
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

/// <summary>
/// Abstract class for the screen
/// </summary>
namespace SpriteandDraw {
    abstract public class Screen {

        /// <summary>
        /// Every method variable and method here is to help the Board class
        /// </summary>
        public string Type;
        public virtual void LoadContent() { }
        public virtual void Update(GameTime gameTime) { }
        public virtual void Draw(SpriteBatch spriteBatch) { }
    }
}
