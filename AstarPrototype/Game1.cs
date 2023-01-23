using Microsoft.VisualBasic.FileIO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;
using SharpDX.DirectWrite;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;

namespace AstarPrototype
{
    public class Game1 : Game
    {
        #region variables
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private char[,] tileValuesArray;
        private Texture2D emptyRec;
        private const int TILE_SIZE = 40;
        private Tile[,] tileArray = new Tile[20, 20];
        private TileMapClass tileMap = new();
        private SquareGrid grid = new SquareGrid(20, 20);
        private Location endingLocation = new();
        private Location startingLocation = new();
        private AStarSearch aStar;
        private Texture2D mobTex;
        private Texture2D pTex;
        private Vector2 pPos;
        private Sprite mob;
        private Vector2 startPos;
        private Vector2 mobSize;
        private InputManager iManager = new();
        private Player player;
        private Vicinity area = new();
        private bool inArea = false;
        private TileLocation posOfPlayer,posOfMob;
        private AI walls;
        private AI ai;
        private AI path;
        #endregion

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 800;
            MapReader.MapSize = 20;
            
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            tileArray = new Tile[MapReader.MapSize, MapReader.MapSize];
            tileValuesArray = MapReader.ReadFile("../../../Content/AStar/ForAstar");
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            #region Content
            emptyRec = Content.Load<Texture2D>("BlankImage");
            mobTex = Content.Load<Texture2D>("Mob");
            pTex = Content.Load<Texture2D>("Mob");
            pPos = new Vector2(400, 400);
            startPos = new Vector2(200,80);
            mobSize = new Vector2(40, 40);
            mob = new Sprite(mobTex, startPos, mobSize, Color.White);
            player = new Player(pTex,pPos,new Vector2(40,40),Color.White);
            posOfPlayer = new TileLocation(0,0);
            posOfMob = new TileLocation(0, 0);
            walls = new ();
            path = new();
            ai = new();
            #endregion

            GenerateFloorMap();
        }
        public void GenerateFloorMap()
        {
            tileArray = tileMap.CreateMap(tileArray,grid ,tileValuesArray, TILE_SIZE, GraphicsDevice, emptyRec);
        }
        

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            
            aStar = new AStarSearch(grid);
            posOfPlayer = area.PlayerPos(tileArray, player, posOfPlayer,_graphics);
            posOfMob = area.MobPos(tileArray, mob, posOfMob,_graphics);
            startingLocation = new Location(posOfMob.x, posOfMob.y);
            endingLocation = new Location(posOfPlayer.x,posOfPlayer.y);
            inArea = area.Area(posOfPlayer,posOfMob, startingLocation, inArea);
            if (inArea == true)
            {
                aStar.CalculatedPath(startingLocation, endingLocation);
                path.DrawPath(grid, aStar, tileArray);
                mob = ai.FollowPath(grid, aStar, posOfMob, mob);
            }

            walls.DrawWalls(grid, aStar, tileArray);
            
            iManager.CheckKeys(player, _graphics);
            
            base.Update(gameTime);
        }
        
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            foreach(Tile t in tileArray)
            {
                t.DrawSprite(_spriteBatch, t.spriteTexture);
            }
            mob.DrawSprite(_spriteBatch, mobTex);
            player.DrawSprite(_spriteBatch, pTex);
            base.Draw(gameTime);
        }
    }
}