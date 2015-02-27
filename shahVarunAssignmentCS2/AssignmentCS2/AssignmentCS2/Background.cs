using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssignmentCS2
{
    class Background
    {
        public KeyboardState currentKeyboard;
        public Texture2D texture;
        public Rectangle rectangle;
        public void draw(SpriteBatch spritBatch)
        {
            spritBatch.Draw(texture, rectangle, Color.White);
        }
    }

    class LastBackground : Background
    {
        public LastBackground(Texture2D newTexture, Rectangle newRectangle)
        {
            texture = newTexture;
            rectangle = newRectangle;            
        }

        public void update()
        {
            currentKeyboard = Keyboard.GetState();
            if (currentKeyboard.IsKeyDown(Keys.Right) == true)
                rectangle.X -= 1;
            if (currentKeyboard.IsKeyDown(Keys.Left) == true)
                rectangle.X += 1;
        }
    }

    class ForeBackground : Background
    {
        public ForeBackground(Texture2D newTexture, Rectangle newRectangle)
        {
            texture = newTexture;
            rectangle = newRectangle;
        }

        public void update()
        {
            currentKeyboard = Keyboard.GetState();
            if (currentKeyboard.IsKeyDown(Keys.Right) == true)
                rectangle.X -= 5;
            if (currentKeyboard.IsKeyDown(Keys.Left) == true)
                rectangle.X += 5;
        }
    }
    class Middleground : Background
    {
        public Middleground(Texture2D newTexture, Rectangle newRectangle)
        {
            texture = newTexture;
            rectangle = newRectangle;
        }

        public void update()
        {
            currentKeyboard = Keyboard.GetState();
            if (currentKeyboard.IsKeyDown(Keys.Right) == true)
                rectangle.X -= 3;
            if (currentKeyboard.IsKeyDown(Keys.Left) == true)
                rectangle.X += 3;
        }
    }

}
