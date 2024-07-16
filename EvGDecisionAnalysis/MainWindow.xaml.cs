using System;
using System.Windows;
using EvGDecisionAnalysis.Data;
using EvGDecisionAnalysis.Models;
using LiveCharts;
using LiveCharts.Wpf;

namespace EvGDecisionAnalysis
{
    public partial class MainWindow : Window
    {
        public SeriesCollection NPVValues { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            NPVValues = new SeriesCollection();
            DataContext = this;
        }

        public double BayesTheorem(double npve1, double npve2, double pe1, double pe2)
        {
            return (npve1 * pe1) + (npve2 * pe2);
        }

        private void btnResult_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double pe1 = pe1Input.Value;
                double npve1 = npve1Input.Value;
                double pe2 = pe2Input.Value;
                double npve2 = npve2Input.Value;

                double result = BayesTheorem(npve1, npve2, pe1, pe2);
                resultTextBlock.Text = $"Result: {result:F2}";

                //
                SaveResultsFile(npve1, npve2, pe1, pe2, result);
                //
                //SaveResultsDB(npve1, npve2, pe1, pe2, result);
            }
            catch (FormatException)
            {
                resultTextBlock.Text = "Please enter valid numeric values.";
            }
            //catch ()
            /*catch (Exception ex)
            {
                resultTextBlock.Text = $"An error occurred: {ex.Message}";
            }*/
        }

        public void SaveResultsFile(double npvE1, double pE1, double npvE2, double pE2, double calculatedNPV)
        {
            string result = $"NPV(E1): {npvE1}, P(E1): {pE1}, NPV(E2): {npvE2}, P(E2): {pE2}, Calculated NPV: {calculatedNPV}";
            System.IO.File.AppendAllText("NPVResults.txt", result + Environment.NewLine);
        }

        public void SaveResultsDB(double npvE1, double pE1, double npvE2, double pE2, double calculatedNPV)
        {
            using (var context = new AppDbContext())
            {
                var result = new NPVResult
                {
                    NPVE1 = npvE1,
                    PE1 = pE1,
                    NPVE2 = npvE2,
                    PE2 = pE2,
                    CalculatedNPV = calculatedNPV
                };
                context.NPVResults.Add(result);
                context.SaveChanges();
            }

        }
    }
}
