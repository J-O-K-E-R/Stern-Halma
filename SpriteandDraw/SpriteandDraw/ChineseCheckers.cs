using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using ProjectName;

namespace SpriteandDraw {
    class ChineseCheckers : GameType {

        private List<Circle> board = new List<Circle>();
        ChinesePeice[] pieces = new ChinesePeice[60];
        Rectangle[] list = new Rectangle[60];
        GamePiece current = new ChinesePeice();
        MouseState previousMouseState;
        Vector2 mposition;//mouse position

        public ChineseCheckers() {
            CreateBoard();
            AddPeices();
        }
        public override void LoadContent() {
            Type = "ChineseCheckers";
        }
        public override void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(Game1._backgroundTexture, new Rectangle(0, 0, Game1.graphics.GraphicsDevice.Viewport.Width, Game1.graphics.GraphicsDevice.Viewport.Height), Color.DarkSlateGray);
            foreach (Circle circle in board)
                circle.Draw(spriteBatch);
            foreach (ChinesePeice peice in pieces)
                peice.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime) {
            MouseState state = Mouse.GetState();
            mposition.X = state.X;
            mposition.Y = state.Y;

            if (previousMouseState.LeftButton == ButtonState.Pressed && state.LeftButton == ButtonState.Pressed) {

                current.position.X = mposition.X - 20;
                current.position.Y = mposition.Y - 20;

            }
            if (state.LeftButton == ButtonState.Pressed && !current._isPressed) {
                MousePressed((int)mposition.X, (int)mposition.Y);
            }
            if (previousMouseState.LeftButton == ButtonState.Pressed && state.LeftButton == ButtonState.Released) {
                MouseClicked((int)mposition.X, (int)mposition.Y);
                current._isPressed = false;
            }
            previousMouseState = state;
        }

        public void MouseClicked(int x, int y) {
            Rectangle mouseRect = new Rectangle(x, y, 1, 1);
            


        }
        public void MousePressed(int x, int y) {
            Rectangle mouseRect = new Rectangle(x, y, 1, 1);
            for (int i = 0; i < pieces.Length; i++) {
                list[i] = (new Rectangle((int)pieces[i].position.X, (int)pieces[i].position.Y, 40, 40));
            }

            for (int i = 0; i < list.Length; i++) {
                if (mouseRect.Intersects(list[i])) {
                    System.Diagnostics.Debug.WriteLine("pressed peice: " + i);
                    current = pieces[i];
                    current._isPressed = true;
                    break;
                }
            }
        }

        public void ServerUpdateMove(GamePiece moved)
        {
            current.position.X = moved.position.X;
            current.position.Y = moved.position.Y;
        }

        public void CreateBoard() {
            int i, height;
            int[] x = new int[121];
            int[] y = new int[121];
            //comments determine the column
            //middle row
            height = 130;
            for (i = 0; i < 9; i++) {
                x[i] = 735;
                y[i] = height;
                height += 80;
            }
            //left 1
            height = 170;
            for (i = 9; i <= 16; i++) {
                x[i] = 714;
                y[i] = height;
                height += 80;
            }
            //left 2
            height = 210;
            for (i = 17; i <= 23; i++) {
                x[i] = 693;
                y[i] = height;
                height += 80;
            }
            //left 3
            height = 250;
            for (i = 24; i <= 29; i++) {
                x[i] = 672;
                y[i] = height;
                height += 80;
            }
            //left 4
            height = 290;
            for (i = 30; i <= 34; i++) {
                x[i] = 651;
                y[i] = height;
                height += 80;
            }
            //left 5
            height = 330;
            for (i = 35; i <= 38; i++) {
                x[i] = 630;
                y[i] = height;
                height += 80;
            }
            //left 6
            height = 290;
            for (i = 39; i <= 43; i++) {
                x[i] = 609;
                y[i] = height;
                height += 80;
            }
            //left 7
            height = 330;
            for (i = 44; i <= 47; i++) {
                x[i] = 588;
                y[i] = height;
                height += 80;
            }
            //left 8
            height = 290;
            for (i = 48; i <= 52; i++) {
                x[i] = 567;
                y[i] = height;
                height += 80;
            }
            //left 9
            height = 330;
            for (i = 53; i <= 56; i++) {
                x[i] = 546;
                y[i] = height;
                height += 80;
            }
            //left 10
            height = 290;
            for (i = 57; i <= 58; i++) {
                x[i] = 525;
                y[i] = height;
                height += 80;
            }
            height = 530;
            for (i = 59; i <= 60; i++) {
                x[i] = 525;
                y[i] = height;
                height += 80;
            }
            //left 11
            x[61] = 504;
            y[61] = 330;
            x[62] = 504;
            y[62] = 570;
            //left 12
            x[63] = 483;
            y[63] = 290;
            x[64] = 483;
            y[64] = 610;

            //right 1
            height = 170;
            for (i = 65; i <= 72; i++) {
                x[i] = 756;
                y[i] = height;
                height += 80;
            }
            //right 2
            height = 210;
            for (i = 73; i <= 79; i++) {
                x[i] = 777;
                y[i] = height;
                height += 80;
            }
            //right 3
            height = 250;
            for (i = 80; i <= 85; i++) {
                x[i] = 798;
                y[i] = height;
                height += 80;
            }
            //right 4
            height = 290;//reuse the height
            for (i = 86; i <= 90; i++) {
                x[i] = 819;
                y[i] = height;
                height += 80;
            }
            //right 5
            height = 330; //resue for height 2
            for (i = 91; i <= 94; i++) {
                x[i] = 840;
                y[i] = height;
                height += 80;
            }
            //right 6
            height = 290;
            for (i = 95; i <= 99; i++) {
                x[i] = 861;
                y[i] = height;
                height += 80;
            }
            //right 7
            height = 330;
            for (i = 100; i <= 103; i++) {
                x[i] = 882;
                y[i] = height;
                height += 80;
            }
            //right 8
            height = 290;
            for (i = 104; i <= 108; i++) {
                x[i] = 903;
                y[i] = height;
                height += 80;
            }
            //right 9
            height = 330;
            for (i = 109; i <= 112; i++) {
                x[i] = 924;
                y[i] = height;
                height += 80;
            }
            //right 10
            height = 290;
            for (i = 113; i <= 114; i++) {
                x[i] = 945;
                y[i] = height;
                height += 80;
            }
            height = 530;
            for (i = 115; i <= 116; i++) {
                x[i] = 945;
                y[i] = height;
                height += 80;
            }
            //right 11
            x[117] = 966;
            y[117] = 330;
            x[118] = 966;
            y[118] = 570;
            //right 12
            x[119] = 987;
            y[119] = 290;
            x[120] = 987;
            y[120] = 610;

            for (i = 0; i < y.Length; i++)
                board.Add(new Circle(new Vector2(x[i], y[i])));
        }
        public void AddPeices() {
            int i, width;
            int[] x = new int[60];
            int[] y = new int[60];
            //adding the top left peices
            width = 483;
            for (i = 0; i <= 3; i++) {
                x[i] = width;
                y[i] = 290;
                width += 42;
            }
            width = 504;
            for (i = 4; i <= 6; i++) {
                x[i] = width;
                y[i] = 330;
                width += 42;
            }
            width = 525;
            for (i = 7; i <= 8; i++) {
                x[i] = width;
                y[i] = 370;
                width += 42;
            }
            x[9] = 546;
            y[9] = 410;
            for (i = 0; i < 10; i++)
                pieces[i] = (new ChinesePeice(new Vector2(x[i], y[i]), 'y'));
            //adding the bottom left peices
            width = 483;
            for (i = 10; i <= 13; i++) {
                x[i] = width;
                y[i] = 610;
                width += 42;
            }
            width = 504;
            for (i = 14; i <= 16; i++) {
                x[i] = width;
                y[i] = 570;
                width += 42;
            }
            width = 525;
            for (i = 17; i <= 18; i++) {
                x[i] = width;
                y[i] = 530;
                width += 42;
            }
            x[19] = 546;
            y[19] = 490;
            for (i = 10; i < 20; i++)
                pieces[i] = (new ChinesePeice(new Vector2(x[i], y[i]), 'g'));
            //add the top right
            width = 987;
            for (i = 20; i <= 23; i++) {
                x[i] = width;
                y[i] = 290;
                width -= 42;
            }
            width = 966;
            for (i = 24; i <= 26; i++) {
                x[i] = width;
                y[i] = 330;
                width -= 42;
            }
            width = 945;
            for (i = 27; i <= 28; i++) {
                x[i] = width;
                y[i] = 370;
                width -= 42;
            }
            x[29] = 924;
            y[29] = 410;
            for (i = 20; i < 30; i++)
                pieces[i] = (new ChinesePeice(new Vector2(x[i], y[i]), 'v'));
            //add the bottom right
            width = 987;
            for (i = 30; i <= 33; i++) {
                x[i] = width;
                y[i] = 610;
                width -= 42;
            }
            width = 966;
            for (i = 34; i <= 36; i++) {
                x[i] = width;
                y[i] = 570;
                width -= 42;
            }
            width = 945;
            for (i = 37; i <= 38; i++) {
                x[i] = width;
                y[i] = 530;
                width -= 42;
            }
            x[39] = 924;
            y[39] = 490;
            for (i = 30; i < 40; i++)
                pieces[i] = (new ChinesePeice(new Vector2(x[i], y[i]), 'w'));
            //add the top middle
            width = 672;
            for (i = 40; i <= 43; i++) {
                x[i] = width;
                y[i] = 250;
                width += 42;
            }
            width = 693;
            for (i = 44; i <= 46; i++) {
                x[i] = width;
                y[i] = 210;
                width += 42;
            }
            width = 714;
            for (i = 47; i <= 48; i++) {
                x[i] = width;
                y[i] = 170;
                width += 42;
            }
            x[49] = 735;
            y[49] = 130;
            for (i = 40; i < 50; i++)
                pieces[i] = (new ChinesePeice(new Vector2(x[i], y[i]), 'b'));
            //add the bottom middle
            width = 672;
            for (i = 50; i <= 53; i++) {
                x[i] = width;
                y[i] = 650;
                width += 42;
            }
            width = 693;
            for (i = 54; i <= 56; i++) {
                x[i] = width;
                y[i] = 690;
                width += 42;
            }
            width = 714;
            for (i = 57; i <= 58; i++) {
                x[i] = width;
                y[i] = 730;
                width += 42;
            }
            x[59] = 735;
            y[59] = 770;
            for (i = 50; i < 60; i++)
                pieces[i] = (new ChinesePeice(new Vector2(x[i], y[i]), 'r'));
        }
    }
}
