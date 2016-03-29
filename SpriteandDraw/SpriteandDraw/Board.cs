using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using ProjectName;

namespace SpriteandDraw {
    public class Board : Screen {
        List<Circle> board = new List<Circle>();
        Vector2 backb = new Vector2(0, 870);
        MouseState previousMouseState;
        Vector2 mposition;//mouse position
        Button back;

        public Board() {
            CreateBoard();
            back = new Button(backb, "gear");
        }
        public void CreateBoard() {
            int i, height, j;
            int[] x = new int[100];
            int[] y = new int[100];
            //middle row
            height = 130;

           
            //left 1
            height = 170;
            for (i = 9; i <= 16; i++)
            {
                x[i] = 714;
                y[i] = height;
                height += 80;
            }
            //left 2
            height = 210;
            for (i = 17; i <= 23; i++)
            {
                x[i] = 693;
                y[i] = height;
                height += 80;
            }
            //left 3
            height = 250;
            for (i = 24; i <= 29; i++)
            {
                x[i] = 672;
                y[i] = height;
                height += 80;
            }
            //left 4
            height = 290;//reuse the height
            for (i = 30; i <= 34; i++)
            {
                x[i] = 651;
                y[i] = height;
                height += 80;
            }
            //left 5
            height = 330; //resue for height 2
            for (i = 35; i <= 38; i++)
            {
                x[i] = 630;
                y[i] = height;
                height += 80;
            }
            //left 6
            height = 290;
            for (i = 40; i <= 44; i++)
            {
                x[i] = 609;
                y[i] = height;
                height += 80;
            }
            //left 7
            height = 330;
            for (i = 45; i <= 48; i++)
            {
                x[i] = 588;
                y[i] = height;
                height += 80;
            }
            //left 8
            height = 290;
            for (i = 49; i <= 53; i++)
            {
                x[i] = 567;
                y[i] = height;
                height += 80;
            }
            //left 9
            height = 330;
            for (i = 54; i <= 57; i++)
            {
                x[i] = 546;
                y[i] = height;
                height += 80;
            }
            //left 10
            height = 290;
            for (i = 58; i <= 59; i++)
            {
                x[i] = 525;
                y[i] = height;
                height += 80;
            }
            height = 530;
            for (i = 60; i <= 61; i++)
            {
                x[i] = 525;
                y[i] = height;
                height += 80;
            }
            //left 11
            x[62] = 504;
            y[62] = 330;
            x[63] = 504;
            y[63] = 570;
            //left 12
            x[64] = 483;
            y[64] = 290;
            x[65] = 483;
            y[65] = 610;

            for (i = 0; i < y.Length; i++)
            {
                //Console.WriteLine(GraphicsDevice.Viewport.Width);
                board.Add(new Circle(new Vector2(x[i], y[i])));
            }
            /*height = 170;
            for (i = 17; i <= 24; i++)
            {
                x[i] = 756;
                y[i] = height;
                height += 80;
            }*/
        }
        public override void LoadContent() {
            Type = "Board";
        }

        public override void Update(GameTime gameTime) {
            MouseState state = Mouse.GetState();
            mposition.X = state.X;
            mposition.Y = state.Y;

            //System.Diagnostics.Debug.WriteLine(position.X.ToString() +
            //                       "," + position.Y.ToString());
            if (previousMouseState.LeftButton == ButtonState.Pressed && state.LeftButton == ButtonState.Released)
            {
                MouseClicked((int)mposition.X, (int)mposition.Y);
            }
            previousMouseState = state;
        }
        public override void Draw(SpriteBatch spriteBatch) {
            back.Draw(spriteBatch);
            foreach (Circle circle in board)
                circle.Draw(spriteBatch);
            //spriteBatch.DrawString(Game1.font, "Chung what the hell are you doing: ", new Vector2(100, 100), Color.Black);
        }
        public void MouseClicked(int x, int y) {
            Rectangle mouseRect = new Rectangle(x, y, 1, 1);
            Rectangle backRect = new Rectangle((int)backb.X, (int)backb.Y, 30, 30);

            if (mouseRect.Intersects(backRect))
            { //player clicked back button
                Game1.currentScreen.Type = "Menu";
            }
        }
    }
}
