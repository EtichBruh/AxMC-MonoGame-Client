using attemp1st.GraphicsLogic;
using attemp1st.MapLogic;
using attemp1st.player;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace attemp1st
{
    public class Game1 : Game
    {
        private Camera _camera;
        private TileMap Map;
        private Player Player { get; set; }
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private SpriteFont Arial;
        public List<SpriteAtlas> _sprites;
        //private Connection connection;
        readonly Random rand = new();
        public static Vector2 WindowCenter;
        private readonly string[] WindowNameAddition = new string[] { "Damn sussy", "Yey finnaly exist", "Thanks for playing flash ver", "Also try minecraft", "When the impostor is sus" };


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Window.AllowUserResizing = true;
            Window.Title = "AMC Realms: " + WindowNameAddition.GetValue(rand.Next(1, WindowNameAddition.Length));
        }


        protected override void Initialize()
        {

            // TODO: Add your initialization logic here
            _sprites = new();
            Map = new();
            Arial = Content.Load<SpriteFont>("Arial");

            //connection = new Connection();


            base.Initialize();
        }



        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            Texture2D playerTexture = Content.Load<Texture2D>("CrewMateMASK");
            Texture2D BulletTexture = Content.Load<Texture2D>("bullet");
            TileData.Tileset = Content.Load<Texture2D>("MCRTile");
            _camera = new Camera();
            Player = new Player(playerTexture)
            {
                Input = new Input()
                {
                    Left = Keys.A,
                    Down = Keys.S,
                    Right = Keys.D,
                    Up = Keys.W,
                    RotateLeft = Keys.Q,
                    RotateRight = Keys.E
                }
                    ,
                Position = new Vector2(100, 100)
                    ,
                Bullet = new Bullet(BulletTexture)

            };
            Map.MapLoad(new int[,] {
                {1, 0, 0, 0, 2, 0, 0, 0, 2, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 },
                {1, 0, 0, 0, 2, 2, 0, 2, 2, 0, 1, 0, 1, 0, 2,-1, 2, 0, 0, 0, 0, 0 },
                {1, 0, 0, 0, 2, 0, 2, 0, 2, 0, 1, 1, 1, 0, 1,-1, 1, 0, 0, 0, 0, 0 },
                {1, 1, 1, 0, 2, 0, 0, 0, 2, 0, 1, 0, 1, 0, 0, 2, 0, 0, 0, 0, 0, 0 },
                {1, 0, 0, 0, 2, 0, 0, 0, 2, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 },
                {1, 0, 0, 0, 2, 2, 0, 2, 2, 0, 1, 0, 1, 0, 2,-1, 2, 0, 0, 0, 0, 0 },
                {1, 0, 0, 0, 2, 0, 2, 0, 2, 0, 1, 1, 1, 0, 1,-1, 1, 0, 0, 0, 0, 0 },
                {1, 1, 1, 0, 2, 0, 0, 0, 2, 0, 1, 0, 1, 0, 0, 2, 0, 0, 0, 0, 0, 0 },
                {1, 0, 0, 0, 2, 0, 0, 0, 2, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 },
                {1, 0, 0, 0, 2, 2, 0, 2, 2, 0, 1, 0, 1, 0, 2,-1, 2, 0, 0, 0, 0, 0 },
                {1, 0, 0, 0, 2, 0, 2, 0, 2, 0, 1, 1, 1, 0, 1,-1, 1, 0, 0, 0, 0, 0 },
                {1, 1, 1, 0, 2, 0, 0, 0, 2, 0, 1, 0, 1, 0, 0, 2, 0, 0, 0, 0, 0, 0 },
                {1, 0, 0, 0, 2, 0, 0, 0, 2, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 },
                {1, 0, 0, 0, 2, 2, 0, 2, 2, 0, 1, 0, 1, 0, 2,-1, 2, 0, 0, 0, 0, 0 },
                {1, 0, 0, 0, 2, 0, 2, 0, 2, 0, 1, 1, 1, 0, 1,-1, 1, 0, 0, 0, 0, 0 },
                {1, 1, 1, 0, 2, 0, 0, 0, 2, 0, 1, 0, 1, 0, 0, 2, 0, 0, 0, 0, 0, 0 },
                {1, 0, 0, 0, 2, 0, 0, 0, 2, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 },
                {1, 0, 0, 0, 2, 2, 0, 2, 2, 0, 1, 0, 1, 0, 2,-1, 2, 0, 0, 0, 0, 0 },
                {1, 0, 0, 0, 2, 0, 2, 0, 2, 0, 1, 1, 1, 0, 1,-1, 1, 0, 0, 0, 0, 0 },
                {1, 1, 1, 0, 2, 0, 0, 0, 2, 0, 1, 0, 1, 0, 0, 2, 0, 0, 0, 0, 0, 0 },
                {1, 0, 0, 0, 2, 0, 0, 0, 2, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 },
                {1, 0, 0, 0, 2, 2, 0, 2, 2, 0, 1, 0, 1, 0, 2,-1, 2, 0, 0, 0, 0, 0 },
                {1, 0, 0, 0, 2, 0, 2, 0, 2, 0, 1, 1, 1, 0, 1,-1, 1, 0, 0, 0, 0, 0 },
                {1, 1, 1, 0, 2, 0, 0, 0, 2, 0, 1, 0, 1, 0, 0, 2, 0, 0, 0, 0, 0, 0 },
                {1, 0, 0, 0, 2, 0, 0, 0, 2, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 },
                {1, 0, 0, 0, 2, 2, 0, 2, 2, 0, 1, 0, 1, 0, 2,-1, 2, 0, 0, 0, 0, 0 },
                {1, 0, 0, 0, 2, 0, 2, 0, 2, 0, 1, 1, 1, 0, 1,-1, 1, 0, 0, 0, 0, 0 },
                {1, 1, 1, 0, 2, 0, 0, 0, 2, 0, 1, 0, 1, 0, 0, 2, 0, 0, 0, 0, 0, 0 },
                {1, 0, 0, 0, 2, 0, 0, 0, 2, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 },
                {1, 0, 0, 0, 2, 2, 0, 2, 2, 0, 1, 0, 1, 0, 2,-1, 2, 0, 0, 0, 0, 0 },
                {1, 0, 0, 0, 2, 0, 2, 0, 2, 0, 1, 1, 1, 0, 1,-1, 1, 0, 0, 0, 0, 0 },
                {1, 1, 1, 0, 2, 0, 0, 0, 2, 0, 1, 0, 1, 0, 0, 2, 0, 0, 0, 0, 0, 0 },
                {1, 0, 0, 0, 2, 0, 0, 0, 2, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 },
                {1, 0, 0, 0, 2, 2, 0, 2, 2, 0, 1, 0, 1, 0, 2,-1, 2, 0, 0, 0, 0, 0 },
                {1, 0, 0, 0, 2, 0, 2, 0, 2, 0, 1, 1, 1, 0, 1,-1, 1, 0, 0, 0, 0, 0 },
                {1, 1, 1, 0, 2, 0, 0, 0, 2, 0, 1, 0, 1, 0, 0, 2, 0, 0, 0, 0, 0, 0 },
                {1, 0, 0, 0, 2, 0, 0, 0, 2, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 },
                {1, 0, 0, 0, 2, 2, 0, 2, 2, 0, 1, 0, 1, 0, 2,-1, 2, 0, 0, 0, 0, 0 },
                {1, 0, 0, 0, 2, 0, 2, 0, 2, 0, 1, 1, 1, 0, 1,-1, 1, 0, 0, 0, 0, 0 },
                {1, 1, 1, 0, 2, 0, 0, 0, 2, 0, 1, 0, 1, 0, 0, 2, 0, 0, 0, 0, 0, 0 },
                {1, 0, 0, 0, 2, 0, 0, 0, 2, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 },
                {1, 0, 0, 0, 2, 2, 0, 2, 2, 0, 1, 0, 1, 0, 2,-1, 2, 0, 0, 0, 0, 0 },
                {1, 0, 0, 0, 2, 0, 2, 0, 2, 0, 1, 1, 1, 0, 1,-1, 1, 0, 0, 0, 0, 0 },
                {1, 1, 1, 0, 2, 0, 0, 0, 2, 0, 1, 0, 1, 0, 0, 2, 0, 0, 0, 0, 0, 0 },
                {1, 0, 0, 0, 2, 0, 0, 0, 2, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 },
                {1, 0, 0, 0, 2, 2, 0, 2, 2, 0, 1, 0, 1, 0, 2,-1, 2, 0, 0, 0, 0, 0 },
                {1, 0, 0, 0, 2, 0, 2, 0, 2, 0, 1, 1, 1, 0, 1,-1, 1, 0, 0, 0, 0, 0 },
                {1, 1, 1, 0, 2, 0, 0, 0, 2, 0, 1, 0, 1, 0, 0, 2, 0, 0, 0, 0, 0, 0 },
            }, this);
            _sprites.Add(Player);


            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            //WindowCenter = new Vector2(GraphicsDevice.Viewport.Width * 0.5f, GraphicsDevice.Viewport.Height * 0.5f);
            _camera.View = GraphicsDevice.Viewport;
            // TODO: Add your update logic here
            foreach (var sprites in _sprites)
            {
                sprites.Update(gameTime, _camera, this);
            }
            _sprites.RemoveAll(sprites => sprites.isRemoved);

            _camera.Follow(Player);
            base.Update(gameTime);
        }
        // _ = connection.Connect(_player);


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin(transformMatrix: _camera.Transform, samplerState: SamplerState.PointClamp);


            //Map.Draw(_spriteBatch);

            // TODO: Add your drawing code here
            foreach (var sprite in _sprites)
            {
                sprite.Draw(_spriteBatch, sprite.Position);
            }
            _spriteBatch.DrawString(Arial, new string($"X:{Player.Position.X}, Y:{Player.Position.Y}"), new Vector2(Player.Position.X - 76, Player.Position.Y - 40), Color.Red);


            _spriteBatch.End();

            //player.Draw(_spriteBatch);

            base.Draw(gameTime);
        }

    }
}
