using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace attemp1st.GraphicsLogic
{
    public class SpriteAtlas// : ICloneable
    {
        public Texture2D Texture { get; set; }
        public SpriteAtlas parent;
        public Vector2 Direction;
        public Vector2 Position;
        public Vector2 Origin;
        public bool isRemoved = false;
        //private int _columns { get; set; }
        //public int MovingState { get; set; }
        public int Size { get; set; }
        public float Rotation { get; set; }
        public int CurrentFrame { set; get; }
        //public int TotalFrames { get; set; }
        private int width { get; set; }
        private int height { get; set; }
        public int Width,Height = 1;
        public SpriteEffects Effect;
        public SpriteAtlas(Texture2D spritesheet, int rows, int columns, int frame)
        {
            width = spritesheet.Width / columns;
            height = spritesheet.Height / rows;
            //_columns = columns;
            CurrentFrame = frame;
            Origin = new(width * 0.5f, height * 0.5f);
            Texture = Slice(spritesheet, width * (CurrentFrame % columns), height * (CurrentFrame / columns));

        }
        public virtual void Update(GameTime gameTime, Camera camera, List<SpriteAtlas> spritesToAdd) { }
        public object Clone()
        {
            return MemberwiseClone();
        }
        private Texture2D Slice(Texture2D org, int x, int y) // x is position on sprite sheet, same as y
        {
            Texture2D tex = new(org.GraphicsDevice, width, height);
            var data = new Color[width * height];
            org.GetData(0, new(x, y, width, height), data, 0, data.Length);
            tex.SetData(data);
            return tex;
        }
        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(Texture, new((int)Position.X, (int)Position.Y, Width, Height), null, Color.White, Rotation, Origin, Effect, 1);
        }
    }
}
