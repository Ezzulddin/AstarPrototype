using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using System.Drawing.Text;
using System.Text.RegularExpressions;

namespace AstarPrototype
{
    public class AI
    {
        private PhysicsManager pManager;
        public void DrawPath(SquareGrid grid, AStarSearch aStar, Tile[,] tileArray)
        {
            for (int row = 0; row < grid.Rows; row++)
            {
                for (int column = 0; column < grid.Columns; column++)
                {
                    Location cell = new Location(column, row);
                    if (cell == aStar.Start)
                    {
                        tileArray[column, row].spriteColour = Color.Blue;
                    }
                    else if (cell == aStar.Goal)
                    {
                        tileArray[column, row].spriteColour = Color.Green;
                    }
                    else if (aStar.Path.Contains(cell))
                    {
                        tileArray[cell.X, cell.Y].spriteColour = Color.Silver;
                    }
                }
            }
        }
        public Sprite FollowPath(SquareGrid grid, AStarSearch aStar, TileLocation posOfM, Sprite mob)
        {
            pManager = new();
            for (int row = 0; row < grid.Rows; row++)
            {
                for (int column = 0; column < grid.Columns; column++)
                {
                    Location cell = new Location(column, row);

                    if (aStar.Path.Contains(cell))
                    {
                        if (posOfM.x <= cell.X && posOfM.y == cell.Y)
                        {
                            pManager.GoRight(mob);
                        }
                        if (posOfM.x >= cell.X && posOfM.y == cell.Y)
                        {
                            pManager.GoLeft(mob);
                            
                        }
                        if (posOfM.x == cell.X && posOfM.y <= cell.Y)
                        {
                            pManager.GoDown(mob);
                            
                        }
                        if (posOfM.x == cell.X && posOfM.y >= cell.Y)
                        {
                            pManager.GoUp(mob);
                        }
                    }
                }
            }
            return mob;
        }
        
        public void DrawWalls(SquareGrid grid, AStarSearch aStar, Tile[,] tileArray)
        {
            for (int row = 0; row < grid.Rows; row++)
            {
                for (int column = 0; column < grid.Columns; column++)
                {
                    Location cell = new Location(column, row);
                    if (grid.walls.Contains(cell))
                    {
                        tileArray[column, row].spriteColour = Color.Red;
                    }
                }
            }
        }
    }
}
