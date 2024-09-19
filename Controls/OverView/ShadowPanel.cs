using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DesignFrame.Controls.OverView
{
    public class ShadowPanel : Panel
    {
        private int shadowSize = 25;

        public ShadowPanel()
        {
            this.BackColor = Color.Transparent;
            // Bật Double Buffering
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.UserPaint |
                          ControlStyles.AllPaintingInWmPaint |
                          ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.ResizeRedraw, true);
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
                int alpha = 110 - (i * 5); // Bắt đầu với alpha cao và giảm dần
                if (alpha < 0) alpha = 0; // Đảm bảo alpha không giảm dưới 0

                // Bóng mờ bên trái
                using (LinearGradientBrush leftBrush = new LinearGradientBrush(
                    new Rectangle(-shadowSize + i, i, shadowSize, this.Height - 2 * i),
                    Color.FromArgb(alpha, 0, 0, 0), // Color with varying alpha
                    Color.FromArgb(0, 0, 0, 15), // Transparent
                    LinearGradientMode.Horizontal))
                {
                    g.FillRectangle(leftBrush, new Rectangle(-shadowSize + i + 5, i, shadowSize, this.Height - 2 * i));
                }
                // Bóng mờ trên
                using (LinearGradientBrush topBrush = new LinearGradientBrush(
                    new Rectangle(i, -shadowSize + i, this.Width - 2 * i, shadowSize),
                    Color.FromArgb(alpha, 0, 0, 0), // Color with varying alpha
                    Color.FromArgb(0, 0, 0, 15), // Transparent
                    LinearGradientMode.Vertical))
                {
                    g.FillRectangle(topBrush, new Rectangle(i, -shadowSize + i + 5, this.Width - 2 * i, shadowSize));
                }

                using (LinearGradientBrush rightBrush = new LinearGradientBrush(
                    new Rectangle(this.Width - i, i, shadowSize, this.Height - (2 * i)),
                    Color.FromArgb(0, 0, 0, 255), // Transparent
                    Color.FromArgb(alpha, 0, 0, 15), // Color with varying alpha
                    LinearGradientMode.Horizontal))
                {
                    // Bóng mờ bên phải
                    g.FillRectangle(rightBrush, new Rectangle(this.Width - i - 5, i, shadowSize, this.Height - (2 * i)));
                }

                using (LinearGradientBrush bottomBrush = new LinearGradientBrush(
                    new Rectangle(i, this.Height - i, this.Width - (2 * i), shadowSize),
                    Color.FromArgb(0, 0, 0, 255), // Transparent
                    Color.FromArgb(alpha, 0, 0, 15), // Color with varying alpha
                    LinearGradientMode.Vertical))
                {
                    // Bóng mờ dưới
                    g.FillRectangle(bottomBrush, new Rectangle(i, this.Height - i - 5, this.Width - (2 * i), shadowSize));
                }
            }
        }
    }
}
