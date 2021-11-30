using attemp1st.GraphicsLogic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace attemp1st.MapLogic
{
    public class TileData : SpriteAtlas
    {
        public static Texture2D Tileset { get; set; }

        public TileData(int Offset)
            : base(Tileset, 1, 3, Offset) //prob can be merged ?
        {
           // Layer = 1;
            Size = 5;
        }
    }
    public class Tile : TileData
    {
        public Tile(int i, Vector2 newPos)
            : base(i)
        {
            Position = newPos * 16 * Size;
            //Layer = 1;
        }
    }
}
