using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using WinFormMVC.Model;

namespace WinFormMVC.View
{
    class GPage : TabPage 
    {
        private CPictureBox pbGraph  { get; set; }
        private PictureBox pbMatrix  { get; set; }

        public TabControl tabControl { get; set; }

        private TabPage tpMatrix     { get; set; }
        private TabPage tpLogs       { get; set; }

        public RichTextBox rtbLogs   { get; set; }

        private bool onHold = false;

        private Point source = new Point(0, 0);
        private Point destination = new Point(0, 0);

        private Point MatrixHoverPoint = new Point(0, 0);

        public Graph invokeGraph { get; set; }

        public GPage(Graph _Graph, string Text)
        {
            this.Text = Text;
            this.BackColor = Color.White;
            this.invokeGraph = _Graph;

            AddControls();

            this.pbMatrix.Paint += (sender, e) => Matrix_OnPaint(sender, e, _Graph);
            this.pbGraph.Paint += (sender, e) => Graph_OnPaint(sender, e, _Graph);

            this.pbGraph.MouseDown += delegate (object sender, MouseEventArgs e) 
            {
                if (e.Button == MouseButtons.Left)
                {
                    if (_Graph.Get((e.X / StaticValues.CDIAMETER), (e.Y / StaticValues.CDIAMETER)) == null)
                        _Graph.Add(new Vertex(_Graph.V)
                        {
                            x = e.X / StaticValues.CDIAMETER,
                            y = e.Y / StaticValues.CDIAMETER
                        });

                    else
                    {
                        this.source = this.destination = _Graph.Get((e.X / StaticValues.CDIAMETER), (e.Y / StaticValues.CDIAMETER)).Center;
                        this.onHold = true;
                    }
                }

                else if (e.Button == MouseButtons.Right)
                {
                    _Graph.Remove(_Graph.Get((e.X / StaticValues.CDIAMETER), (e.Y / StaticValues.CDIAMETER)));
                }

                pbGraph.Invalidate();
                pbMatrix.Invalidate();
            };

            this.pbGraph.MouseUp += delegate (object sender, MouseEventArgs e) 
            {
                if (e.Button == MouseButtons.Left)
                {
                    Vertex V1 = _Graph.Get(source.X / StaticValues.CDIAMETER, source.Y / StaticValues.CDIAMETER);
                    Vertex V2 = _Graph.Get(destination.X / StaticValues.CDIAMETER, destination.Y / StaticValues.CDIAMETER);

                    if (V1 != null && V2 != null && V1 != V2 && onHold)
                        _Graph.Connect(V1, V2);

                    pbGraph.Invalidate();
                    pbMatrix.Invalidate();
                }

                onHold = false;
            };

            this.pbGraph.MouseMove += delegate (object sender, MouseEventArgs e) 
            {
                if (onHold)
                {
                    destination = new Point(e.X, e.Y);
                    pbGraph.Invalidate();
                }
            };

            this.pbMatrix.MouseDown += delegate (object sender, MouseEventArgs e)
            {
                int i = e.X / StaticValues.CDIAMETER - 1;
                int j = e.Y / StaticValues.CDIAMETER - 1;

                if (i != j && i < _Graph.V && j < _Graph.V && i > -1 && j > -1)
                {
                    if (e.Button == MouseButtons.Left)
                        _Graph.Connect(_Graph[i], _Graph[j]);

                    else if (e.Button == MouseButtons.Right)
                    {
                        Edge ptrTemp = _Graph.Get(_Graph[i], _Graph[j]);

                        if (ptrTemp != null && ptrTemp.cost > 0)
                        {
                            if (ptrTemp.cost - 1 == 0)
                                _Graph.Edges.Remove(ptrTemp);

                            else
                                ptrTemp.cost--;
                        }
                    }

                    pbMatrix.Invalidate();
                    pbGraph.Invalidate();
                }
            };

            this.pbMatrix.MouseMove += delegate (object sender, MouseEventArgs e) 
            {
                this.MatrixHoverPoint = new Point(((e.Location.X) / StaticValues.CDIAMETER) * StaticValues.CDIAMETER,
                    ((e.Location.Y / StaticValues.CDIAMETER) * StaticValues.CDIAMETER));

                pbMatrix.Invalidate();
            };
        }

        private void Matrix_OnPaint(object sender, PaintEventArgs e, Graph _Graph)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Grid Hover Highlight
            if (MatrixHoverPoint.X > 0 && MatrixHoverPoint.Y > 0 && (MatrixHoverPoint.X / StaticValues.CDIAMETER) <= _Graph.V && MatrixHoverPoint.Y / StaticValues.CDIAMETER <= _Graph.V)
                e.Graphics.FillRectangle(new SolidBrush(Color.WhiteSmoke), MatrixHoverPoint.X, MatrixHoverPoint.Y, StaticValues.MATRIX_GRID_W, StaticValues.MATRIX_GRID_H);

            // Horizonal Label Reconstruction
            int x = StaticValues.MATRIX_GRID_W, y = 0;
            for (int i = 0; i < _Graph.V; i++)
            {
                e.Graphics.DrawString(string.Format("{0,2}", i + 1), new Font("Roboto Condensed", 9, FontStyle.Italic), new SolidBrush(Color.Black), x + 7, y);
                x += StaticValues.MATRIX_GRID_W;
            }

            // Vertical Label Reconstruction
            x = 0; y = StaticValues.MATRIX_GRID_H;
            for (int i = 0; i < _Graph.V; i++)
            {
                e.Graphics.DrawString(string.Format("{0,2}", i + 1), new Font("Roboto Condensed", 9, FontStyle.Italic), new SolidBrush(Color.Black), x, y + 7);
                y += StaticValues.MATRIX_GRID_H;
            }

            // ------------ ADJACENCY MATRIX RECONSTRUCTION ------------ //
            x = StaticValues.MATRIX_GRID_W; y = StaticValues.MATRIX_GRID_H;
            for (int i = 0; i < _Graph.V; i++)
            {
                for (int j = 0; j < _Graph.V; j++)
                {
                    e.Graphics.DrawRectangle(new Pen(SystemColors.ActiveBorder, 1), x, y, StaticValues.MATRIX_GRID_W, StaticValues.MATRIX_GRID_H);

                    if (i == j)
                        e.Graphics.DrawString(string.Format("{0,2}", "-"), new Font("Consolas", 10, FontStyle.Regular), new SolidBrush(Color.Black), x + 2, y + 7);

                    foreach (Edge edge in _Graph.Edges)
                        if ((edge[0].id == i && edge[1].id == j) || (edge[0].id == j && edge[1].id == i))
                            e.Graphics.DrawString(string.Format("{0,2}", edge.cost), this.Font, new SolidBrush(Color.Black), x + 6, y + 9);

                    x += StaticValues.MATRIX_GRID_W;
                }

                x = StaticValues.MATRIX_GRID_W;
                y += StaticValues.MATRIX_GRID_H;
            }
        }

        private void Graph_OnPaint(object sender, PaintEventArgs e, Graph _Graph)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Drag & Drop Connection Line Reconstruction
            if (onHold)
            {
                e.Graphics.DrawLine(new Pen(Color.IndianRed, 2) { DashPattern = new[] { 2f, 2f, 2f, 2f } }, source, destination);
                e.Graphics.DrawString(StaticValues.INITIAL_COST.ToString(), this.Font, new SolidBrush(Color.Black), 0.5f * (source.X + destination.X), 0.5f * (source.Y + destination.Y));
            }

            // Connection Line Reconstruction
            foreach (Edge edge in _Graph.Edges)
                e.Graphics.DrawLine(new Pen(Color.IndianRed, 2), edge[0].Center, edge[1].Center);

            // Connection Cost-Label Reconstruction
            foreach (Edge edge in _Graph.Edges)
                e.Graphics.DrawString(edge.cost.ToString(), this.Font, new SolidBrush(Color.Black), 0.5f * (edge[0].Center.X + edge[1].Center.X), 0.5f * (edge[0].Center.Y + edge[1].Center.Y));

            // Vertex Ellipse Reconstruction
            foreach (Vertex v in _Graph)
            {
                e.Graphics.FillEllipse(new SolidBrush(Color.LightYellow), new Rectangle(v.Location, v._Size));
                e.Graphics.DrawEllipse(new Pen(Color.Black), new Rectangle(v.Location, v._Size));

                e.Graphics.DrawString(string.Format("{0,2}", v.id + 1), this.Font, new SolidBrush(Color.Black), v.Location.X + 7, v.Location.Y + 9);
            }
        }

        private void AddControls()
        {
            this.Controls.Add(pbGraph = new CPictureBox()
            {
                Location = new Point(15, 15),
                Size = new Size(510, 510)
            });

            this.Controls.Add(tabControl = new TabControl()
            {
                Location = new Point(531, 15),
                Size = new Size(488, 510)
            });

            this.tabControl.TabPages.Add(tpMatrix = new TabPage("Adjacency Matrix")
            {
                BackColor = Color.White
            });

            this.tabControl.TabPages[0].Controls.Add(pbMatrix = new PictureBox()
            {
                Location = new Point(12, 18),
                Size = new Size(480, 480)
            });

            this.tabControl.TabPages.Add(tpLogs = new TabPage("Logs")
            {
                BackColor = Color.White
            });

            this.tabControl.TabPages[1].Controls.Add(rtbLogs = new RichTextBox()
            {
                Location = new Point(12, 12),
                Size = new Size(450, 450),
            });
        }
    }
}
