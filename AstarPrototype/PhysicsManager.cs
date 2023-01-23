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
    public class PhysicsManager
    {
        private float playerspeed = 1f;
        private float mobspeed = 0.5f;
        public void goLeft(Player playerSprite)
        {
            playerSprite.spritePosition = new Vector2(playerSprite.spritePosition.X - playerspeed, playerSprite.spritePosition.Y);
        }
        public void goRight(Player playerSprite)
        {
            playerSprite.spritePosition = new Vector2(playerSprite.spritePosition.X + playerspeed, playerSprite.spritePosition.Y);
        }
        public void goUp(Player playerSprite)
        {
            playerSprite.spritePosition = new Vector2(playerSprite.spritePosition.X, playerSprite.spritePosition.Y - playerspeed);
        }
        public void goDown(Player playerSprite)
        {
            playerSprite.spritePosition = new Vector2(playerSprite.spritePosition.X, playerSprite.spritePosition.Y + playerspeed);
        }
        public void GoRight(Sprite mob)
        {
            mob.spritePosition = new Vector2(mob.spritePosition.X + mobspeed, mob.spritePosition.Y);
        }
        public void GoLeft(Sprite mob)
        {
            mob.spritePosition = new Vector2(mob.spritePosition.X - mobspeed, mob.spritePosition.Y);
        }
        public void GoUp(Sprite mob)
        {
            mob.spritePosition = new Vector2(mob.spritePosition.X, mob.spritePosition.Y - mobspeed);
        }
        public void GoDown(Sprite mob)
        {
            mob.spritePosition = new Vector2(mob.spritePosition.X, mob.spritePosition.Y + mobspeed);
        }
    }
}
