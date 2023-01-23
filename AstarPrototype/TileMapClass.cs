using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace AstarPrototype
{
    public class TileMapClass
    {
        Vector2 temPosition;
        Vector2 pSize = new Vector2(40,40);

        public Tile[,] CreateMap(Tile[,] tileArray, SquareGrid grid, char[,] tileValuesArray,int Tile_size, GraphicsDevice graphics,
            Texture2D emptyRec)
        {
            for(int i = 0; i <= tileArray.GetUpperBound(0); i++)
            {
                for(int j = 0; j <= tileArray.GetUpperBound(1);j++)
                {
                    if (tileValuesArray[i,j].ToString().Contains("1"))
                    {
                        temPosition = new Vector2(i * Tile_size, j * Tile_size);
                        tileArray[i,j] = new Tile(emptyRec, temPosition, pSize,Color.White);
                        
                    }
                    if (tileValuesArray[i, j].ToString().Contains("2"))
                    {
                        temPosition = new Vector2(i * Tile_size, j * Tile_size);
                        tileArray[i, j] = new Tile(emptyRec, temPosition, pSize, Color.White);
                        grid.walls.Add(new Location(i, j));
                    }
                    else if (tileValuesArray[i,j].ToString().Contains("0"))
                    {
                        tileArray[i,j] = new Tile(new Texture2D(graphics, 10, 10), new Vector2(0, 0), new Vector2(0, 0), Color.White);
                    }
                }
            }
            return tileArray;
        }
    }
}
