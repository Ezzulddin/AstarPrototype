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
using SharpDX.Direct2D1.Effects;
using System.Drawing;

namespace AstarPrototype
{
    public class Vicinity
    {
        int radius = 4;
        
        public bool Area(TileLocation posOfP,TileLocation posOfM,Location startingPos, bool inArea)
        {

            for (int x = 0; x <= radius; x++)
            {
                for (int y = 0; y <= radius; y++)
                {
                    if (posOfP.x <= posOfM.x + x && posOfP.y <= posOfM.y+  y)
                    {
                        inArea = true;
                    }
                    else
                    {
                        inArea = false;
                    }

                }
            }
            return inArea;
        }
        

        public TileLocation PlayerPos(Tile[,] tileArray, Player player, TileLocation posOfP, GraphicsDeviceManager graphics)
        {
            for (int i = 0; i <= tileArray.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= tileArray.GetUpperBound(1); j++)
                {
                    if (player.spritePosition.X >= tileArray[i, j].spritePosition.X && player.spritePosition.X <= tileArray[i, j].spritePosition.X + graphics.PreferredBackBufferWidth
                        && player.spritePosition.Y >= tileArray[i, j].spritePosition.Y && player.spritePosition.Y <= tileArray[i, j].spritePosition.Y + graphics.PreferredBackBufferHeight)
                    {
                        posOfP.x = i;
                        posOfP.y = j;
                    }
                }
            }
            return posOfP;
        }
        public TileLocation MobPos(Tile[,] tileArray, Sprite mob, TileLocation posOfM,GraphicsDeviceManager graphics)
        {
            
            for (int i = 0; i <= tileArray.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= tileArray.GetUpperBound(1); j++)
                {
                    if (mob.spritePosition.X >= tileArray[i,j].spritePosition.X && mob.spritePosition.X <= tileArray[i,j].spritePosition.X + graphics.PreferredBackBufferWidth 
                        && mob.spritePosition.Y >= tileArray[i,j].spritePosition.Y && mob.spritePosition.Y <= tileArray[i,j].spritePosition.Y + graphics.PreferredBackBufferHeight)
                    {
                        posOfM.x = i;
                        posOfM.y = j;
                    }
                    
                }
            }
            return posOfM;
        }

    }
}
