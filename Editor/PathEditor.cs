using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Editor
{
    public partial class PathEditor : Form
    {
        Menu menu = new Menu();
        protected PictureBox[,] pathGrid = new PictureBox[28, 16];
        private const int boxHeight = 20;
        private const int boxWidth = 20;

        public PathEditor(Menu menu)
        {
            this.menu = menu;
            InitializeComponent();
        }

        private void SetUpGrid()
        {
            for (int height = 0; height < pathGrid.GetLength(1); height++)
            {
                for (int width = 0; width < pathGrid.GetLength(0); width++)
                {
                    pathGrid[width, height] = new PictureBox();
                    pathGrid[width, height].Size = new Size(boxWidth, boxHeight);
                    pathGrid[width, height].Location = new Point(width * boxWidth,
                        (height * boxHeight));
                    path.Controls.Add(pathGrid[width, height]);
                    pathGrid[width, height].MouseMove += MouseMove;
                    pathGrid[width, height].MouseDown += MouseDown;
                }
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(pathName.Text))
                return;
            ListViewItem item = new ListViewItem(pathName.Text);
            pathListView.Items.Add(item);
            pathName.Clear();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (pathListView.Items.Count > 0)
                pathListView.Items.Remove(pathListView.SelectedItems[0]);
        }

        private void PathEditor_Load(object sender, EventArgs e)
        {
            SetUpGrid();
        }




        protected new void MouseMove(object? sender, MouseEventArgs e)
        {

            if(sender is PictureBox)
            {
                PictureBox pb = (PictureBox)sender;
                if(e.Button == MouseButtons.Left)
                {
                    pb.BackColor = Color.Gray;

                }
            }
        }

        private new void MouseDown(object? sender, EventArgs e)
        {
            if(sender is PictureBox)
            {
                PictureBox pb = (PictureBox)sender;
                pb.Capture = false;
                pb.BackColor = Color.Gray;
            }
        }
    }
}
