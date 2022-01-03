using attemp1st.GraphicsLogic;
using Microsoft.Xna.Framework.Graphics;

namespace attemp1st.MapLogic
{
    public class TileData : SpriteAtlasLite
    {
        public static Texture2D Tileset { get; set; }

        public TileData(int offset)
            : base(Tileset, 1, 3, offset) //prob can be merged ?
        {
            // Layer = 1;
            Width = 50;
            Height = 50;
        }
    }
    public class Tile : TileData
    {
        public Tile(int id, float x, float y)
            : base(id)
        {
            rect = new((int)x * Width, (int)y * Height, Width, Height);
            //Layer = 1;
        }
    }
}
