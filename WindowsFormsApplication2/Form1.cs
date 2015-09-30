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

        public Form1()
        {
            InitializeComponent();
        }

        private void glControl1_Load(object sender, EventArgs e)
        {
            hOpenGL = HandlerOpenGL.Instance;
        }

        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            System.Console.Write("Paint\n");
            int[][] arrCoord = new int[4][];
            Color color = Color.Gray;
            int width = 50;

            Bitmap bitmap = new Bitmap(@"D:\Проекты\WindowsFormsApplication2\WindowsFormsApplication2\img\pol.jpg");
            Texture Txtr = new Texture(bitmap);
            

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

            glControl1.SwapBuffers();
        }

        private void glControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "A")
            {
                hOpenGL.MoveLeft();
            }
            else if (e.KeyCode.ToString() == "D")
            { 
                hOpenGL.MoveRight();
            }
            glControl1.Invalidate();
        }
    }
}
