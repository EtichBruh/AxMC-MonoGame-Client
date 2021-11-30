using Microsoft.Xna.Framework;

namespace attemp1st.GraphicsLogic
{
    public class Camera
    {
        public Matrix Transform { get; private set; }
        public float RotationDegrees = 0;
        public float Zoom = 1f;

        private float Zoom_ { get { return Zoom = Zoom >= 0.1f ? Zoom : Zoom = 0.1f; } }


        public void Follow(SpriteAtlas target)
        {
            var WindowCenter = Game1.WindowCenter;
            var position = Matrix.CreateTranslation(new Vector3(-target.Position.X, -target.Position.Y, 0))
                * Matrix.CreateRotationZ(RotationDegrees)
                * Matrix.CreateScale(Zoom_);
            var offset = Matrix.CreateTranslation(new Vector3(WindowCenter.X, WindowCenter.Y, 0));

            Transform = position * offset;
        }
    }
}
