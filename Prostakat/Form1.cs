using System.Drawing.Drawing2D;

namespace Prostakat
{
    public partial class Form1 : Form
    {
        public int vertices = 4;
        public Random randomVariable = new Random();
        public double distance(int x, int y, int x2, int y2)
        {
            return Math.Sqrt(Math.Pow(x - x2, 2) + Math.Pow(y - y2, 2));
        }
        public Form1()
        {
            InitializeComponent();
        }
        public double polygonArea(double[] X, double[] Y)
        {
            double area = 0.0;
            int j = vertices - 1;
            for (int i = 0; i < vertices; i++)
            {
                area += (X[j] + X[i]) * (Y[j] - Y[i]);
                j = i;
            }
            return Math.Abs(area / 2.0);

        }
        private void button1_Click(object sender, EventArgs e)
        {
           Graphics graphics = pictureBox1.CreateGraphics();
            graphics.Clear(Color.White);
            int aX = randomVariable.Next(0, 175);
            int aY = randomVariable.Next(0, 175);
            int bX = randomVariable.Next(175, 350);
            int bY = randomVariable.Next(0, 175);
            int cX = randomVariable.Next(175, 350);
            int cY = randomVariable.Next(175, 350);
            int dX = randomVariable.Next(0, 175);
            int dY = randomVariable.Next(175, 350);
            GraphicsPath path = new GraphicsPath();
            path.AddLine(aX, aY, bX, bY);
            path.AddLine(bX, bY, cX, cY);
            path.AddLine(cX, cY, dX, dY);
            path.AddLine(dX, dY, aX, aY);
            graphics.DrawPath(new Pen(Color.FromArgb(128, 255, 0, 0), 4), path);
            double area = polygonArea([aX, bX, cX, dX], [aY, bY, cY, dY]);
            label1.Text = "Area: " + area;
        }
    }
}
