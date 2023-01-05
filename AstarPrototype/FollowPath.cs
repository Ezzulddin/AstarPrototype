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

namespace AstarPrototype
{
    public class FollowPath
    {
        private float speed = 0.5f;
        private AStarSearch aStar;
        private SquareGrid grid;
        private Sprite mob;
        public FollowPath(AStarSearch AStar,SquareGrid Grid ,Sprite Mob)
        {
            aStar = AStar;
            grid = Grid;
            mob = Mob;
        }
        public void PathAI(AStarSearch aStar, SquareGrid grid, Sprite mob)
        {
            
            for (int row = 0; row < grid.Rows; row++)
            {
                for (int column = 0; column < grid.Columns; column++)
                {
                    Location cell = new(column, row);
                    if (aStar.Path.Contains(cell))
                    {
                        if (mob.spritePosition.X > cell.X)
                        {
                            do
                                mob = new Sprite(mob.spriteTexture, new Vector2(mob.spritePosition.X - speed, mob.spritePosition.Y), mob.spriteSize, Color.White);
                            while (mob.spritePosition.X < cell.X);
                        }
                        if (mob.spritePosition.X < cell.X)
                        {
                            do
                                mob = new Sprite(mob.spriteTexture, new Vector2(mob.spritePosition.X + speed, mob.spritePosition.Y), mob.spriteSize, Color.White);
                            while (mob.spritePosition.X > cell.X);
                        }
                        if (mob.spritePosition.Y < cell.Y)
                        {
                            do
                                mob = new Sprite(mob.spriteTexture, new Vector2(mob.spritePosition.X, mob.spritePosition.Y + speed), mob.spriteSize, Color.White);
                            while (mob.spritePosition.Y > cell.Y);
                        }
                        if (mob.spritePosition.Y > cell.Y)
                        {
                            do
                                mob = new Sprite(mob.spriteTexture, new Vector2(mob.spritePosition.X, mob.spritePosition.Y - speed), mob.spriteSize, Color.White);
                            while (mob.spritePosition.Y < cell.Y);
                        }
                    }
                }
            }
        }

    }
}
