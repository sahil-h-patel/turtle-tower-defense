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
        Dictionary<string, Path> pathList = new Dictionary<string, Path>();
        private string selectedPath;
        private Path currentPath;

        public PathEditor(Menu menu)
        {
            this.menu = menu;
            InitializeComponent();
            currentPath = new Path(path);
        }
        private void addButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(pathName.Text))
                return;
            ListViewItem item = new ListViewItem(pathName.Text);
            pathListView.Items.Add(item);
            Path temp = currentPath.Copy();
            pathList.Add(pathName.Text, temp);
            pathName.Clear();
            currentPath.Clear();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (pathListView.Items.Count > 0)
                pathListView.Items.Remove(pathListView.SelectedItems[0]);
        }

        private void pathListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(pathListView.SelectedItems.Count > 0)
            {
                selectedPath = pathListView.SelectedItems[0].Text;
                pathName.Text = selectedPath;
                currentPath = pathList[selectedPath];
                Draw(selectedPath);
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            if(pathList.Count > 0)
            {
                if (pathList[pathListView.SelectedItems[0].Text].Filled)
                {
                    pathList[pathName.Text].Clear();
                }
            }
        }

        private void Draw(string namePath)
        {
            for (int x = 0; x < pathList[namePath].pathGrid.GetLength(0); x++)
            {
                for (int y = 0; y < pathList[namePath].pathGrid.GetLength(1); y++)
                {
                    if (pathList[namePath].pathGrid[x, y].BackColor == Color.Gray)
                    {
                        currentPath.pathGrid[x, y].BackColor = Color.Gray;
                    }
                }
            }
        }

        private void Save(string path)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            if(saveFile.ShowDialog() == DialogResult.OK)
            {
                saveFile.Title = "Saving a path file";
                saveFile.Filter = "Path Files|*.path";
                saveFile.DefaultExt = ".path";

                FileStream stream = new FileStream(path, FileMode.OpenOrCreate);
                StreamWriter output = new StreamWriter(stream);
                
                foreach(KeyValuePair<string, Path> kvp in pathList)
                {
                    output.WriteLine(kvp.Key);
                    for(int i = 0; i < kvp.Value.X; i++)
                    {
                        for(int j = 0; j < kvp.Value.Y; j++)
                        {

                        }
                    }
                }
            }
          

        }
        
    }
}
