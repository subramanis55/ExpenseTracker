
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace ExpenseTracker
{
    class Points
    {
        public int EllipseRadius = 0;
        public int EllipseX;
        public int EllipseY;
        public int Alpha = 100;

    }
    public class CustomButton : Button
    {
        Timer animationTimer;
        private int BorderSize = 0;
        private int BorderRadius = 40;
        private Color borderColor = Color.PaleVioletRed;
        List<Points> points_List = new List<Points>();
        List<Timer> timer_List = new List<Timer>();
        private Color ellipseColor = ColorTranslator.FromHtml("#96EFFF");
        private int slowMotionInterval = 5;
        [DefaultValue("Custem properties")]
        public Color EllipseColor
        {
            get
            {
                return ellipseColor;
            }
            set
            {
                ellipseColor = value;
            }
        }
        public int SlowMotionInterval
        {
            get
            {
                return slowMotionInterval;
            }
            set
            {
                if (value > 50)
                {
                    slowMotionInterval = 50;
                }
                else
                    slowMotionInterval = value;
            }
        }
        [Category("Custem Button Properties")]
        public int BorderSize1
        {
            get
            {
                return BorderSize;
            }

            set
            {
                BorderSize = value;
                this.Invalidate();
            }
        }
        [Category("Custem Button Properties")]
        public int BorderRadius1
        {
            get
            {
                return BorderRadius;
            }

            set
            {
                if (value <= this.Height)
                    BorderRadius = value;
                else
                    BorderRadius = this.Height;
                this.Invalidate();
            }
        }
        [Category("Custem Button Properties")]
        public Color BorderColor
        {
            get
            {
                return borderColor;
            }

            set
            {
                borderColor = value;
                this.Invalidate();
            }
        }
        [Category("Custem Button Properties")]
        public Color BackgroudColor
        {
            get { return this.BackColor; }
            set { this.BackColor = value; this.Invalidate(); }
        }
        [Category("Custem Button Properties")]
        public Color TextColor
        {
            get { return this.ForeColor; }
            set { this.ForeColor = value; this.Invalidate(); }
        }

        public CustomButton()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.Size = new Size(150, 40);
            this.BackColor = Color.MediumSlateBlue;
            this.ForeColor = Color.White;
            this.Resize += new EventHandler(Button_Resize);
            Paint += OnPaint;
            MouseClick += OnMouseClick;
        }

        private void Button_Resize(object sender, EventArgs e)
        {
            if (BorderRadius > this.Height)
            {
                BorderRadius1 = this.Height;
            }

        }

        public GraphicsPath GetFigurePath(RectangleF rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Width - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Width - radius, rect.Height - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();
            return path;
        }
        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            RectangleF recSurface = new RectangleF(0, 0, this.Width, this.Height);
            RectangleF recBorder = new RectangleF(1, 1, this.Width - 0.8f, this.Height - 1);
            if (BorderRadius > 2)//Rounded button
            {
                using (GraphicsPath PathSurface = GetFigurePath(recSurface, BorderRadius))
                using (GraphicsPath PathBorder = GetFigurePath(recBorder, BorderRadius - 1f))
                using (Pen PenSurface = new Pen(this.Parent.BackColor, 2))
                using (Pen penBorder = new Pen(borderColor, BorderSize))
                {
                    penBorder.Alignment = PenAlignment.Inset;
                    this.Region = new Region(PathSurface);
                    pevent.Graphics.DrawPath(PenSurface, PathSurface);
                    if (BorderSize >= 1)
                    {//Draw control border
                        pevent.Graphics.DrawPath(penBorder, PathBorder);
                    }
                }
            }
            else//Normal button
            {
                this.Region = new Region(recSurface);
                if (BorderSize >= 1)
                {
                    using (Pen penBorder = new Pen(borderColor, BorderSize))
                    {
                        penBorder.Alignment = PenAlignment.Inset;
                        pevent.Graphics.DrawRectangle(penBorder, 0, 0, this.Width - 1, this.Height - 1);
                    }

                }
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            this.Parent.BackColorChanged += new EventHandler(Container_BackColorChanged);

        }
        private void Container_BackColorChanged(object sender, EventArgs e)
        {
            if (this.DesignMode)
                this.Invalidate();
        }

        private void OnPaint(object sender, PaintEventArgs args)
        {

            for (int i = 0; i < points_List.Count; i++)
            {
                if (points_List[i].EllipseRadius > 0)
                {
                    using (var brush = new SolidBrush(Color.FromArgb(points_List[i].Alpha, ellipseColor)))
                    {
                        args.Graphics.FillEllipse(brush, points_List[i].EllipseX - points_List[i].EllipseRadius, points_List[i].EllipseY - points_List[i].EllipseRadius, 2 * points_List[i].EllipseRadius, 2 * points_List[i].EllipseRadius);
                    }
                }
            }
        }

        public void EllipseRadiusIncrement(object sender, EventArgs args)
        {

            for (int i = 0; i < timer_List.Count; i++)
            {
                if (timer_List[i] == sender)
                {
                    if (points_List[i].EllipseRadius < Width + Height)
                    {
                        points_List[i].EllipseRadius += 10;
                        if (points_List[i].Alpha < 10)
                            points_List[i].Alpha = 10;
                        points_List[i].Alpha -= 1;
                    }
                    else
                    {
                        timer_List[i].Stop();
                        timer_List[i].Dispose();
                        //points_List[i].Dispose();
                        timer_List.RemoveAt(i);
                        points_List.RemoveAt(i);
                    }
                    break;
                }

            }
            Invalidate();

        }
        private void OnMouseClick(object sender, MouseEventArgs e)
        {
            Points newPoints = new Points();
            newPoints.EllipseX = e.X;
            newPoints.EllipseY = e.Y;
            points_List.Add(newPoints);
            Invalidate();
            animationTimer = new Timer();
            animationTimer.Interval = 5;
            animationTimer.Tick += EllipseRadiusIncrement;
            animationTimer.Start();
            timer_List.Add(animationTimer);
        }
    }
}



