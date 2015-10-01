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
        private float oldMouseX = new float();
        private float oldMouseY = new float();

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
            this.eyeX = 250;
            this.eyeY = 20;
            this.eyeZ = 250;
            this.targetX = this.countTargetX();
            this.targetY = 20;
            this.targetZ = this.countTargetZ();
            this.oldX = Mouse.GetCursorState().X;
            this.oldY = Mouse.GetCursorState().Y;
            this.oldMouseX = Mouse.GetCursorState().X;
            this.oldMouseY = Mouse.GetCursorState().Y;
            
            GL.Enable(EnableCap.DepthTest);
            GL.DepthRange(0.1f, 1.0f);
            GL.DepthMask(true);

            Vector4 LightAmbient = new Vector4(0.1f, 0.1f, 0.1f, 1.0f);
            Vector4 LightDiffuse = new Vector4(1.0f, 1.0f, 1.0f, 1.0f);
            Vector4 LightPosition = new Vector4(0.0f, 0.0f, 5.0f, 1.0f);


            GL.Enable(EnableCap.Fog);
            float[] color = { 0f, 0f, 0f, 1.0f };
            GL.Fog(FogParameter.FogMode, 1);
            GL.Fog(FogParameter.FogColor, color);
            GL.Fog(FogParameter.FogDensity, 0.03f);
            GL.Hint(HintTarget.FogHint, HintMode.Nicest);
            GL.Fog(FogParameter.FogStart, 1.0f);
            GL.Fog(FogParameter.FogEnd, 10.0f);

            // GL.Light(LightName.Light0, LightParameter.Ambient, LightAmbient);
            //GL.Light(LightName.Light1, LightParameter.Diffuse, LightDiffuse);
            //GL.Light(LightName.Light1, LightParameter.Position, LightPosition);
            //GL.Enable(EnableCap.Lighting);
            //GL.Enable(EnableCap.Light1);

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
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
        }

        public void MoveForward(int mode)
        {
            float oldX = this.eyeX;
            float oldZ = this.eyeZ;
            this.eyeX += mode * (float)Math.Sin(this.angle);
            this.eyeZ += mode * (float)Math.Cos(this.angle);
            this.targetX += (this.eyeX - oldX);
            //this.targetY = 20;
            this.targetZ += (this.eyeZ - oldZ);
            this.ChangeCam();
        }

        public void MoveSideways(int mode)
        {
            this.angle += mode*0.05f;
            this.targetX = this.countTargetX();
            //this.targetY = 20;
            this.targetZ = this.countTargetZ();
            this.ChangeCam();
        }

        public void LookAround(int X, int Y) {
            float deltaX = new float();
            float deltaY = new float();
            int modeX = 0, modeY;
            deltaX = (float)X - this.oldMouseX;
            deltaY = (float)Y - this.oldMouseY;
            if (Math.Abs(deltaY) > 10) {
                modeY = (int)Math.Round(deltaY / Math.Abs(deltaY));
                this.targetY -= modeY * 0.05f;
                this.oldMouseY = Y;
            }
            if (Math.Abs(deltaX) > 10) {
                this.oldMouseX = X;
                modeX = (int)Math.Round(deltaX / Math.Abs(deltaX));
            }
            this.MoveSideways(modeX);
        }
    }
}
