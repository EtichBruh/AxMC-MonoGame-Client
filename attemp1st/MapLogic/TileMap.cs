using attemp1st.GraphicsLogic;
using System.Collections.Generic;
using SharpDX.Direct3D11;
using System.Linq;

namespace attemp1st.MapLogic
{
    public class TileMap
    {
        public static void MapLoad(int[,] map, ref Tile[] tiles)
        {
            tiles = new Tile[map.GetLength(1) * map.GetLength(0)];
            for (int x = 0; x < map.GetLength(1); x++)
                for (int y = 0; y < map.GetLength(0); y++)
                {
                    int number = map[y, x];
                    if(number == -1)continue;
                    
                    tiles[y * map.GetLength(1) + x] = new Tile(number, x, y);
                }
        }
    }

}
