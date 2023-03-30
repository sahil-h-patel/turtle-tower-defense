using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LevelEditor
{
    public partial class Form1 : Form
    {
        private int wavesNum;
        private bool isEndless;
        private string errorMessages = "";

        /// <summary>
        /// Gets and sets the number of waves in a game
        /// </summary>
        public int WavesNum { get { return wavesNum; } set { wavesNum = value; } }

        /// <summary>
        /// Gets and sets whether current game is in endless mode
        /// </summary>
        public bool IsEndless { get { return isEndless; } set { isEndless = value; } }


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
            //ensures that user either has input wave numbers or enabled endless mode
            if (isEndless == false)
            {
                if (textBoxWaves.Text.Equals(""))
                {
                    errorMessages += "- Please either input the number of waves or enable endless mode.";
                }
                else
                {
                    //attempts to convert user input into an integer
                    try { wavesNum = int.Parse(textBoxWaves.Text); }
                    catch (Exception ex)
                    {
                        errorMessages += "- Please input an integer for the number of waves.\n";
                    }

                    //checks if the user-input number of waves is valid
                    if (wavesNum <= 0)
                    {
                        errorMessages += "- The number of waves need to be greater than 0.";
                    }
                }



                if (errorMessages.Length > 0)
                {
                    MessageBox.Show(errorMessages,
                        "Error creating map",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Error
                       );
                    errorMessages = "";
                }
                else
                {
                    LevelEditor editor = new LevelEditor(this, false, "Level Editor");
                    editor.ShowDialog();
                }


            }
            // If everything is valid then it will initialize the LevelEditor
            else
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

        /// <summary>
        /// disables waves text box once endless mode is turned on
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void isEndlessCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (isEndlessCheckBox.Checked)
            {
                textBoxWaves.Enabled = false;
                isEndless = true;
            }
            else
            {
                textBoxWaves.Enabled = true;
                isEndless = false;
            }

        }
    }
}