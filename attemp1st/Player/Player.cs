using attemp1st.GraphicsLogic;
using attemp1st.MapLogic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace attemp1st.player
{
    public class Player : SpriteAtlas
    {

        public Input Input;
        public Bullet Bullet;
        public Player _player;


        protected Texture2D playerTexture;
        protected MouseState currentKey;
        protected MouseState previousKey;
        private float Speed = 1f;
        public float Velocity = 0f;
        private static int Frame = 0;
        public Player(Texture2D texture)
            : base(texture, 3, 5, Frame)
        {
            //Layer = 0;
            Size = 10;
        }
        public override void Update(GameTime gameTime, Camera camera, List<SpriteAtlas> sprites)
        {
            Move(gameTime, camera);
            Shoot(sprites);
            Rotate(camera);

            if (Keyboard.GetState().IsKeyDown(Keys.OemMinus))
            {
                camera.Zoom -= 0.01f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.OemPlus))
            {
                camera.Zoom += 0.01f;
            }

            /*currentFrame++;
            if (currentFrame >= totalFrames)
                currentFrame -= MovingState;*/
        }

        private void AddBullet(List<SpriteAtlas> sprites)
        {
            var b = Bullet.Clone() as Bullet;
            var mPos = new Vector2(Mouse.GetState().X, Mouse.GetState().Y);
            b.Position = Position;
            b.Direction = mPos - Game1.WindowCenter;
            if (b.Direction != Vector2.Zero)
                b.Direction = new Vector2(MathF.Cos(MathF.Atan2(b.Direction.Y, b.Direction.X) + Rotation),
                    MathF.Sin(MathF.Atan2(b.Direction.Y, b.Direction.X) + Rotation));
            b.Rotation = MathF.Atan2(b.Direction.Y, b.Direction.X) + MathF.PI / 0.45f;
            b.linearVelocity = 5;
            b.LifeSpan = 2;
            b.parent = this;

            sprites.Add(b);
        }
        private void Shoot(List<SpriteAtlas> sprites)
        {
            previousKey = currentKey;
            currentKey = Mouse.GetState();
            if ((currentKey.LeftButton == ButtonState.Pressed) && (previousKey.LeftButton == ButtonState.Released))
            {
                AddBullet(sprites);
            }
        }
        private void Move(GameTime gameTime, Camera camera)
        {
            if (Input == null)
            {
                return;
            }
            GetDirection(Input.Left, -Speed);
            GetDirection(Input.Up, spdY: -Speed);
            GetDirection(Input.Down, spdY: Speed);
            GetDirection(Input.Right, Speed);

        }
        private void GetDirection(Keys k, float spd = 0, float spdY = 0)
        {
            if (Keyboard.GetState().IsKeyDown(k))
            {
                Direction.X = spd != 0 ? spd  : Direction.X;
                Direction.Y = spdY != 0 ? spdY : Direction.Y;
                if (Direction != Vector2.Zero)
                {
                    Direction = new Vector2(MathF.Cos(MathF.Atan2(Direction.Y, Direction.X) + Rotation) ,
                        MathF.Sin(MathF.Atan2(Direction.Y, Direction.X) + Rotation) );
                    Position += Direction * 2;
                }
            }
        }
        private void Rotate(Camera _camera)
        {
            if (Keyboard.GetState().IsKeyDown(Input.RotateLeft))
            {
                 _camera.RotationDegrees += MathHelper.ToRadians(1);
                Rotation = -_camera.RotationDegrees;
            }
            if (Keyboard.GetState().IsKeyDown(Input.RotateRight))
            {
                _camera.RotationDegrees -= MathHelper.ToRadians(1);
                Rotation = -_camera.RotationDegrees;
            }
        }
    }
}
