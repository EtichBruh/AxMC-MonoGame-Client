using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace attemp1st.GraphicsLogic
{
    public class SpriteAtlasLite
    {
        public Texture2D Texture { get; set; }
        public Rectangle rect;
        public bool isRemoved = false;
        public int Width, Height = 1;
        public SpriteAtlasLite(Texture2D spritesheet, int rows, int columns, int frame)
        {
            int width = spritesheet.Width / columns;
            int height = spritesheet.Height / rows;
            Texture = new(spritesheet.GraphicsDevice, width, height);
            var data = new Color[width * height];
            spritesheet.GetData(0, new(width * (frame % columns), height * (frame / columns), width, height), data, 0, data.Length);
            Texture.SetData(data);
            // Texture = Slice(spritesheet, width * (CurrentFrame % columns), height * (CurrentFrame / columns));
        }
        //public virtual void Update(GameTime gameTime, Camera camera, List<SpriteAtlas> spritesToAdd) { }
        /*private Texture2D Slice(Texture2D org, int x, int y) // x is position on sprite sheet, same as y
        {
            Texture2D tex = new(org.GraphicsDevice, width, height);
            var data = new Color[width * height];
            org.GetData(0, new(width * (CurrentFrame % columns), height * (CurrentFrame / columns), width, height), data, 0, data.Length);
            tex.SetData(data);
            return tex;
        }*/ // currently implemented in class
        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(Texture, rect, Color.White);
        }
    }
}
