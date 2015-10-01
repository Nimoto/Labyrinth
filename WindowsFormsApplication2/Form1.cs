using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        HandlerOpenGL hOpenGL;
        Texture Txtr;

        public Form1()
        {
            InitializeComponent();
        }

        private void glControl1_Load(object sender, EventArgs e)
        {
            hOpenGL = HandlerOpenGL.Instance;
        }

        private void MyPaint() {

            System.Console.Write("Paint\n");
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            int[][] arrCoord = new int[4][];
            Color color = Color.Gray;
            int width = 50;

            Bitmap bitmap = new Bitmap(@"D:\Проекты\WindowsFormsApplication2\WindowsFormsApplication2\img\pol.jpg");
            if (Txtr == null) Txtr = new Texture(bitmap);


            arrCoord[0] = new int[3];
            arrCoord[0][0] = 0;
            arrCoord[0][1] = 0;
            arrCoord[0][2] = 0;

            arrCoord[1] = new int[3];
            arrCoord[1][0] = 0;
            arrCoord[1][1] = 0;
            arrCoord[1][2] = width;

            arrCoord[2] = new int[3];
            arrCoord[2][0] = width;
            arrCoord[2][1] = 0;
            arrCoord[2][2] = width;

            arrCoord[3] = new int[3];
            arrCoord[3][0] = width;
            arrCoord[3][1] = 0;
            arrCoord[3][2] = 0;

            Polygon polygon = new Polygon(arrCoord, color);
            polygon.Draw(Txtr);

            double subwidth = Math.Round(width / 2.0);

            arrCoord[0][0] = (int)subwidth;
            arrCoord[0][1] = (int)subwidth;
            arrCoord[0][2] = (int)subwidth;

            arrCoord[1][0] = (int)subwidth;
            arrCoord[1][1] = 0;
            arrCoord[1][2] = (int)subwidth;

            arrCoord[2][0] = (int)subwidth;
            arrCoord[2][1] = 0;
            arrCoord[2][2] = width;

            arrCoord[3][0] = (int)subwidth;
            arrCoord[3][1] = (int)subwidth;
            arrCoord[3][2] = width;

            Polygon polygon2 = new Polygon(arrCoord, color);
            polygon2.Draw(Txtr);

            glControl1.SwapBuffers();
        }

        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            this.MyPaint();
        }

        private void glControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "W")
            {
                hOpenGL.MoveForward(1);
            }
            else if (e.KeyCode.ToString() == "S")
            {
                hOpenGL.MoveForward(-1);
            }
            else if (e.KeyCode.ToString() == "A")
            {
                hOpenGL.MoveSideways(1);
            }
            else if (e.KeyCode.ToString() == "D")
            {
                hOpenGL.MoveSideways(-1);
            }
            glControl1.Invalidate();
        }

        private void glControl1_MouseMove(object sender, MouseEventArgs e)
        {
            hOpenGL.LookAround(e.X, e.Y);
            this.MyPaint();
        }
    }
}
