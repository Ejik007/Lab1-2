using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

namespace _DCubeNoGimbalLock
{
    public partial class frmDirectX : Form
    {
        Device device;
        Mesh mesh1, mesh2, mesh3, mesh4, mesh5, mesh6;

        public float angle { get; set; }

        public frmDirectX()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.Opaque, true);

            var presentParameters = new PresentParameters()
            {
                Windowed = true,
                SwapEffect = SwapEffect.Discard,
                AutoDepthStencilFormat = DepthFormat.D16,
                EnableAutoDepthStencil = true
            };

            device = new Device(0, DeviceType.Hardware, Handle,
                CreateFlags.HardwareVertexProcessing, presentParameters);

            mesh1 = Mesh.Box(device, 2.0f, 2.0f, 2.0f); // куб
            mesh2 = Mesh.Cylinder(device, 2.0f, 2.0f, 2.0f, 36, 36); // цилиндр
            mesh3 = Mesh.Polygon(device, 2.0f, 8); // полигон, 8 - число сторон полигона
            mesh4 = Mesh.Sphere(device, 2.0f, 36, 36); // сфера
            mesh5 = Mesh.Torus(device, 0.5f, 2.0f, 36, 80); // тор ("бублик")
            mesh6 = Mesh.Teapot(device); // заварочный чайник
        }

        private void SetupCamera()
        {
            device.Transform.Projection = Matrix.PerspectiveFovLH(
                (float)Math.PI / 4, this.Width / this.Height, 1.0f, 100.0f);
            device.Transform.View = Matrix.LookAtLH(
                new Vector3(0, 0, 20.0f), new Vector3(), new Vector3(0, 1, 0));
            device.Transform.World = Matrix.RotationYawPitchRoll(
                angle / (float)Math.PI, angle / (float)Math.PI * 2.0f, angle / (float)Math.PI);
            angle += 0.03f;
            device.RenderState.Ambient = Color.DarkBlue;
            device.Lights[0].Type = LightType.Directional;
            device.Lights[0].Diffuse = Color.DarkBlue;
            device.Lights[0].Direction = new Vector3(0, -1, -1);
            device.Lights[0].Enabled = true;
            Material boxMaterial = new Material();
            boxMaterial.Ambient = Color.White;
            boxMaterial.Diffuse = Color.White;
            device.Material = boxMaterial;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            device.Clear(ClearFlags.Target | ClearFlags.ZBuffer, Color.Black, 1.0f, 0);
            SetupCamera();
            device.BeginScene();
            device.RenderState.CullMode = Cull.None;
            mesh1.DrawSubset(0);
            device.Transform.World = Matrix.RotationYawPitchRoll(
                angle / (float)Math.PI, angle / (float)Math.PI / 2.0f, angle /
                (float)Math.PI * 4.0f) * Matrix.Translation(5.0f, 0.0f, 0.0f);
            mesh2.DrawSubset(0);
            device.Transform.World = Matrix.RotationYawPitchRoll(
                angle / (float)Math.PI, angle / (float)Math.PI * 4.0f, angle /
                (float)Math.PI / 2.0f) * Matrix.Translation(-5.0f, 0.0f, 0.0f);
            mesh3.DrawSubset(0);
            device.Transform.World = Matrix.RotationYawPitchRoll(
                angle / (float)Math.PI, angle / (float)Math.PI / 2.0f, angle /
                (float)Math.PI * 4.0f) * Matrix.Translation(5.0f, 5.0f, 0.0f);
            mesh4.DrawSubset(0);
            device.Transform.World = Matrix.RotationYawPitchRoll(
                angle / (float)Math.PI, angle / (float)Math.PI * 2.0f, angle /
                (float)Math.PI * 4.0f) * Matrix.Translation(-5.0f, 5.0f, 0.0f);
            mesh5.DrawSubset(0);
            device.Transform.World = Matrix.RotationYawPitchRoll(
                angle / (float)Math.PI, angle / (float)Math.PI / 2.0f, angle /
                (float)Math.PI * 4.0f) * Matrix.Translation(-5.0f, -5.0f, 0.0f);
            mesh6.DrawSubset(0);
            device.Transform.World = Matrix.RotationYawPitchRoll(
                angle / (float)Math.PI, angle / (float)Math.PI * 2.0f, angle /
                (float)Math.PI * 4.0f) * Matrix.Translation(5.0f, -5.0f, 0.0f);
            mesh1.DrawSubset(0);
            device.Transform.World = Matrix.RotationYawPitchRoll(
                angle / (float)Math.PI, angle / (float)Math.PI / 2.0f, angle /
                (float)Math.PI * 4.0f) * Matrix.Translation(0.0f, 5.0f, 0.0f);
            mesh3.DrawSubset(0);
            device.Transform.World = Matrix.RotationYawPitchRoll(
                angle / (float)Math.PI, angle / (float)Math.PI * 2.0f, angle /
                (float)Math.PI * 4.0f) * Matrix.Translation(0.0f, -5.0f, 0.0f);
            mesh5.DrawSubset(0);
            device.EndScene();
            device.Present();
            Invalidate();
        }
    }
}