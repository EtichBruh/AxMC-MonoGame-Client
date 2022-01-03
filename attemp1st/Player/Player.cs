using attemp1st.GraphicsLogic;
using attemp1st.MapLogic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using MonoGame.Extended.Collisions;
using attemp1st.Classes;

namespace attemp1st.player
{
    public class Player : SpriteAtlas
    {

        public Input Input;
        public Bullet PlayersBullet;
        
        //public Player _player;

        //protected Texture2D playerTexture;
        //private MouseState _currentKey;
        //private MouseState _previousKey;
        private KeyboardState _keyBstate;
        //private readonly float Speed = 2f;
        public float Velocity = 0f;
        private static int Frame = 0;
        public Player(Texture2D texture, Texture2D BulletTexture)
            : base(texture, 3, 5, Frame)
        {
            //Layer = 0;
            Bullet.texture = BulletTexture;
            Width = 64;
            Height = Width;
        }
        public override void Update(GameTime gameTime, Camera camera, List<SpriteAtlas> spritesToAdd)
        {
            _keyBstate = Keyboard.GetState();
            if (Position.Y - Texture.Bounds.Center.Y <= 0)
            {
                Position.Y -= Direction.Y;
                return;
            }
            if (Position.X - Texture.Width <= 0)
            {
                Position.X -= Direction.X;
                return;
            }
            Move(gameTime, camera);
            //_currentKey = ;
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                AddBullet(spritesToAdd, camera);
            }
            Rotate(camera);
            if (_keyBstate.IsKeyDown(Keys.OemMinus))
            {
                camera.Zoom -= 0.01f;
            }
            if (_keyBstate.IsKeyDown(Keys.OemPlus))
            {
                camera.Zoom += 0.01f;
            }
        }
        private float _spawnedBullets = 0.1f;// piece of code needed for spiral shooting

        private void AddBullet(List<SpriteAtlas> spritesToAdd, Camera cam)
        {
            Bullet b = PlayersBullet.Clone() as Bullet;
            b.Position = Position;
            if (_spawnedBullets > 360) _spawnedBullets = 0;
            b.Direction.X += MathF.Cos(_spawnedBullets);
            b.Direction.Y += MathF.Sin(_spawnedBullets);
           // b.Direction = Vector2.Normalize(Vector2.Transform(new(currentKey.X, currentKey.Y), Matrix.Invert(cam.Transform)) - Position);
            b.LinearVelocity = 5;
            b.LifeSpan = 10;
            b.parent = this;
            spritesToAdd.Add(b);
            _spawnedBullets += 0.1f;
        }

        private void Move(GameTime gameTime, Camera camera)
        {
            if (Input == null)
            {
                return;
            }

            if (_keyBstate.IsKeyDown(Input.Left))
            {
                if (Effect != SpriteEffects.FlipHorizontally)
                    Effect = SpriteEffects.FlipHorizontally;
                Direction.X = -1;
                Position.X += Direction.X;
            }
            if (_keyBstate.IsKeyDown(Input.Right))
            {
                if (Effect == SpriteEffects.FlipHorizontally)
                    Effect = SpriteEffects.None;
                Direction.X = 1;
                Position.X += Direction.X;
            }
            if (_keyBstate.IsKeyDown(Input.Up))
            {
                Direction.Y = -1;
                Position.Y += Direction.Y;
            }
            if (_keyBstate.IsKeyDown(Input.Down))
            {
                Direction.Y = 1;
                Position.Y += Direction.Y;
            }

            if (Position.Y - Texture.Bounds.Center.Y <= 0)
            {
                Position.Y -= Direction.Y;
                //return;
            }
          if(Position.X - Texture.Width <= 0)
            {
                Position.X -= Direction.X;
                //return;
            }

        }
        private void Rotate(Camera camera)
        {
            if (_keyBstate.IsKeyDown(Input.RotateLeft))
            {
                camera.RotationDegrees += MathHelper.ToRadians(1);
                Rotation = -camera.RotationDegrees;
            }

            if (!_keyBstate.IsKeyDown(Input.RotateRight)) return;
            camera.RotationDegrees -= MathHelper.ToRadians(1);
            Rotation = -camera.RotationDegrees;
        }
    }
}
