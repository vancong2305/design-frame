using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DesignFrame.Controls.OverView
{
    public class ShadowButton : Panel
    {
        private int shadowSize = 10;
        private Color shadowColor = Color.FromArgb(0, 0, 0, 100); // Mặc định màu bóng mờ là xám đen với độ mờ 100

        [Browsable(true)]
        [Category("Appearance")]
        [Description("Color of the shadow.")]
        public Color ShadowColor
        {
            get { return shadowColor; }
            set
            {
                shadowColor = value;
                Invalidate(); // Yêu cầu vẽ lại khi màu bóng mờ thay đổi
            }
        }

        public ShadowButton()
        {
            this.BackColor = Color.Transparent;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.UserPaint |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.ResizeRedraw, true);

            // Đặt kích thước tối thiểu là 30x30
            this.MinimumSize = new Size(30, 30);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawShadow(e.Graphics);
        }

        private void DrawShadow(Graphics g)
        {
            // Vẽ nhiều lớp bóng mờ với độ mờ giảm dần cho hiệu ứng phai
            for (int i = 0; i < shadowSize; i++)
            {
                // Tính toán alpha và màu dựa trên khoảng cách từ trung tâm
                int alpha = 150 - (i * 5); // Bắt đầu với alpha cao và giảm dần
                if (alpha < 0) alpha = 0; // Đảm bảo alpha không giảm dưới 0

                // Bóng mờ bên trái
                using (LinearGradientBrush leftBrush = new LinearGradientBrush(
                    new Rectangle(-shadowSize + i, i, shadowSize, this.Height - 2 * i),
                    Color.FromArgb(alpha, 255, 0, 0), // Color with varying alpha
                    Color.FromArgb(0, 0, 0, 15), // Transparent
                    LinearGradientMode.Horizontal))
                {
                    g.FillRectangle(leftBrush, new Rectangle(-shadowSize + i, i, shadowSize, this.Height - 2 * i));
                }
                // Bóng mờ trên
                using (LinearGradientBrush topBrush = new LinearGradientBrush(
                    new Rectangle(i, -shadowSize + i, this.Width - 2 * i, shadowSize),
                    Color.FromArgb(alpha, 0, 0, 0), // Color with varying alpha
                    Color.FromArgb(0, 0, 0, 15), // Transparent
                    LinearGradientMode.Vertical))
                {
                    g.FillRectangle(topBrush, new Rectangle(i, -shadowSize + i, this.Width - 2 * i, shadowSize));
                }

                using (LinearGradientBrush rightBrush = new LinearGradientBrush(
                    new Rectangle(this.Width - i, i, shadowSize, this.Height - (2 * i)),
                    Color.FromArgb(0, 0, 0, 255), // Transparent
                    Color.FromArgb(alpha, 255, 0, 15), // Color with varying alpha
                    LinearGradientMode.Horizontal))
                {
                    // Bóng mờ bên phải
                    g.FillRectangle(rightBrush, new Rectangle(this.Width - i, i, shadowSize, this.Height - (2 * i)));
                }

                using (LinearGradientBrush bottomBrush = new LinearGradientBrush(
                    new Rectangle(i, this.Height - i, this.Width - (2 * i), shadowSize),
                    Color.FromArgb(0, 0, 0, 255), // Transparent
                    Color.FromArgb(alpha, 0, 0, 15), // Color with varying alpha
                    LinearGradientMode.Vertical))
                {
                    // Bóng mờ dưới
                    g.FillRectangle(bottomBrush, new Rectangle(i, this.Height - i, this.Width - (2 * i), shadowSize));
                }
            }
        }
    }
}
