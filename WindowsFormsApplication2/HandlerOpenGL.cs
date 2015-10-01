using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

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
        private float angle = new float();
        private float R = new float();
        private Matrix4 modelview;
        private float[] mouseSpeed = new float[2];
        private float oldX = new float();
        private float oldY = new float();

        private HandlerOpenGL() {
            init();
        }

        public static HandlerOpenGL Instance {
            get {
                return instance;
            }
        }

        private float countTargetX() {
            return (float)Math.Sin(this.angle) + this.eyeX;
        }

        private float countTargetZ() {
            return (float)Math.Cos(this.angle) + this.eyeZ;
        }

        private void init()
        {
            this.angle = 0.79f;
            this.R = 20;
            this.eyeX = -1;
            this.eyeY = 20;
            this.eyeZ = -1;
            this.targetX = this.countTargetX();
            this.targetY = 20;
            this.targetZ = this.countTargetZ();
            this.oldX = Mouse.GetCursorState().X;
            this.oldY = Mouse.GetCursorState().Y;

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
            modelview = Matrix4.LookAt(this.eyeX, this.eyeY, this.eyeZ,
                                                this.targetX, this.targetY, this.targetZ,
                                                 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref modelview);
        }

        public void MoveForward(int mode)
        {
            float oldX = this.eyeX;
            float oldZ = this.eyeZ;
            this.eyeX += mode * (float)Math.Sin(this.angle);
            this.eyeZ += mode * (float)Math.Cos(this.angle);
            this.targetX += (this.eyeX - oldX);
            this.targetZ += (this.eyeZ - oldZ);
            System.Console.Write("forward => " + this.targetX + " " + this.targetZ + "\n");
            this.ChangeCam();
        }

        public void MoveSideways(int mode)
        {
            this.angle += mode*0.05f;
            this.targetX = this.countTargetX();
            this.targetZ = this.countTargetZ();
            System.Console.Write("sideways => " + this.targetX + " " + this.targetZ + "\n");
            this.ChangeCam();
        }
    }
}
