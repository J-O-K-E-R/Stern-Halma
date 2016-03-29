﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpriteandDraw {
    public class Button {

        static Texture2D blank;
        static Texture2D gear;
        Vector2 position;
        String texture_name;

        public Button(Vector2 position, String texture_name) {
            this.position = position;
            this.texture_name = texture_name;
        }
        public static void LoadContent(ContentManager content) {
            blank = content.Load<Texture2D>("blank_button");
            gear = content.Load<Texture2D>("gear_icon");

        }
        public void Draw(SpriteBatch spriteBatch) {
            switch (texture_name)
            {
                case "blank":
                    spriteBatch.Draw(blank, position, null, Color.White, 0f, Vector2.Zero, 0.25f, SpriteEffects.None, 0f);
                    break;
                case "gear":
                    spriteBatch.Draw(gear, position, null, Color.White, 0f, Vector2.Zero, 0.1f, SpriteEffects.None, 0f);
                    break;
            }            
        }

    }
}
