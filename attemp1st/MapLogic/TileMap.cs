using attemp1st.GraphicsLogic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace attemp1st.MapLogic
{
    public class TileMap
    {
        public TileMap() { }
        public void MapLoad(int[,] map, Game1 game)
        {
            for (int x = 0; x < map.GetLength(1); x++)
                for (int y = 0; y < map.GetLength(0); y++)
                {
                    int number = map[y, x];
                    if (number > -1)
                    {
                        game._sprites.Add(new Tile(number, new Vector2(x, y)));
                    }
                    
                }
            //File.WriteAllText("test.json", JsonSerializer.Serialize((object)map)); // not working oof
        }
    }

}
