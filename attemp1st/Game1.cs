using attemp1st.GraphicsLogic;
using attemp1st.MapLogic;
using attemp1st.player;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Globalization;
using ButtonState = Microsoft.Xna.Framework.Input.ButtonState;
using Keys = Microsoft.Xna.Framework.Input.Keys;

//using System.Linq;

namespace attemp1st
{
    public class Game1 : Game
    {
        private Camera _camera;
        //private TileMap _map;
        private Block _block;
        private Player Player { get; set; }
        private Vector3 _cameraPos = new(0f, 0f, 2);
        Matrix _projectionMatrix;
        Matrix _viewMatrix;
        Matrix _worldMatrix;
        private Effect _outline;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private SpriteFont _arial;
        private List<SpriteAtlas> _sprites;
        private List<SpriteAtlas> SpritesToAdd;

        public Tile[] Tiles;
        //private Connection connection;
        readonly Random _rand = new();
        //public static Vector2 WindowCenter;
        private readonly string[] _windowNameAddition = { "Damn sussy", "Yey finnaly exist", "Thanks for playing flash ver", "Also try minecraft", "When the impostor is sus" };


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Window.AllowUserResizing = true;
            Window.Title = "AMC Realms: " + _windowNameAddition[_rand.Next(0, _windowNameAddition.Length)];
            //_graphics.SynchronizeWithVerticalRetrace = false;
            //the sIsFixedTimeStep = false;
        }


        protected override void Initialize()
        {

            // TODO: Add your initialization logic here
            _block = new();

            SpritesToAdd = new();
            _block.BlockInit(_graphics.GraphicsDevice);
            _sprites = new();
            //_map = new();
            _arial = Content.Load<SpriteFont>("Arial");
            _viewMatrix = Matrix.CreateLookAt(_cameraPos, Vector3.Forward, Vector3.Up);

            _projectionMatrix = Matrix.CreateOrthographic(GraphicsDevice.Viewport.Width / 50f, GraphicsDevice.Viewport.Height / 50f, 0f, 100f);

            _worldMatrix = Matrix.CreateWorld(new(0, 0, 0), Vector3.Forward, Vector3.Up);


            //connection = new Connection();


            base.Initialize();
        }



        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _outline = Content.Load<Effect>("outline");

            _outline.Parameters["xOutlineColour"].SetValue(new Vector4(1f, 1f, 0f, 1.0f));
            TileData.Tileset = Content.Load<Texture2D>("MCRTile");
            TileMap.MapLoad(new[,] {
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
            }, ref Tiles);
            _camera = new Camera();
            Player = new Player(Content.Load<Texture2D>("CrewMateMASK"), Content.Load<Texture2D>("bullet"))
            {
                Input = new Input
                {
                    Left = Keys.A,
                    Down = Keys.S,
                    Right = Keys.D,
                    Up = Keys.W,
                    RotateLeft = Keys.Q,
                    RotateRight = Keys.E
                }
                    ,
                Position = new Vector2(100, 100),
                PlayersBullet = new()
            };

            _outline.Parameters["uvPix"].SetValue(new Vector2(1f / Player.Width, 1f / Player.Height));
            
            SpritesToAdd.Add(Player);


            // TODO: use this.Content to load your game content here
        }
        protected override void UnloadContent()
        {
        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _camera.View = GraphicsDevice.Viewport;
            Window.Title = (1000f / (float)gameTime.ElapsedGameTime.TotalMilliseconds).ToString(CultureInfo.CurrentCulture);
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                _worldMatrix *= Matrix.CreateRotationY(MathHelper.ToRadians(1));

            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                _worldMatrix *= Matrix.CreateRotationY(-1 * MathHelper.ToRadians(1));

            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                _worldMatrix *= Matrix.CreateRotationX(-1 * MathHelper.ToRadians(1));

            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                _worldMatrix *= Matrix.CreateRotationX(MathHelper.ToRadians(1));

            }
            //CameraPos = new(Mouse.GetState().X * 2f, Mouse.GetState().Y * 2f, CameraPos.Z);

            if(SpritesToAdd.Count > 0) for (int i = 0; i < SpritesToAdd.Count; i++) { _sprites.Add(SpritesToAdd[i]); SpritesToAdd.RemoveAt(i); i--; }
            
            
            for (int i = 0; i < _sprites.Count; i++)
            {

                _sprites[i].Update(gameTime, _camera, SpritesToAdd);
                if (!_sprites[i].isRemoved) continue;
                _sprites.RemoveAt(i);
                i--;
            }
            //_sprites.RemoveAll(sprites => sprites.isRemoved);

            //_sprites.ForEach(action => action.Update(gameTime, _camera, spritesToAdd));

            _camera.Follow(Player);
            base.Update(gameTime);
        }
        // _ = connection.Connect(_player);


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin(effect: _outline, transformMatrix: _camera.Transform, samplerState: SamplerState.PointClamp, blendState: BlendState.AlphaBlend);
            foreach(Tile t in Tiles)
            {
                if ((t.rect.Center.ToVector2() - Player.Position).Length() < 500)
                {
                    t.Draw(_spriteBatch);
                }
            }
            for(int i = 0; i < _sprites.Count; i++)
            {
                _sprites[i].Draw(_spriteBatch);
            }
            _spriteBatch.DrawString(_arial, new string($"X: {Player.Position.X}, Y: {Player.Position.Y}"), new(Player.Position.X - Player.Width, Player.Position.Y - Player.Height), Color.Black);

            _spriteBatch.End();

            _block.BasiceCubeEff.View = _viewMatrix;
            _block.BasiceCubeEff.Projection = _projectionMatrix;
            _block.BasiceCubeEff.World = _worldMatrix;
            GraphicsDevice.SetVertexBuffer(_block.VertexBuffer);
            GraphicsDevice.Indices = _block.IndexBuffer;
            foreach (EffectPass pass in _block.BasiceCubeEff.CurrentTechnique.Passes)
            {
                pass.Apply();
                GraphicsDevice.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, 12); // la cube drawing
            }
            base.Draw(gameTime);
        }

    }
}
