using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace WinFormMVC.Model
{
    public class Function
    {
        DataGridView dataGridView;
        Graphics gr;
        PointF mouseDown, mouseUp;
        DelFunction function;
        Bitmap bitmapFunction = new Bitmap(wid, hgt);
        BackgroundWorker backgroundWorker;
        List<PointF> pointsFunction = new List<PointF>();
        List<PointF> pointsVisualization = new List<PointF>();

        private static int wid = 750;
        private static int hgt = 500;
        float xstart;
        float xmin;
        float xmax;
        float ymin;
        float ymax;

        public enum FunctionType {Polynomial, Logarithm, Exponential, Sine, Cosine};
        FunctionType currentFunction;
        IController controller;

        public Function(IController _controller)
        {
            controller = _controller;
            function = PolynomialFunction;
        }

        public FunctionType CurrentFunctionType
        {
            set
            {
                currentFunction = value;

                switch (value)
                {
                    case FunctionType.Polynomial:
                        function = PolynomialFunction;
                        break;

                    case FunctionType.Logarithm:
                        function = LogarithmFunction;
                        break;

                    case FunctionType.Exponential:
                        function = ExponentialFunction;
                        break;

                    case FunctionType.Sine:
                        function = SineFunction;
                        break;

                    case FunctionType.Cosine:
                        function = CosineFunction;
                        break;
                }
            }
        }

        public float XStart
        {
            set { xstart = value; }
        }

        public DataGridView DataGridView
        {
            set { dataGridView = value; }
        }

        public PointF MouseDown
        {
            set { mouseDown = value; }
        }

        public PointF MouseUP
        {
            set { mouseUp = value; }
        }

        public int SleepTime { get; set; }

        public void ClearVisualizationPoints()
        {
            pointsVisualization.Clear();
        }

        private delegate float DelFunction(float x, int row);

        private float PolynomialFunction(float x, int row)
        {
            float result = 0;
            float a = Convert.ToSingle(dataGridView[0, row].Value);

            for (int i = 2; i < dataGridView.ColumnCount - 1; i++)
            {
                result += Convert.ToSingle(Convert.ToDouble(dataGridView[i, row].Value) * Math.Pow(x, i - 1));
            }

            return a * result + Convert.ToSingle(dataGridView[1, row].Value);
        }

        private float LogarithmFunction(float x, int row)
        {
            double a  = Convert.ToDouble(dataGridView[0, row].Value);
            double b  = Convert.ToDouble(dataGridView[1, row].Value);
            double c  = Convert.ToDouble(dataGridView[2, row].Value);
            double d  = Convert.ToDouble(dataGridView[3, row].Value);
            double yo = Convert.ToDouble(dataGridView[4, row].Value);
            
            return Convert.ToSingle(a * Math.Log(c * (x - d), b) + yo);
        }

        private float ExponentialFunction(float x, int row)
        {
            double a  = Convert.ToDouble(dataGridView[0, row].Value);
            double b  = Convert.ToDouble(dataGridView[1, row].Value);
            double c  = Convert.ToDouble(dataGridView[2, row].Value);
            double d  = Convert.ToDouble(dataGridView[3, row].Value);
            double yo = Convert.ToDouble(dataGridView[4, row].Value);

            return Convert.ToSingle(a * Math.Pow(b, c * (x - d)) + yo);
        }

        private float SineFunction(float x, int row)
        {
            double a = Convert.ToDouble(dataGridView[0, row].Value);
            double b = Convert.ToDouble(dataGridView[1, row].Value);
            double c = Convert.ToDouble(dataGridView[2, row].Value);
            double yo = Convert.ToDouble(dataGridView[3, row].Value);

            return Convert.ToSingle(a * Math.Sin(b * x + c) + yo);
        }

        private float CosineFunction(float x, int row)
        {
            double a = Convert.ToDouble(dataGridView[0, row].Value);
            double b = Convert.ToDouble(dataGridView[1, row].Value);
            double c = Convert.ToDouble(dataGridView[2, row].Value);
            double yo = Convert.ToDouble(dataGridView[3, row].Value);

            return Convert.ToSingle(a * Math.Cos(b * x + c) + yo);
        }

        private float Fd(DelFunction function, float x, int row)
        {
            float h = 0.00001f;
            return (function(x + h, row) - function(x, row)) / h;
        }

        private bool updateBackgroundWorker = true;

        private void BWReportProgress()
        {
            if (backgroundWorker != null)
            {
                if (updateBackgroundWorker)
                {
                    updateBackgroundWorker = false;
                    backgroundWorker.ReportProgress(10);
                }
                else
                {
                    updateBackgroundWorker = true;
                    backgroundWorker.ReportProgress(1);
                }
            }
        }

        public Bitmap DrawVisualization()
        {
            try
            {
                if (pointsVisualization.Count != 0)
                {
                    gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    gr.DrawLines(new Pen(Color.LimeGreen, 0), pointsVisualization.ToArray());
                }
            }
            catch { }

            return bitmapFunction;
        }

        public float NewtonAlgorithm()
        {
            int selectedRowIndex = int.MaxValue;

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.Selected)
                {
                    selectedRowIndex = row.Index;
                }
            }

            float xold;
            float x = xstart;

            if (selectedRowIndex != int.MaxValue)
            {
                do
                {
                    if (x.Equals(float.NaN) || float.IsInfinity(x)) { break; }

                    xold = x;
                    x -= (function(x, selectedRowIndex) / Fd(function, x, selectedRowIndex));

                    if (pointsVisualization.Count == 0)
                    {
                        pointsVisualization.Add(new PointF(xold, 0));
                    }

                    pointsVisualization.Add(new PointF(xold, function(xold, selectedRowIndex)));
                    pointsVisualization.Add(new PointF(x, 0));

                    BWReportProgress();

                    if (SleepTime != 0)
                    {
                        Thread.Sleep(SleepTime);
                    }

                } while ((Math.Round(xold, 6) != Math.Round(x, 6)) && !backgroundWorker.CancellationPending);
            }
            backgroundWorker.ReportProgress(100);

            return x;
        }

        public Bitmap MakeGraph(float _xmin, float _xmax, float _ymin, float _ymax)
        {
            //The bounds to draw.
            xmin = _xmin;
            xmax = _xmax;
            ymin = _ymin;
            ymax = _ymax;

            // Make the Bitmap.
            gr = Graphics.FromImage(bitmapFunction);
            gr.Clear(Color.Transparent);
            gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            //Transform the graphics object to cartesian coordinates
            float fdx = wid * -(xmin / (xmax - xmin));
            float fdy = hgt * -(ymax / (ymin - ymax));

            gr.TranslateTransform(fdx, fdy);

            float sx = Convert.ToSingle(wid) / Math.Abs(xmax - xmin);
            float sy = Convert.ToSingle(hgt) / Math.Abs(ymax - ymin);

            gr.ScaleTransform(sx, -sy);

            // Draw the graph.
            using (Pen graph_pen = new Pen(Color.Blue, 0), grid_pen = new Pen(Color.LightGray, 0))
            {
                for (int x = (int)xmin; x <= xmax; x++)
                {
                    //Draw Grid
                    gr.DrawLine(grid_pen, x, ymin, x, ymax);
                    //Draw AxesSeperation
                    gr.DrawLine(graph_pen, x, -0.1f, x, 0.1f);
                }
                for (int y = (int)ymin; y <= ymax; y++)
                {
                    //Draw Grid
                    gr.DrawLine(grid_pen, xmin, y, xmax, y);
                    //Draw AxesSeperation
                    gr.DrawLine(graph_pen, -0.1f, y, 0.1f, y);
                }

                //Draw the axes.
                gr.DrawLine(graph_pen, xmin, 0, xmax, 0);
                gr.DrawLine(graph_pen, 0, ymin, 0, ymax);

                graph_pen.Color = Color.Red;

                //See how big 1 pixel is horizontally.
                System.Drawing.Drawing2D.Matrix inverse = gr.Transform;
                inverse.Invert();
                PointF[] pixel_pts =
                {
                        new PointF(0, 0),
                        new PointF(1, 0)
                };
                inverse.TransformPoints(pixel_pts);
                float dx = pixel_pts[1].X - pixel_pts[0].X;
                dx /= 4;

                //Draw Function
                //Loop over every function in DataGridView
                for (int i = 0; i < dataGridView.RowCount - 1; i++)
                { 
                    if (dataGridView.Rows[i].Selected == true)
                    {
                        float y;
                        //Loop over x values to generate points.
                        for (float x = xmin; x <= xmax; x += dx)
                        {
                            //Get the next point.
                            y = function(x, i);

                            if (!Single.IsNaN(y) && !Single.IsInfinity(y) && !(y > 100000))
                            {
                                //Only add points that are visible
                                if (y < ymax + 0.2 && ymin - 0.2 < y)
                                {
                                    if (function(x - dx, i) > ymax || function(x - dx, i) < ymin)
                                    {
                                        pointsFunction.Add(new PointF(x - dx, function(x - dx, i)));
                                    }

                                    pointsFunction.Add(new PointF(x, y));

                                    if (function(x + dx, i) > ymax || function(x + dx, i) < ymin)
                                    {
                                        pointsFunction.Add(new PointF(x + dx, function(x + dx, i)));
                                    }
                                }
                            }
                        }

                        if (pointsFunction.Count != 0)
                        {
                            try
                            {
                                gr.DrawLines(graph_pen, pointsFunction.ToArray());
                            }
                            catch (Exception e)
                            {
                                MessageBox.Show(e.ToString(), e.Message);
                            }
                        }
                        pointsFunction.Clear();
                    }
                }
            }

            controller.UpdateFunctionTextBox(xmin, xmax, ymin, ymax);

            //return the result.
            return DrawVisualization();
        }

        public Bitmap ShiftCoordinateSystem()
        {
            System.Drawing.Drawing2D.Matrix inverse = gr.Transform;
            inverse.Invert();
            PointF[] pointFs =
            {
                        mouseDown,
                        mouseUp
            };

            //Transform Points in Coordinate-System Points
            inverse.TransformPoints(pointFs);

            float xOffSet = pointFs[0].X - pointFs[1].X;
            float yOffSet = pointFs[0].Y - pointFs[1].Y;

            xmin += xOffSet;
            xmax += xOffSet;
            ymin += yOffSet;
            ymax += yOffSet;

            return MakeGraph(xmin, xmax, ymin, ymax);
        }

        public Bitmap MousWheel(MouseEventArgs e)
        {
            float sign;
            if (e.Delta > 0)
            {
                sign = -1;
            }
            else
            {
                sign = 1;
            }

            float testXmin = xmin + sign * -0.75f;
            float testXmax = xmax + sign * 0.75f;
            float testYymin = ymin + sign * -0.5f;
            float testYymax = ymax + sign * 0.5f;

            //Dont allow the user to zoom to deep into the graph
            if ((testXmin != 0 || testXmax != 0 || testYymin != 0 || testYymax != 0) && !(0.0001 > (testXmax - testXmin) && (testXmax - testXmin) >= -0.0001 ||
                                                                            0.0001 > (testYymax - testYymin) && (testYymax - testYymin) >= -0.0001))
            {
                xmin = testXmin;
                xmax = testXmax;
                ymin = testYymin;
                ymax = testYymax;
            }

            return MakeGraph(xmin, xmax, ymin, ymax);
        }

        public void SetBackgroundWorker(BackgroundWorker backgroundWorker)
        {
            this.backgroundWorker = backgroundWorker;
        }
    }
}