using FallingWoman.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FallingWoman.Entities
{
    public class Player : IGameEntity
    {
        private float elapsed;
        private float delay = 200f;
        private int frames = 0;

        private Sprite _idleSprite;

        private Rectangle destRect;
        private Rectangle sourceRect;

        public Vector2 Position = new Vector2();

        private KeyboardState keyboardState;

        public PlayerState State { get; private set; }
        public bool IsAlive { get; private set; }
        public int DrawOrder { get; set; }

        public Player(Texture2D spriteSheet, Vector2 position) // need to add sound effect parameter
        {
            Position = position;
            State = PlayerState.Idle;
            _idleSprite = new Sprite(spriteSheet, 0, 0, 33, 80);
        }

        public void Initialize()
        {
            State = PlayerState.Idle;
            IsAlive = true;
            destRect = new Rectangle(100, 100, 33, 80);
        }

        private void Walk(GameTime gameTime)
        {
            State = PlayerState.Walking;

            elapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (elapsed >= delay)
            {
                if (frames >= 2)
                {
                    frames = 0;
                }
                else
                {
                    frames++;
                }

                elapsed = 0;
            }

            sourceRect = new Rectangle(33 * frames, 0, 33, 80);
        }


        public void Update(GameTime gameTime)
        {
            keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Right))
            {
                Position.X += 2f;
            }

            Walk(gameTime);

            destRect = new Rectangle((int)Position.X, (int)Position.Y, 33, 80);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
        }
    }
}
