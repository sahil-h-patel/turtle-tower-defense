using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LevelEditor
{
    public partial class LevelEditor : Form
    {
        Form1 menu = new Form1();
        PictureBox[,] map;
        string title;
        bool saved = true;
        int mapHeight = 576;
        int mapWidth = 1024;

        /// <summary>
        /// This initializes the Level Editor class
        /// </summary>
        /// <param name="menu">This communicates with the Form1 class which has information needed to create the map</param>
        /// <param name="loaded">Checks whether if a file was loaded in or not from Form1</param>
        /// <param name="title">The title of the file if it was loaded in or not</param>
        public LevelEditor(Form1 menu, bool loaded, string title)
        {
            // Intializes the form and the title of the file
            this.menu = menu;
            this.title = title;

            InitializeComponent();

     
                CreateMap();
            
        }

        /// <summary>
        /// Creates a blank map with the appropiate height and width
        /// </summary>
        private void CreateMap()
        {
            // Intializing variables which will offset and
            // pad the pixels so they are not cut off
            int heightOffset = 20;
            int widthOffset = 10;
            int heightPadding = 15;
            int widthPadding = 5;

            // Initializes the pixel height, pixel width, group box width,
            // group box height, the form width, and the form height
            int boxHeight = 32;
            int boxWidth = boxHeight;
            groupBoxMap.Height = (boxHeight * mapHeight) + heightOffset;
            groupBoxMap.Width = (boxWidth * mapWidth) + widthOffset;

            // Initializes the map with the height and width inputted by the user
            map = new PictureBox[mapHeight, mapWidth];

            // Iterates through the array and initailizes each pixel with a Picture Box
            // which has the appropiate size and location, and then adds it to the group box
            // and subscribes the Click event to the Change Color method
            for (int i = 0; i < mapHeight; i++)
            {
                for (int j = 0; j < mapWidth; j++)
                {
                    map[i, j] = new PictureBox();
                    map[i, j].Size = new Size(boxWidth, boxHeight);
                    map[i, j].Location = new Point(widthPadding + (j * boxWidth), (i * boxHeight) + heightPadding);
                    groupBoxMap.Controls.Add(map[i, j]);
                    map[i, j].Click += ChangeColor;
                }

            }
            this.Text = title;
        }

        /// <summary>
        /// This is the same thing as the CreateMap method but initializes the pixel with the appropiate color
        /// </summary>
        private void LoadMap()
        {
           
        }

        /// <summary>
        /// Clears the map of the previous map that was loaded in
        /// </summary>
        private void ClearMap()
        {
            // Iterates through the map of pixels and removes them from the groupBox
            for (int i = 0; i < mapHeight; i++)
            {
                for (int j = 0; j < mapWidth; j++)
                {
                    groupBoxMap.Controls.Remove(map[i, j]);      
                }
            }
        }

        /// <summary>
        /// Changes the color if the user clicked on the pixel
        /// </summary>
        private void ChangeColor(object? sender, EventArgs e)
        {
            // Checks whether what the user clicked was a PictureBox, if so then
            // it will change its color based on the currently selected color
            if(sender is PictureBox)
            {
                PictureBox pb = (PictureBox)sender!;
                pb.BackColor = pictureBoxCurrentColor.BackColor;
                saved = false;
            }
            // If it wasn't saved then the text will insert an asterix noting that the file is not saved yet
            if (!saved)
            {
                this.Text += " *";
            }
        }

        /// <summary>
        /// Selects the current color out of a select few colors
        /// </summary>
        private void SelectColor(object sender)
        {
            // Validates whether the user clicked on a Button, if so then it changes
            // the pictureBox holding the current color to the one the user clicked on
            if(sender is Button)
            {
                Button color = (Button)sender!;
                pictureBoxCurrentColor.BackColor = color.BackColor;
            }
        }

        /// <summary>
        /// Loads the file directly from the Level Editor (almost the same components of Form1's load event)
        /// </summary>
        private void LoadFile()
        {

            // Calls the clear map method to clear the map so it can create the new map
            ClearMap();

            // Opens the window file exlporer which will ask for a LEVEL file
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Title = "Read a level file.";
            openFile.Filter = "Level Files|*.level";

            // Occurs if the user inputs a LEVEL file
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                // Intializes an object which will read the file and intialize the
                // height, width, and the double array containing the ARGB values of all the pixels
                FileStream stream = File.OpenRead(openFile.FileName);
                StreamReader input = new StreamReader(stream);

                //file reading code goes here


                // Once done it will close the stream so that the process will close so
                // it can either load another file or save another file in the future
                input.Close();
            }
            title = "Level Editor - " + openFile.SafeFileName;
            this.Text = title;

            // Displays a MessageBox that the file was successfully loaded in
            DialogResult loadedMessage = MessageBox.Show("File loaded successfully", "File loaded",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Calls the Load Map method so that it can fill in the map with the appropiate
            // height and width of the window, map, and pixels as well as color of the pixels
            LoadMap();
        }
        
        private void SaveFile()
        {
            // Opens the file explorer which will ask for an exisiting file or the
            // user can type in a new name for the file to be saved in
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Title = "Save a level file.";
            saveFile.Filter = "Level Files|*.level";
            
            // Occurs whether the users provides a file to save the level in
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                // Intializes an object which will save the file and wriite the
                // height, width, and the individual values of the pixels in the file
                FileStream stream = File.OpenWrite(saveFile.FileName);
                StreamWriter output = new StreamWriter(stream);
                
              // file writing code goes here

                // Once done it will close the stream so that the process will close so
                // it can either load another file or save another file in the future
                output.Close();
            }
            // This sets the title to the same as before but without the
            // asterisk so that it denotes that the file was saved
            this.Text = this.Text.Substring(0, this.Text.Length-2);
            title = this.Text;
            saved = true;

            // Displays a MessageBox that the file was successfully saved
            DialogResult savedMessage = MessageBox.Show("File saved successfully", "File saved",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        /// <summary>
        /// This is the method which all the color selector buttons are 
        /// subscribed to which calls the select color method if clicked on
        /// </summary>
        private void buttonGreen_Click(object sender, EventArgs e)
        {
            SelectColor((Button)sender);
        }

        /// <summary>
        /// This is the method which the save button is subscribed to and calls the Save File method
        /// </summary>
        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        /// <summary>
        /// This is the method which the load button is subscribed to and calls the Load File method
        /// </summary>
        private void buttonLoad_Click(object sender, EventArgs e)
        {
            LoadFile();
        }

        /// <summary>
        /// Occurs when the user clicks the X button on the top left of the window
        /// </summary>
        private void LevelEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            // If the file is not saved then it will display a MessageBox asking the
            // user if they want to validate their chocie to quit without saving
            if (this.Text.Substring(this.Text.Length-1) == "*")
            {
                DialogResult unsavedChanges = MessageBox.Show(
                    "There are unsaved changes. Are you sure you want to quit?", "Unsaved changes",
               MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (unsavedChanges == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
