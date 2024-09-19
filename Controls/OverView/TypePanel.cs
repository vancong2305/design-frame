using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DesignFrame.Controls.OverView
{
    public class TypePanel : Panel
    {
        private int shadowSize = 30;

        public TypePanel()
        {
            this.BackColor = Color.Transparent;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawShadow(e.Graphics);
        }

        private void DrawShadow(Graphics g)
        {
            // Define the color and size of the shadow
            Color shadowColor = Color.Black;
            int depth = shadowSize;

            // Draw gradient shadow for all four sides

            // Top shadow
            using (LinearGradientBrush brush = new LinearGradientBrush(
                new Rectangle(0, 0, this.Width, depth),
                Color.FromArgb(0, shadowColor),  // Transparent color
                Color.FromArgb(180, shadowColor), // Opaque color
                LinearGradientMode.Vertical))
            {
                g.FillRectangle(brush, new Rectangle(0, 0, this.Width, depth));
            }

            // Bottom shadow
            using (LinearGradientBrush brush = new LinearGradientBrush(
                new Rectangle(0, this.Height - depth, this.Width, depth),
                Color.FromArgb(180, shadowColor), // Opaque color
                Color.FromArgb(0, shadowColor),  // Transparent color
                LinearGradientMode.Vertical))
            {
                g.FillRectangle(brush, new Rectangle(0, this.Height - depth, this.Width, depth));
            }

            // Left shadow
            using (LinearGradientBrush brush = new LinearGradientBrush(
                new Rectangle(0, 0, depth, this.Height),
                Color.FromArgb(0, shadowColor),  // Transparent color
                Color.FromArgb(180, shadowColor), // Opaque color
                LinearGradientMode.Horizontal))
            {
                g.FillRectangle(brush, new Rectangle(0, 0, depth, this.Height));
            }

            // Right shadow
            using (LinearGradientBrush brush = new LinearGradientBrush(
                new Rectangle(this.Width - depth, 0, depth, this.Height),
                Color.FromArgb(180, shadowColor), // Opaque color
                Color.FromArgb(0, shadowColor),  // Transparent color
                LinearGradientMode.Horizontal))
            {
                g.FillRectangle(brush, new Rectangle(this.Width - depth, 0, depth, this.Height));
            }
        }
    }
}
