using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics;

namespace WindowsFormsApplication2
{
    class Shape
    {
        protected HandlerOpenGL hOpenGl = HandlerOpenGL.Instance;
        private const int MODE_POLYGON = 1;
        protected int[][] arrCoord;
        protected Color color;

        public Shape() { }

        public Shape(int mode, int[][] arrCoord, Color color)
        {
            if (init(arrCoord, color) == true)
            {
                getInstance(mode);
            }
        }

        protected bool init(int[][] arrCoord, Color color)
        {
            if (this.hOpenGl.loaded == true)
            {
                this.arrCoord = arrCoord;
                this.color = color;
            }
            return this.hOpenGl.loaded;
        }

        private Shape getInstance(int mode) {
            switch (mode)
            {
                case MODE_POLYGON:
                    return new Polygon(this.arrCoord, this.color);
                    break;
                default:
                    return new Shape();
                    break;             
            }
        }

        public void Draw() { }
    }

    class Polygon : Shape
    {

        public Polygon(int[][] arrCoord, Color color)
        {
            init(arrCoord, color);
        }

        public void Draw(Texture Txtr = null)
        {
            float[][] textCoord = new float[4][];
            if (Txtr != null) {
                for (int i = 0; i < 4; i++) {
                    textCoord[i] = new float[3];
                    for (int j = 0; j < 3; j++) {
                        textCoord[i][j] = 0.0f;
                    }
                }

                textCoord[0][2] = 1.0f;
                textCoord[1][0] = 1.0f;
                textCoord[1][2] = 1.0f;
                textCoord[2][0] = 1.0f;
                GL.BindTexture(TextureTarget.Texture3D, Txtr.GetTexture);
            }
            
            GL.Color3(this.color);
            GL.Begin(BeginMode.Polygon);
            int count = 0;
            foreach (int[] coord in this.arrCoord) {
                if (Txtr != null) GL.TexCoord3(textCoord[count][0], textCoord[count][1], textCoord[count][2]);
                GL.Vertex3(coord[0], coord[1], coord[2]);
                count++;
            }
            GL.End();
        }
    }
}
