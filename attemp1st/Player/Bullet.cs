using attemp1st.GraphicsLogic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Threading;

namespace attemp1st.player
{
    public class Bullet : SpriteAtlas
    {
        public float LifeSpan = 5f;
        private readonly float _angleOffsetFromTexture = MathF.Atan(0.9f);
        public float LinearVelocity = 4f;//prob bullet speed lul
        float _totalSeconds;


        public Bullet(Texture2D texture)
            : base(texture, 1, 1, 0)
        {
            Width = 8 * 4;
            Height = Width;
        }
        static Vector2 RotatePoint(Vector2 origin, float rotation, Vector2 p)
        {
            origin.Normalize();
            float cos = MathF.Cos(rotation) * 200,
                sin = MathF.Sin(rotation) * 200,
                xcos = -origin.X * cos,
                ycos = -origin.Y * cos,
                xsin = -origin.X * sin,
                ysin = -origin.Y * sin;
            return new Vector2(xcos - ysin + p.X, xsin + ycos + p.Y);
        }
        public override void Update(GameTime gameTime, Camera camera, List<SpriteAtlas> spritesToAdd)
        {
            _totalSeconds += (float)gameTime.ElapsedGameTime.TotalSeconds;
            LifeSpan -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (LifeSpan <= 0)
            {
                isRemoved = true;
                
            }
            else
            {
                //Rotation += rotationVelocity * (float)gameTime.ElapsedGameTime.TotalSeconds; // rotation in future 
                //(MathF.Cos(MathF.Atan2(b.Direction.Y, b.Direction.X)

                //var DirectionEff1 = Direction;
                //
                //Direction.X -= Direction.X * MathF.Cos(Direction.X);
                // Direction.Y = MathF.Sin(Direction.X);
                //Direction.X += 0.01f;
                //Direction = LifeSpan <= 2.5f ? Vector2.Normalize(parent.Position - Position) : Direction;
                Rotation = MathF.Atan2(Direction.Y, Direction.X) + _angleOffsetFromTexture;

                //Direction = LifeSpan <= 4.8f ? new(MathF.Cos(Rotation), MathF.Sin(Rotation)) : Direction;
                //Position += Direction * linearVelocity;
                
                Position = LifeSpan <= 9.5f ? RotatePoint(parent.Origin, _totalSeconds, parent.Position): Position + Direction * LinearVelocity;
            }


        }


    }
}
