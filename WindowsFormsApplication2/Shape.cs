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

        public void Draw()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Color3(this.color);
            GL.Begin(BeginMode.Polygon);
            foreach (int[] coord in this.arrCoord) {
                GL.Vertex3(coord[0], coord[1], coord[2]);
            }
            GL.End();
        }
    }
}
