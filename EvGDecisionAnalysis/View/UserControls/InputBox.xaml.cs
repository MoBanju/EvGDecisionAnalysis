using System.Windows.Controls;

namespace EvGDecisionAnalysis.View.UserControls
{
    public partial class InputBox : UserControl
    {
        public InputBox()
        {
            InitializeComponent();
        }

        private string label;
        public string Label
        {
            get { return label; }
            set
            {
                label = value;
                tbLabel.Text = label;
            }
        }

        public double Value
        {
            get { return double.TryParse(valInput.Text, out double result) ? result : 0; }
            set { valInput.Text = value.ToString(); }
        }
    }
}
