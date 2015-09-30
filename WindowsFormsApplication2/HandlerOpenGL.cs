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
        private float eyeX = new float();
        private float eyeY = new float();
        private float eyeZ = new float();
        private float targetX = new float();
        private float targetY = new float();
        private float targetZ = new float();

        private HandlerOpenGL() {
            init();
        }

        public static HandlerOpenGL Instance {
            get {
                return instance;
            }
        }

        private void init()
        {
            this.eyeX = -1;
            this.eyeY = 30;
            this.eyeZ = -1;
            this.targetX = 20;
            this.targetY = 0;
            this.targetZ = 20;
            this.loaded = true;
            GL.ClearColor(Color.Black);
            GL.Enable(EnableCap.Texture3DExt);
            GL.Hint(HintTarget.PerspectiveCorrectionHint, HintMode.Nicest);

            Matrix4 p = Matrix4.CreatePerspectiveFieldOfView((float)(80 * Math.PI / 180), 1, 1, 500);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref p);
            this.ChangeCam();
        }

        private void ChangeCam()
        {
            System.Console.Write(this.eyeX+"\n");
            Matrix4 modelview = Matrix4.LookAt(this.eyeX, this.eyeY, this.eyeZ,
                                                this.targetX, this.targetY, this.targetZ,
                                                 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref modelview);
        }

        public void MoveLeft()
        {
            this.eyeX -= 1f;
            this.ChangeCam();
        }

        public void MoveRight()
        {
            this.eyeX += 1f;
            this.ChangeCam();
        }
    }
}
