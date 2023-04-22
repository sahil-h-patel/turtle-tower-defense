using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Globalization;
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
        bool initialLoad;
        //float dpiX = this.CreateGraphics().DpiX;

        public PathEditor(Menu menu)
        {
            this.menu = menu;
            InitializeComponent();
            currentPath = new Path(path, currentTile, false);
            selectedPath = null!;
            initialLoad = true;
        }

        private void AddPath(object sender, EventArgs e)
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

        private void RemovePath(object sender, EventArgs e)
        {
            if (pathListView.Items.Count > 0)
                pathListView.Items.Remove(pathListView.SelectedItems[0]);
        }

        private void ChangePath(object sender, EventArgs e)
        {
            if (pathListView.SelectedItems.Count > 0)
            {
                selectedPath = pathListView.SelectedItems[0].Text;
                pathName.Text = selectedPath;
                currentPath = pathList[selectedPath];
                Draw();
            }
        }

        private void Clear(object sender, EventArgs e)
        {
            currentPath.Clear();
            pathName.Clear();
            currentTile.Image = null;
        }

        private void Draw()
        {
            path.Controls.Clear();
            for (int x = 0; x < currentPath.Width; x++)
            {
                for (int y = 0; y < currentPath.Height; y++)
                {
                    currentPath.pathGrid[x, y].Load(currentPath.pathGrid[x, y].ImageLocation);
                    currentPath.pathGrid[x, y].Image.RotateFlip(ApplyRotation(currentPath.pathGrid[x, y]));
                    path.Controls.Add(currentPath.pathGrid[x, y]);
                }
            }

        }

        private void ChangeCurrentTileTag(object sender, EventArgs e)
        {
            if (sender is PictureBox)
            {
                PictureBox pb = (PictureBox)sender;

                if (currentTile.Image == pb.Image)
                {
                    return;
                }
                switch (pb.Name)
                {
                    case "forwardTile":
                        pb.Tag = Type.ForwardEast;
                        currentTile.Load("../../../Resources/straightPath.png");
                        break;
                    case "turnLeftTile":
                        pb.Tag = Type.TurnLeftWest;
                        currentTile.Load("../../../Resources/turnLeftPath.png");
                        break;
                    case "turnRightTile":
                        pb.Tag = Type.TurnRightEast;
                        currentTile.Load("../../../Resources/turnRightPath.png");
                        break;
                    case "splitTile":
                        pb.Tag = Type.SplitLeftRight;
                        currentTile.Load("../../../Resources/splitPath.png");
                        break;
                    case "sandTile":
                        pb.Tag = Type.Sand;
                        currentTile.Load("../../../Resources/sandTexture.png");
                        break;
                }
                currentTile.Tag = pb.Tag;
            }
        }

        private void Rotate(object sender, KeyEventArgs e)
        {
            if (!pathName.Focused)
            {
                if (e.KeyData == Keys.R && currentTile.Image != null)
                {
                    Image img = currentTile.Image;
                    if ((Type)currentTile.Tag != Type.Sand && (Type)currentTile.Tag != Type.SplitUpDown)
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
                        secondNum = (secondNum == 3) ? 0 : secondNum + 1;
                        break;
                    case 4:
                        secondNum = (secondNum == 1) ? 0 : 1;
                        break;
                }
                int newTag = Convert.ToInt32(firstNum.ToString() + secondNum.ToString());
                type = (Type)newTag;
            }
            return type;

        }

        private RotateFlipType ApplyRotation(PictureBox pb)
        {
            switch ((Type)pb.Tag)
            {
                case Type.Sand:
                    return default;
                case Type.ForwardNorth:
                    return RotateFlipType.Rotate270FlipNone;
                case Type.ForwardEast:
                    return default;
                case Type.ForwardSouth:
                    return RotateFlipType.Rotate90FlipNone;
                case Type.ForwardWest:
                    return RotateFlipType.Rotate180FlipNone;
                case Type.TurnLeftNorth:
                    return RotateFlipType.Rotate90FlipNone;
                case Type.TurnLeftEast:
                    return RotateFlipType.Rotate180FlipNone;
                case Type.TurnLeftSouth:
                    return RotateFlipType.Rotate270FlipNone;
                case Type.TurnLeftWest:
                    return default;
                case Type.TurnRightNorth:
                    return RotateFlipType.Rotate270FlipNone;
                case Type.TurnRightEast:
                    return default;
                case Type.TurnRightSouth:
                    return RotateFlipType.Rotate90FlipNone;
                case Type.TurnRightWest:
                    return RotateFlipType.Rotate180FlipNone;
                case Type.SplitUpDown:
                    return RotateFlipType.Rotate270FlipNone;
                case Type.SplitLeftRight:
                    return default;
                default:
                    return default;
            }
        }

        private void SavePaths(object sender, EventArgs e)
        {
            string namesOfPath = null;
            foreach (KeyValuePair<string, Path> kvp in pathList)
            {
                StreamWriter output = null!;
                try
                {
                    FileStream stream = new FileStream(System.IO.Path.Combine("../../../Saves/", kvp.Key + ".path"), FileMode.Create);
                    output = new StreamWriter(stream);
                    namesOfPath += $"   - {kvp.Key}\n";

                    for (int x = 0; x < kvp.Value.Width; x++)
                    {
                        for (int y = 0; y < kvp.Value.Height; y++)
                        {
                            if (((int)kvp.Value.pathGrid[x, y].Tag == 0) && (y == kvp.Value.Height - 1))
                            {
                                output.Write("00");
                            }
                            else if ((int)kvp.Value.pathGrid[x, y].Tag == 0)
                            {
                                output.Write("00, ");
                            }
                            else if (y == kvp.Value.Height - 1)
                            {
                                output.Write((int)kvp.Value.pathGrid[x, y].Tag);
                            }
                            else
                            {
                                output.Write((int)kvp.Value.pathGrid[x, y].Tag + ", ");
                            }
                        }
                        output.WriteLine();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error with saving", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (output != null)
                    {
                        output.Close();
                    }
                }
            }
            MessageBox.Show($"Saved {pathList.Count} path(s):\n" + namesOfPath, "Successfuly saved paths to files",
                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void LoadPaths(object sender, EventArgs e)
        {

            OpenFileDialog openFile = new OpenFileDialog();
            openFile.InitialDirectory = "../../../Saves/";
            openFile.Title = "Opening path files";
            openFile.Filter = "PATH Files|*.path";
            openFile.DefaultExt = ".path";
            openFile.Multiselect = true;
            if (pathListView.Items.Count > 0)
            {
                for (int i = 0; i < pathList.Count; i++)
                {

                }
                currentPath.Clear();
                pathListView.Clear();
                pathList.Clear();
            }

            string namesOfPath = null;
            if (openFile.ShowDialog() == DialogResult.OK)
            {

                StreamReader input = null!;
                try
                {
                    for (int i = 0; i < openFile.FileNames.Length; i++)
                    {
                        if (openFile.CheckFileExists && !initialLoad)
                        {
                            continue;
                        }
                        string fileName = openFile.SafeFileNames[i].Substring(0, openFile.SafeFileNames[i].Length - 5);
                        namesOfPath += "- " + fileName + "\n";
                        ListViewItem item = new ListViewItem(fileName);
                        pathListView.Items.Add(item);
                        FileStream stream = new FileStream(openFile.FileNames[i], FileMode.Open);
                        input = new StreamReader(stream);

                        Path newPath = new Path(path, currentTile, true);
                        newPath.Load(input);
                        pathList.Add(fileName, newPath);
                    }
                }
                catch (Exception ex)
                {
                    DialogResult dialogResult = MessageBox.Show(ex.Message, "Could not load path",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (input != null)
                    {
                        input.Close();
                    }
                    initialLoad = false;
                    MessageBox.Show($"Loaded {openFile.FileNames.Length} path(s): \n" + namesOfPath, "Successfuly loaded paths to editor",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }

        private void DeselectText(object sender, EventArgs e)
        {
            ActiveControl = null;
        }
    }
}

