﻿///Authors: Justin Mclennan and Chun-Yip Tang
///Last Updated April 13, 2016
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

/// <summary>
/// Is the basic shape for the holes in chinese checkers
/// </summary>
namespace ProjectName {
    public class Circle {

        // Some variables for this object class, i.e. Attributes
        static Texture2D circle;
        Vector2 position;

        public Circle(Vector2 position) {
            this.position = position;
        }

        // Some XNA specific methods
        public static void LoadContent(ContentManager content) {

            circle = content.Load<Texture2D>("circle128");
        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(circle, position, Color.White);
        }
        
    }
}