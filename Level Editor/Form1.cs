using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LevelEditor
{
    public partial class Form1 : Form
    {
        private int height;
        private int width;
        private int[,] pixels;

        /// <summary>
        /// Gets and sets the height of the map in pixels
        /// </summary>
        public int MapHeight { get { return height; } set { height = value; } }

        /// <summary>
        /// Gets and sets the width of the map in pixels
        /// </summary>
        public int MapWidth { get { return width; } set { width = value; } }

        /// <summary>
        /// Get and sets the double array of the ARGB values of the pixels
        /// </summary>
        public int[,] Pixels { get { return pixels; } set { pixels = value; } }


        /// <summary>
        /// Initializes the form in the window
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// Checks whether the incoming values are valid according to the restrictions set
        /// </summary>
        /// <param name="isBeingLoaded"> If a map is being loaded this is true </param>
        /// <returns>true or false whether the values are valid</returns>
        private bool valuesAreValid(bool isBeingLoaded)
        {
            List<string> errorList = new List<string>();
            bool valid = true;
            bool parsed = true;

            if (!isBeingLoaded)
            {
                // Parses the values in the textBox if possible but will add
                // the error to a list which will be displayed in a MessageBox later on
                if (!int.TryParse(textBoxHeight.Text, out height))
                {
                    errorList.Add("- Invalid value for height.\n");
                    valid = false;
                    parsed = false;
                }
                if (!int.TryParse(textBoxWidth.Text, out width))
                {
                    errorList.Add("- Invalid value for width.\n");
                    valid = false;
                    parsed = false;
                }
            }
            
            // Checks whether the width and height are within the
            // appropiate bounds and if it is parsed correctly
            if (width < 10 && parsed)
            {
                errorList.Add("- Width is too small. Minimum is 10.\n");
                valid = false;
            }
            if (height < 10 && parsed)
            {
                errorList.Add("- Height is too small. Height is 10.\n");
                valid = false;
            }
            if (width > 30)
            {
                errorList.Add("- Width is too big. Maximum is 30.\n");
                valid = false;
            }
            if (height > 30)
            {
                errorList.Add("- Height is too big. Maximum is 30.\n");
                valid = false;
            }

            // Concetantes all the errors found in one string which will be displayed in the MessageBox
            string errorString = null!;
            foreach (string errors in errorList)
            {
                errorString += errors;
            }

            if (!valid)
            {
                DialogResult errorMessage = MessageBox.Show(errorString, "Error creating map",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return valid;
        }

        /// <summary>
        /// This method occurs when the Create button is clicked
        /// </summary>
        private void buttonCreate_Click(object sender, EventArgs e)
        {
            // If the values of height and width are valid then it will initialize the LevelEditor
            if (valuesAreValid(false))
            {
                LevelEditor editor = new LevelEditor(this, false, "Level Editor");
                editor.ShowDialog();
            }
        }

        /// <summary>
        /// This method occurs when the Load button is clicked
        /// </summary>
        private void buttonLoad_Click(object sender, EventArgs e)
        {
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

                // Declares the line variable which will contain the string of the line that was currently read
                // as well as a counter needed to iterate through the double array accordingly to get the correct
                // ARGB value for the correct pixel
                string line = null!;
                int counterHeight = 0;

                while ((line = input.ReadLine()!) != null)
                {

                    // Extracts the height from the file and initializes the height
                    if (line.StartsWith("Height: "))
                    {
                        height = Convert.ToInt32(line.Substring(8));
                    }
                    // Extracts the width from the file and initializes the width
                    if (line.StartsWith("Width: "))
                    {
                        width = Convert.ToInt32(line.Substring(7));
                        pixels = new int[height, width];
                    }
                    // All the possible ARGB values are negative so if the line
                    // starts with a negative then we know its an integer
                    else if(line.StartsWith("-"))
                    {
                        // Gets the current line, which contains the row of pixels and splits them into individual pixels
                        string[] pixelArr = line.Split(',');
                        
                            // Stores the ARGB value in the pixels double array
                            for(int counterWidth = 0; counterWidth < pixels.GetLength(1); counterWidth++)
                            {
                                pixels[counterHeight, counterWidth] = Convert.ToInt32(pixelArr[counterWidth]);
                            }
                            counterHeight++;
                        
                    }
                }
                // Once done it will close the stream so that the process will close so
                // it can either load another file or save another file in the future
                input.Close();
                string title = "Level Editor - " + openFile.SafeFileName;

                // Displays a MessageBox that the file was successfully loaded in
                DialogResult loadedMessage = MessageBox.Show("File loaded successfully", "File loaded",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // The values of the height and width are checked which will
                // then verify that we can initialize the Level Editor
                if (valuesAreValid(true))
                {
                    LevelEditor editor = new LevelEditor(this, true, title);
                    editor.ShowDialog();
                }
            }   
        }
    }
}