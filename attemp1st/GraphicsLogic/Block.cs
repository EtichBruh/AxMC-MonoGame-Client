using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace attemp1st.GraphicsLogic
{
    public class Block
    {
        private readonly VertexPositionColor[] _triangleVertices = new VertexPositionColor[8];
        public VertexBuffer VertexBuffer;
        public IndexBuffer IndexBuffer;

        private readonly ushort[] _triangleIndices =
            {
                0,1,2, // Front side
                2,3,0,

                6,5,4, // Back side
                4,7,6,

                4,0,3, // Left Side
                3,7,4,

                1,5,6, // Rigth side
                6,2,1,

                4,5,1, // Up
                1,0,4,

                3,2,6, // Down
                6,7,3,
            };
        public BasicEffect BasiceCubeEff;
        public void BlockInit(GraphicsDevice gd)
        {
            const float i = 0.5f;
            _triangleVertices[0] = new VertexPositionColor(new Vector3(i, -i, -i), Color.Red);
            _triangleVertices[1] = new(new(-i,-i,-i), Color.Green);
            _triangleVertices[2] = new(new(-i, i, -i), Color.Yellow);
            _triangleVertices[3] = new(new(i,i,-i), Color.Blue);

            _triangleVertices[4] = new(-_triangleVertices[2].Position, Color.Red);
            _triangleVertices[5] = new(-_triangleVertices[3].Position, Color.Green);
            _triangleVertices[6] = new(-_triangleVertices[0].Position, Color.Yellow);
            _triangleVertices[7] = new(-_triangleVertices[1].Position, Color.Blue);

            VertexBuffer = new(gd, typeof(VertexPositionColor),_triangleVertices.Length, BufferUsage.None);
            VertexBuffer.SetData(_triangleVertices);

            BasiceCubeEff = new(gd){VertexColorEnabled = true};

            IndexBuffer = new IndexBuffer(gd, typeof(ushort), _triangleIndices.Length, BufferUsage.WriteOnly);// init buffer of indexes
            IndexBuffer.SetData(_triangleIndices);
        }
    }
}