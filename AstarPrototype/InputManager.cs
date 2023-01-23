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
    public class InputManager
    {
        KeyboardState state;
        PhysicsManager physicsManager;
        public void CheckKeys(Player playerSprite, GraphicsDeviceManager inGraphics)
        {
            state = Keyboard.GetState();

            playerSprite.goingLeft = false;
            playerSprite.goingRight = false;
            playerSprite.goingUp = false;
            playerSprite.goingDown = false;
            physicsManager = new();
            if (state.IsKeyDown(Keys.A))
            {
                playerSprite.goingLeft = true;
                physicsManager.goLeft(playerSprite);
            }

            if (state.IsKeyDown(Keys.D))
            {
                playerSprite.goingRight = true;
                physicsManager.goRight(playerSprite);
            }

            if (state.IsKeyDown(Keys.W))
            {
                playerSprite.goingUp = true;
                physicsManager.goUp(playerSprite);
            }

            if (state.IsKeyDown(Keys.S))
            {
                playerSprite.goingDown = true;
                physicsManager.goDown(playerSprite);
            }
        }
    }
}
