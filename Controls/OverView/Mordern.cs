using System;
using System.Drawing;
using System.Windows.Forms;
using DesignFrame.Controls.OverView;
namespace DesignFrame
{
    public partial class frmMordern : Form
    {

        public frmMordern()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None; // Remove border for custom shadow
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.UserPaint |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.ResizeRedraw, true);
            // Chỉ bật cuộn dọc, tắt cuộn ngang
            tlpIndex.AutoScroll = true;
            tlpIndex.HorizontalScroll.Enabled = false;
            tlpIndex.HorizontalScroll.Visible = false;
            this.Cursor = createCurso();

        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
        private Cursor createCurso()
        {
            Bitmap bitmap = null;
            if (pnAvatar != null && pnAvatar.BackgroundImage != null)
            {
                // Ensure pnAvatar.BackgroundImage is a Bitmap
                bitmap = new Bitmap(pnAvatar.BackgroundImage);
            }

            if (bitmap == null)
            {
                throw new ArgumentNullException("Bitmap cannot be null.");
            }

            // Optionally resize to standard cursor size (32x32)
            Bitmap resizedBitmap = new Bitmap(bitmap, new Size(32, 32));

            // Make transparent (adjust the transparency color as needed)
            resizedBitmap.MakeTransparent(Color.White); // Example: Make white color transparent

            // Create cursor from the bitmap's icon handle
            return new Cursor(resizedBitmap.GetHicon());
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
