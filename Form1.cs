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
        /// This method occurs when the Create button is clicked
        /// </summary>
        private void buttonCreate_Click(object sender, EventArgs e)
        {
            // If the values of height and width are valid then it will initialize the LevelEditor
                LevelEditor editor = new LevelEditor(this, false, "Level Editor");
                editor.ShowDialog();
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

                   //file reader code goes here
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
                    LevelEditor editor = new LevelEditor(this, true, title);
                    editor.ShowDialog();
            }   
        }
    }
}