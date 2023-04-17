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
        //float dpiX = this.CreateGraphics().DpiX;

        public PathEditor(Menu menu)
        {
            this.menu = menu;
            InitializeComponent();
            currentPath = new Path(path, currentTile);
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
            if (pathListView.SelectedItems.Count > 0)
            {
                selectedPath = pathListView.SelectedItems[0].Text;
                pathName.Text = selectedPath;
                currentPath = pathList[selectedPath];
                Draw(selectedPath);
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            if (pathList.Count > 0)
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



        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Title = "Saving a path file";
            saveFile.Filter = "Path Files|*.path";
            saveFile.DefaultExt = ".path";
            saveFile.InitialDirectory = "../../../Saves/";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                FileStream stream = new FileStream(System.IO.Path.Combine(saveFile.InitialDirectory, saveFile.FileName), FileMode.Create);
                StreamWriter output = new StreamWriter(stream);

                foreach (KeyValuePair<string, Path> kvp in pathList)
                {
                    output.WriteLine(kvp.Key);
                    for (int x = 0; x < kvp.Value.Width; x++)
                    {
                        for (int y = 0; y < kvp.Value.Height; y++)
                        {
                            output.Write(kvp.Value.pathGrid[x, y].BackColor.ToArgb() + ", ");
                        }
                    }
                    output.WriteLine();
                }
            }
        }

        private void sandTile_Click(object sender, EventArgs e)
        {
            if(sender is PictureBox)
            {
                PictureBox pb = (PictureBox)sender;
                switch (pb.Name)
                {
                    case "forwardTile":
                        pb.Tag = Type.Forward;
                        break;
                    case "rightTurnTile":
                        pb.Tag = Type.Right_Turn;
                        break;
                    case "leftTurnTile":
                        pb.Tag = Type.Left_Turn;
                        break;
                    case "splitTile":
                        pb.Tag = Type.Split;
                        break;
                    case "sandTile":
                        pb.Tag = Type.Sand;
                        break;
                }
                currentTile.Image = pb.Image;
            }  
        }

        private void PathEditor_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.R)
            {
                Image img = currentTile.Image;
                img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                currentTile.Image = img;
            }
        }

        //private void LoadPath(string path)
        //{
        //    OpenFileDialog openFile = new OpenFileDialog();
        //    openFile.Title = "Saving a path file";
        //    openFile.Filter = "Path Files|*.path";
        //    openFile.DefaultExt = ".path";

        //    if (openFile.ShowDialog() == DialogResult.OK)
        //    {
        //        FileStream stream = new FileStream(path, FileMode.OpenOrCreate);
        //        StreamReader input = new StreamReader(stream);

        //        foreach (KeyValuePair<string, Path> kvp in pathList)
        //        {
        //            string line;
        //            while ((line = input.ReadLine()) != null)
        //            {
        //                if (input.ReadLine) 
        //            }
        //        }
        //    }
        //}

    }
}
