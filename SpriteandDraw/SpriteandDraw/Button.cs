using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpriteandDraw {
    public class Button {

        static Texture2D button;

        //inputstate input;
        //inputhelper inputhelper;

        //public event eventhandler click;
        //public bool ispressed = false;
        //public string text { get; set; }
        //public vector2 position { get; set; }
        //public rectangle bounds { get; set; }

        //private bool intersectwith(vector2 position) {
        //    rectangle touchtap = new rectangle((int)position.x - 1, (int)position.y - 1, 2, 2);
        //    return bounds.intersects(touchtap);
        //}

        //private void handleinput(mousestate mousestate) {
        //    bool pressed = false;
        //    vector2 position = vector2.zero;
        //    if (mousestate.leftbutton == buttonstate.pressed)
        //    {
        //        pressed = true;
        //        position = new vector2(mousestate.x, mousestate.y);
        //    }
        //    else if (inputhelper.ispressed)
        //    {
        //        pressed = true;
        //        position = inputhelper.pointposition;
        //    }
        //    else
        //    {
        //        if (ispressed)
        //        {
        //            if (intersectwith(new vector2(mousestate.x, mousestate.y)) ||
        //                intersectwith(inputhelper.pointposition))
        //            {
        //                put something here
        //                ispressed = false;
        //            }
        //            else
        //            {

        //                ispressed = false;
        //            }
        //        }

        //        iskeydown = false;
        //    }

        public static void LoadContent(ContentManager content) {

            button = content.Load<Texture2D>("blank_button");
        }
        public void Draw(SpriteBatch spriteBatch) {
            //spriteBatch.Draw(button, position, Color.White);
        }

    }
}
