using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CountWordsInSentence
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TextBox.Text = "This is a statement, and so is this";
        }


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            CountWords();
        }

        private void CountWords()
        {
            string[] sentence = TextBox.Text.ToLower().Split(new char[] { ' ', '.', ',', ';' }, StringSplitOptions.RemoveEmptyEntries);
            var result = sentence.GroupBy(w => w).ToDictionary(w => w.Key, c => c.Count()).OrderByDescending(desc => desc.Value);

            ListBox.ItemsSource = result.ToList();
        }
    }
}
