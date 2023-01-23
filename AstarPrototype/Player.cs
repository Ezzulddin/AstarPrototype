using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AstarPrototype
{
    public class Player : Sprite
    {
        public bool goingLeft;
        public bool goingRight;
        public bool goingUp;
        public bool goingDown;

        private bool isDrawn;
        
        public Player(Texture2D tex, Vector2 pos, Vector2 size, Color colour) : base(tex, pos, size, colour)
        {
        }
        
        public bool IsDrawn
        {
            get { return isDrawn; }
            set { isDrawn = value; }
        }
    }
}

