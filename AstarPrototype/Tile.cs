using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Diagnostics;
using System;

namespace AstarPrototype
{
    public class Tile : Sprite
    {
        public Tile()
        {
        }
        public Tile(Texture2D inTexture, Vector2 inPosition, Vector2 inSize,Color colour)
            : base(inTexture, inPosition, inSize,colour)
        {
        }
        public Vector2 GetTilePosition { get; set; }
        public string TileType { get; set; }
    }
}
