using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace WindowsFormsApplication2
{
    class HandlerOpenGL
    {
        public bool loaded = false;
        private readonly static HandlerOpenGL instance = new HandlerOpenGL();

        private HandlerOpenGL() {
            init();
        }

        public static HandlerOpenGL Instance {
            get {
                return instance;
            }
        }

        private void init() { 
            this.loaded = true;
            GL.ClearColor(Color.Black);
            GL.Enable(EnableCap.DepthTest);

            Matrix4 p = Matrix4.CreatePerspectiveFieldOfView((float)(10 * Math.PI / 180), 1, 10, 500);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref p);

            Matrix4 modelview = Matrix4.LookAt(20, 10, 20, 200, 0, 200, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref modelview);
        }
    }
}
