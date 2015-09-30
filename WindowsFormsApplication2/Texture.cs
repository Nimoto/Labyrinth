using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace WindowsFormsApplication2
{
    class Texture
    {
        Bitmap bitmap;
        int texture;
        public int GetTexture {
            get {
                return texture;
            }
        }

        public Texture(Bitmap bitmap) {
            this.bitmap = bitmap;
            this.OnLoad();
        }

        protected void OnLoad()
        {
            GL.Enable(EnableCap.Texture3DExt);

            GL.Hint(HintTarget.PerspectiveCorrectionHint, HintMode.Nicest);

            GL.GenTextures(1, out texture);
            GL.BindTexture(TextureTarget.Texture3D, texture);
            GL.TexParameter(TextureTarget.Texture3D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture3D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);

            BitmapData data = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height),
                ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            GL.TexImage3D(TextureTarget.Texture3D, 0, PixelInternalFormat.Rgba, data.Width, 1, data.Height, 0,
                OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);

            bitmap.UnlockBits(data);
        }

        protected void OnUnload(EventArgs e)
        {
            GL.DeleteTextures(1, ref texture);
        }

        protected void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, this.bitmap.Width, this.bitmap.Height);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-1.0, 1.0, -1.0, 1.0, 0.0, 4.0);
        }

    }
}
