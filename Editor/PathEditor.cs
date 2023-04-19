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
            currentPath.Clear();
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

        private void sandTile_Click(object sender, EventArgs e)
        {
            if (sender is PictureBox)
            {
                PictureBox pb = (PictureBox)sender;
                switch (pb.Name)
                {
                    case "forwardTile":
                        pb.Tag = Type.ForwardEast;
                        break;
                    case "rightTurnTile":
                        pb.Tag = Type.TurnWest;
                        break;
                    case "leftTurnTile":
                        pb.Tag = Type.TurnEast;
                        break;
                    case "splitTile":
                        pb.Tag = Type.SplitLeftRight;
                        break;
                    case "sandTile":
                        pb.Tag = Type.Sand;
                        break;
                }
                currentTile.Image = pb.Image;
                currentTile.Tag = pb.Tag;
            }
        }

        private void PathEditor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.R && currentTile.Image != null)
            {
                Image img = currentTile.Image;
                if((Type)currentTile.Tag != Type.Sand && (Type)currentTile.Tag != Type.SplitUpDown)
                {
                    img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    
                }
                else if ((Type)currentTile.Tag == Type.SplitUpDown)
                {
                    img.RotateFlip(RotateFlipType.Rotate270FlipNone);
                }
                currentTile.Image = img;
                currentTile.Tag = ChangeRotationTag();
            }
        }

        private Type ChangeRotationTag()
        {
            int tag = (int)currentTile.Tag;
            Type type = default;
            if ((Type)currentTile.Tag != Type.Sand)
            {
                int firstNum = Convert.ToInt32(tag.ToString().Substring(0, 1));
                int secondNum = Convert.ToInt32(tag.ToString().Substring(1));
                switch (firstNum)
                {
                    case 1:
                        secondNum = (secondNum == 3) ? 0 : secondNum + 1;
                        break;
                    case 2:
                        secondNum = (secondNum == 3) ? 0 : secondNum + 1;
                        break;
                    case 3:
                        secondNum = (secondNum == 1) ? 0 : 1;
                        break;
                }
                int newTag = Convert.ToInt32(firstNum.ToString() + secondNum.ToString());
                type = (Type)newTag;
            }
            return type;

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
                StreamWriter output = null;
                try
                {
                    FileStream stream = new FileStream(System.IO.Path.Combine(saveFile.InitialDirectory, saveFile.FileName), FileMode.Create);
                    output = new StreamWriter(stream);

                    foreach (KeyValuePair<string, Path> kvp in pathList)
                    {
                        for (int x = 0; x < kvp.Value.Width; x++)
                        {
                            for (int y = 0; y < kvp.Value.Height; y++)
                            {
                                if((int)kvp.Value.pathGrid[x, y].Tag == 0)
                                {
                                    output.Write("00, ");
                                }
                                else
                                {
                                    output.Write((int)kvp.Value.pathGrid[x, y].Tag + ", ");
                                }
                            }
                        }
                        output.WriteLine();
                        output.WriteLine();
                    }
                }
                catch (Exception ex)
                {
                    DialogResult dialogResult = MessageBox.Show("Error with saving", ex.Message,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (output != null)
                    {
                        output.Close();
                    }
                }
            }
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Title = "Reading a path file";
            openFile.Filter = "Path Files|*.path";
            openFile.DefaultExt = ".path";
            openFile.InitialDirectory = "../../../Saves/";

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                StreamReader input = null;
                try
                {
                    FileStream stream = new FileStream(System.IO.Path.Combine(openFile.InitialDirectory, openFile.FileName), FileMode.OpenOrCreate);
                    input = new StreamReader(stream);

                    foreach (KeyValuePair<string, Path> kvp in pathList)
                    {
                        string line;

                        while ((line = input.ReadLine()) != null)
                        {
                            if (line == string.Empty)
                                continue;
                            else
                            {
                                int[] coords = ConvertInt32Array(line.Split(','));
                                for (int i = 0; i < coords.Length; i++)
                                {

                                }
                            }
                        }
                    }
                }
                catch(Exception ex)
                {
                    DialogResult dialogResult = MessageBox.Show("Error with loading", ex.Message,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if(input != null)
                    {
                        input.Close();
                    }
                }
                
            }
        }

        private int[] ConvertInt32Array(string[] array)
        {
            int[] coords = new int[array.Length];
            for(int i = 0; i < array.Length; i++)
            {
                coords[i] = Convert.ToInt32(array[i]);
            }

            return coords;
        }
    }

    //private void LoadPath(string path)
    //{
    //    
    //}

}

