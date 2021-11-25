using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FallingWoman.Entities
{
    public interface IGameEntity
    {
        int DrawOrder { get; }

        void Update(GameTime gameTime);

        void Draw(SpriteBatch spriteBatch);
    }
}
