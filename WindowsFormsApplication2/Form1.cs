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
        //bool loaded = false;
        HandlerOpenGL hOpenGL;

        public Form1()
        {
            InitializeComponent();
        }

        private void glControl1_Load(object sender, EventArgs e)
        {
            /*loaded = true;
            System.Console.Write("Init\n");
            GL.ClearColor(Color.Black);
            GL.Enable(EnableCap.DepthTest);

            Matrix4 p = Matrix4.CreatePerspectiveFieldOfView((float)(80 * Math.PI / 180), 1, 20, 500);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref p);

            Matrix4 modelview = Matrix4.LookAt(70, 70, 70, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref modelview);*/
            hOpenGL = HandlerOpenGL.Instance;
        }

        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            System.Console.Write("Paint\n");
            int[][] arrCoord = new int[4][];
            Color color = Color.Gray;
            int width = 200;

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
            polygon.Draw();


            /*if (!loaded)
                return;            

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Color3(Color.Gray);

            float width = 200;
            
            GL.Begin(BeginMode.Polygon);
            GL.Vertex3(0, 0, 0);
            GL.Vertex3(0, 0, width);
            GL.Vertex3(width, 0, width);
            GL.Vertex3(width, 0, 0);
            GL.End();*/



            glControl1.SwapBuffers();
        }
    }
}
