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
            Bitmap bitmap = new Bitmap(@"D:\Проекты\WindowsFormsApplication2\WindowsFormsApplication2\img\pol.jpg");
            if (Txtr == null) Txtr = new Texture(bitmap);
            Mapper map = new Mapper();
            Labyrinth lab = new Labyrinth(map.PolygonCreated());
            lab.DrawLabyrinth(Txtr);
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
            //hOpenGL.LookAround(e.X, e.Y);
            //this.MyPaint();
        }
    }
}
