using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FallingWoman.Helpers
{
    public static class DrawHelpers
    {
        public static void DrawRectangle(SpriteBatch spriteBatch, int x, int y, int width, int height, Color color, bool filled)
        {
            if (filled)
            {
                spriteBatch.Draw(FallingWoman.Pixel, new Rectangle(x, y, width, height), color);
            }
            else
            {
                DrawLine(spriteBatch, x, y, width, 1,color);
                DrawLine(spriteBatch, x + width - 1, y, 1, height, color);
                DrawLine(spriteBatch, x, y, 1, height, color);
                DrawLine(spriteBatch, x, y + height - 1, width, 1, color);    
            }
        }
        
        public static void DrawLine(SpriteBatch spriteBatch, int x, int y, int width, int height, Color color)
        {
            spriteBatch.Draw(FallingWoman.Pixel, new Rectangle(x, y, width, height), color);
        }
    }
}