using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectName;
using MonoGame.Extended;
using MonoGame.Extended.BitmapFonts;
using MonoGame.Extended.InputListeners;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpriteandDraw {
    class InputText {
        private Texture2D rect;
        private Rectangle rec;
        private Rectangle stringRectangle;
        private static Texture2D _pointTexture;
        private SpriteBatch spriteBatch;
        private KeyboardListener keyboardListener;
        public string tempstring = "";
        private string _typedString = string.Empty;
        private bool _isCursorVisible = true;
        private const float _cursorBlinkDelay = 0.5f;
        private float _cursorBlinkDelta = _cursorBlinkDelay;
        public static bool connected = true;
        Join joining = new Join();

        public int width, height;
        public bool _cursor = false;
        public Vector2 coor;

        public InputText(int x, int y, int w, int h) {
            width = w;
            height = h;
            Color[] data = new Color[width * height];
            //rectangle for white area
            rect = new Texture2D(Game1.graphics.GraphicsDevice, width, height);
            //rectangle for the border
            rec = new Rectangle(x, y, width, height);
            //sets color data for rectangle
            coor = new Vector2(x, y);
            for (int i = 0; i < data.Length; i++)
                data[i] = Color.White;
            rect.SetData(data);
            Input();
        }
        public void Input() {
            var mouseListener = Game1.inputManager.AddListener(new MouseListenerSettings());
            keyboardListener = Game1.inputManager.AddListener(new KeyboardListenerSettings());


            keyboardListener.KeyTyped += (sender, args) => {
                if (args.Key == Keys.Back && _typedString.Length > 0) {
                    _typedString = _typedString.Substring(0, _typedString.Length - 1);
                }
                else if (args.Key == Keys.Enter) {
                    if (joining.ConnectToServer(_typedString)) {
                        Game1.currentScreen.Type = "Board";
                    }
                    else {
                        connected = false;
                    }
                }
                else if (_typedString.Length < 16 && _cursor) {
                    _typedString += args.Character?.ToString() ?? "";
                }
            };
        }
        public void Update(GameTime gameTime) {

            _cursorBlinkDelta -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (_cursor) {
                if (_cursorBlinkDelta <= 0) {
                    _isCursorVisible = !_isCursorVisible;
                    _cursorBlinkDelta = _cursorBlinkDelay;
                }
            }

            Game1.inputManager.Update(gameTime);
        }
        public void Draw(SpriteBatch batch) {
            spriteBatch = batch;//creates a batch usable all over class
            if (_cursor)
                tempstring = _typedString;

            stringRectangle = Game1.font.GetStringRectangle(tempstring, coor);
            spriteBatch.Draw(rect, coor, Color.White);
            //System.Diagnostics.Debug.WriteLine(stringRectangle.Width);
            DrawRectangle(batch, rec, Color.Black, 2); //Draws borer of created rectangle
            spriteBatch.DrawString(Game1.font, tempstring, new Vector2(coor.X + 5, coor.Y + 2), Color.Black);

            if (_cursor) {
                if (_isCursorVisible)
                    spriteBatch.DrawString(Game1.font, "|", new Vector2(stringRectangle.Width + coor.X + 3, coor.Y + 2), Color.Black);
            }
            if(!connected)
                spriteBatch.DrawString(Game1.font, "Cannot Connect...", new Vector2(coor.X + width + 10 , coor.Y ), Color.Black);
        }
        //Draws the border of the rectangle for text
        public static void DrawRectangle(SpriteBatch spriteBatch, Rectangle rectangle, Color color, int lineWidth) {
            if (_pointTexture == null) {
                _pointTexture = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
                _pointTexture.SetData<Color>(new Color[] { Color.White });
            }

            spriteBatch.Draw(_pointTexture, new Rectangle(rectangle.X, rectangle.Y, lineWidth, rectangle.Height + lineWidth), color);
            spriteBatch.Draw(_pointTexture, new Rectangle(rectangle.X, rectangle.Y, rectangle.Width + lineWidth, lineWidth), color);
            spriteBatch.Draw(_pointTexture, new Rectangle(rectangle.X + rectangle.Width, rectangle.Y, lineWidth, rectangle.Height + lineWidth), color);
            spriteBatch.Draw(_pointTexture, new Rectangle(rectangle.X, rectangle.Y + rectangle.Height, rectangle.Width + lineWidth, lineWidth), color);
        }
    }

}
