using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace ProjectName {
    public class Circle {

        // Some variables for this object class, i.e. Attributes
        static Texture2D circle;
        Vector2 position;
        // The 'constructor' method
        public Circle() {

        }
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