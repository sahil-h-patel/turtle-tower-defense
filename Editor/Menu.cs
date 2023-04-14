namespace Editor
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void openWaveEditorButton_Click(object sender, EventArgs e)
        {
            WaveEditor waveEditor = new WaveEditor(this);
            waveEditor.ShowDialog();
        }

        private void openPathEditorButton_Click(object sender, EventArgs e)
        {
            PathEditor pathEditor = new PathEditor(this);
            pathEditor.ShowDialog();
        }
    }
}
