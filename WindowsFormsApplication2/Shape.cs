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

       /* private int[][][] CreateArrCoord() {
            int[][][] arrCoordFull;
            int[] param = new int[3];
            int width = System.Math.Abs(arrCoord[0][0] - arrCoord[1][0]);
            int height = System.Math.Abs(arrCoord[0][1] - arrCoord[1][1]);
            int lenght = System.Math.Abs(arrCoord[0][2] - arrCoord[1][2]);
            param[0] = (width)/20;
            param[1] = (height)/20;
            param[2] = (lenght)/20;
            int w = 0, h = 0;
            if (param[0] != 0 && param[1] != 0)
            {
                w = width;
                h = height;
            }
            else if (param[1] != 0 && param[2] != 0)
            {
                w = height;
                h = lenght;
            }
            else if (param[0] != 0 && param[2] != 0)
            {
                w = width;
                h = lenght;
            }

            int count = 1;

            foreach (int parametr in param.Where(p => p > 0)) {
                count = count * parametr;
            }

            arrCoordFull = new int[w][][];

            for (int i = 0; i < w; i++)
            {
                arrCoordFull[i] = new int[h][];
                for (int j = 0; j < h; j++)
                {
                    arrCoordFull[i][j] = new int[3];
                    if (param[0] != 0 && param[1] != 0)
                    {
                        arrCoordFull
                    }
                    else if (param[1] != 0 && param[2] != 0)
                    {
                    }
                    else if (param[0] != 0 && param[2] != 0)
                    {
                    }
                }
            }

            return arrCoordFull;
        }*/

        public void Draw()
        {
            int block_w = 20;
            float[][] textCoord = new float[4][];
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


            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Color3(this.color);
            GL.Begin(BeginMode.Polygon);
            int count = 0;
            foreach (int[] coord in this.arrCoord) {
                GL.TexCoord3(textCoord[count][0], textCoord[count][1], textCoord[count][2]);
                GL.Vertex3(coord[0], coord[1], coord[2]);
                count++;
            }
            GL.End();
        }
    }
}
