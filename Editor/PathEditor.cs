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
        protected PictureBox[,] pathGrid = new PictureBox[16, 28];
        private const int boxHeight = 40;
        private const int boxWidth = 40;

        public PathEditor()
        {
            InitializeComponent();
            SetUpGrid();
        }

        private void SetUpGrid()
        {
            for(int height = 0; height < pathGrid.GetLength(1); height++)
            {
                for(int width = 0; width < pathGrid.GetLength(0); width++)
                {
                    pathGrid[width, height] = new PictureBox();
                    pathGrid[width, height].Size = new Size(boxWidth, boxHeight);
                    pathGrid[width, height].Location = new Point(path.Location.X + (width * boxWidth), 
                        path.Location.Y + (height * boxHeight));
                    path.Controls.Add(pathGrid[width, height]);
                }
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            pathListView.Columns.Add(pathName.Text);
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            pathListView.Columns.RemoveByKey(pathName.Text);

        }
    }
}
