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
        Texture2D rect;
        Vector2 coor;
        Color[] data = new Color[80 * 30];
        
        private string _typedString = string.Empty;
        private bool _isCursorVisible = true;
        private const float _cursorBlinkDelay = 0.5f;
        private float _cursorBlinkDelta = _cursorBlinkDelay;

        public InputText(int x, int y) {
            rect = new Texture2D(Game1.graphics.GraphicsDevice, 80, 30);
            //Color data = Color.Chocolate;
            coor = new Vector2(x, y);
            for (int i = 0; i < data.Length; i++)
                data[i] = Color.White;
            rect.SetData(data);
            Input();

            
        }
        public void Input(){
            var mouseListener = Game1.inputManager.AddListener(new MouseListenerSettings());
            var keyboardListener = Game1.inputManager.AddListener(new KeyboardListenerSettings());

            keyboardListener.KeyTyped += (sender, args) =>
            {
                if (args.Key == Keys.Back && _typedString.Length > 0)
                {
                    _typedString = _typedString.Substring(0, _typedString.Length - 1);
                }
                else if (args.Key == Keys.Enter)
                {
                    //LogMessage(_typedString);
                    _typedString = string.Empty;
                }
                else
                {
                    _typedString += args.Character?.ToString() ?? "";
                }
            };
        }
        public void Update(GameTime gameTime) {
            _cursorBlinkDelta -= (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (_cursorBlinkDelta <= 0)
            {
                _isCursorVisible = !_isCursorVisible;
                _cursorBlinkDelta = _cursorBlinkDelay;
            }

            Game1.inputManager.Update(gameTime);

        }
        public void Draw(SpriteBatch spriteBatch) {
            var stringRectangle = Game1.font.GetStringRectangle(_typedString, coor);
            spriteBatch.Draw(rect, coor, Color.White);
            spriteBatch.DrawString(Game1.font, _typedString, coor, Color.Black);

            if (_isCursorVisible)
                spriteBatch.DrawString(Game1.font, "|", new Vector2(50, 50), Color.Black);

        }
    }
}
