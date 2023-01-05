using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.DirectWrite;

namespace AstarPrototype
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private char[,] tileValuesArray;
        private Texture2D emptyRec;
        private const int TILE_SIZE = 40;
        private Tile[,] tileArray = new Tile[20, 20];
        private TileMapClass tileMap = new TileMapClass();
        private SquareGrid grid = new SquareGrid(20, 20);
        private int first = 7;
        private int second = 6;
        private int firstStart = 0;
        private int secondStart = 0;
        private Location endingLocation = new Location();
        private Location startingLocation = new Location();
        private AStarSearch aStar;
        private Texture2D mobTex;
        private Sprite mob;
        private Vector2 startPos;
        private Vector2 endPos;
        private Vector2 mobSize;
        private FollowPath ai;
        private float speed = 0.5f;
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
            emptyRec = Content.Load<Texture2D>("BlankImage");
            GenerateFloorMap();
            mobTex = Content.Load<Texture2D>("Mob");
            startPos = new Vector2(startingLocation.X,startingLocation.Y);
            mobSize = new Vector2(40, 40);
            mob = new Sprite(mobTex, startPos, mobSize, Color.White);

            

        }
        public void GenerateFloorMap()
        {
            tileArray = tileMap.CreateMap(tileArray,grid ,tileValuesArray, TILE_SIZE, GraphicsDevice, emptyRec);
        }
        public void DrawGrid(SquareGrid grid, AStarSearch aStar)
        {
            for(int row = 0; row < grid.Rows; row++)
            {
                for(int column = 0; column < grid.Columns; column++)
                {
                    Location cell = new Location(column, row);
                    if(cell == aStar.Start)
                    {
                        tileArray[column,row].spriteColour = Color.Blue;
                    }
                    else if(cell == aStar.Goal)
                    {
                        tileArray[column,row].spriteColour = Color.Green;
                    }
                    else if(grid.walls.Contains(cell))
                    {
                        tileArray[column, row].spriteColour = Color.Red;
                    }
                    else if (aStar.Path.Contains(cell))
                    {
                        tileArray[column, row].spriteColour = Color.Silver;
                        if ((int)mob.spritePosition.X > cell.X)
                        {
                            while((int)mob.spritePosition.X > cell.X)
                            {
                                mob = new Sprite(mob.spriteTexture, new Vector2(mob.spritePosition.X - speed, mob.spritePosition.Y), mob.spriteSize, Color.White);
                                if((int)mob.spritePosition.X >= cell.X)
                                {
                                    break;
                                }
                            }
                        }
                        else if ((int)mob.spritePosition.X < cell.X)
                        {
                            while ((int)mob.spritePosition.X < cell.X)
                            {
                                mob = new Sprite(mob.spriteTexture, new Vector2(mob.spritePosition.X + speed, mob.spritePosition.Y), mob.spriteSize, Color.White);
                                if ((int)mob.spritePosition.X >= cell.X)
                                {
                                    break;
                                }
                            }
                            
                        }
                        else if ((int)mob.spritePosition.Y < cell.Y)
                        {
                            while ((int)mob.spritePosition.Y < cell.Y)
                            {
                                mob = new Sprite(mob.spriteTexture, new Vector2(mob.spritePosition.X, mob.spritePosition.Y + speed), mob.spriteSize, Color.White);
                                if ((int)mob.spritePosition.Y >= cell.Y)
                                {
                                    break;
                                }
                            }
                            
                        }
                        else if ((int)mob.spritePosition.Y > cell.Y)
                        {
                            while ((int)mob.spritePosition.Y > cell.Y)
                            {
                                mob = new Sprite(mob.spriteTexture, new Vector2(mob.spritePosition.X, mob.spritePosition.Y - speed), mob.spriteSize, Color.White);
                                if ((int)mob.spritePosition.Y <= cell.Y)
                                {
                                    break;
                                }
                            }
                            
                        }
                    }

                }
            }
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            //ai = new FollowPath(aStar,grid,mob);
            //ai.PathAI(aStar, grid, mob);
            startingLocation = new Location(firstStart, secondStart);
            aStar = new AStarSearch(grid);
            endingLocation = new Location(first, second);
            aStar.CalculatedPath(startingLocation, endingLocation);
            DrawGrid(grid, aStar);
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
            base.Draw(gameTime);
        }
    }
}