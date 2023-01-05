using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Diagnostics;
using System;

namespace AstarPrototype
{
    public class Sprite
    {
        public Texture2D spriteTexture { get; set; }
        public Vector2 spritePosition { get; set; }
        public Vector2 spriteSize { get; set; }
        public Color spriteColour { get; set; }
        public Sprite()
        {

        }

        public Sprite(Texture2D tex, Vector2 pos, Vector2 size, Color spriteColour)
        {
            this.spriteTexture = tex;
            this.spritePosition = pos;
            this.spriteSize = size;
            this.spriteColour = spriteColour;
        }


        public void DrawSprite(SpriteBatch spriteBatch, Texture2D texture)

        {
            spriteTexture = texture;
            spriteBatch.Begin();
            spriteBatch.Draw(spriteTexture, new Rectangle((int)spritePosition.X, (int)spritePosition.Y, (int)spriteSize.X, (int)spriteSize.Y), spriteColour);
            spriteBatch.End();

        }
    }
}
