using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace attemp1st.GraphicsLogic
{
    public class Camera
    {
        public Matrix Transform { get; set; }
        public Viewport View { get; set; }
        public float RotationDegrees = 0;
        public float Zoom = 1f;

        private float Zoom_ { get { return Zoom = Zoom >= 0.1f ? Zoom : Zoom = 0.1f; } }


        public void Follow(SpriteAtlas target)
        {   //var offset = Matrix.CreateTranslation(new Vector3(WindowCenter.X, WindowCenter.Y, 0));
            Transform = Matrix.CreateTranslation(-target.Position.X, -target.Position.Y, 0)
            * Matrix.CreateScale(Zoom_, Zoom_, 1)
            * Matrix.CreateRotationZ(RotationDegrees)
            * Matrix.CreateTranslation(View.Width * 0.5f, View.Height * 0.5f, 0);
        }
    }
}
