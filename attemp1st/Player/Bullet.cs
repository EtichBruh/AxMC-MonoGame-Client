using attemp1st.GraphicsLogic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace attemp1st.player
{
    public class Bullet : SpriteAtlas
    {
        public float LifeSpan = 5f;

        public float rotationVelocity = 3f;
        public float linearVelocity = 4f;


        public Bullet(Texture2D _texture)
            : base(_texture, 1, 1, 0)
        {
            Size = 6;
        }

        public override void Update(GameTime gameTime, Camera camera, List<SpriteAtlas> sprites)
        {

            LifeSpan -= (float)gameTime.ElapsedGameTime.TotalSeconds;


            if (LifeSpan <= 0)
                isRemoved = true;
            else {                 
                //Rotation += rotationVelocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
                Position += Direction * linearVelocity; }


        }


    }
}
