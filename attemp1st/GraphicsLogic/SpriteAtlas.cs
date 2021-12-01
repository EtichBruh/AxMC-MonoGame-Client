using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace attemp1st.GraphicsLogic
{
    public class SpriteAtlas : ICloneable
    {
        protected Texture2D Texture { get; set; }
        public Vector2 Direction;
        public Vector2 Position;
        public Vector2 Origin;
        public Rectangle rectangle;

        public bool isRemoved = false;
        public int Rows { get; set; }
        public int Columns { get; set; }
        public int MovingState { get; set; }
        public int Size { get; set; }
        public float Rotation { get; set; }
        public SpriteAtlas parent;
        public int CurrentFrame { set; get; }
        public int TotalFrames { get; set; }
        public int Layer { get; set; }

        public SpriteEffects Effect;


        public SpriteAtlas(Texture2D spritesheet, int rows, int columns, int frame)
        {
            Texture = spritesheet;
            Rows = rows;
            Columns = columns;
            CurrentFrame = frame;
            Origin = new Vector2((Texture.Width / Columns) * 0.5f, (Texture.Height / Rows) * 0.5f);
        }
        public virtual void Update(GameTime gameTime, Camera camera, List<SpriteAtlas> sprites)
        {
            foreach(var s in sprites)
            {
                sprites.RemoveAll(s => s.isRemoved = true);
            }
        }
        public object Clone()
        {
            return MemberwiseClone();
        }
        public void Draw(SpriteBatch spritebatch, Vector2 location)
        {
            int width = Texture.Width / Columns; //Texture.Width / Columns
            int height = Texture.Height / Rows; //Texture.Height / Rows
            int row = CurrentFrame / Columns;
            int column = CurrentFrame % Columns;
            Rectangle destinationRectangle = new((int)location.X, (int)location.Y, width * Size, height * Size);

            Rectangle sourceRect = new(width * column, height * row, width, height);
            rectangle = destinationRectangle;
            spritebatch.Draw(Texture, destinationRectangle, sourceRect, Color.White, Rotation, Origin, Effect, 0);
        }
    }
}
