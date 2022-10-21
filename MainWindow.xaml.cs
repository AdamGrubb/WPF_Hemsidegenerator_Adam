using System;
using System.Collections.Generic;
using System.IO;
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
using Hemsidegeneratorn;

namespace Hemsidegeneratorn
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] messagesToClass;
        string nameOfClass;
        string[] kurser;
        string htmlKoden;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void loadFile_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "Document"; // Default file name
            dlg.DefaultExt = ".html"; // Default file extension
            dlg.Filter = "HTML document (.html)|*.html"; // Filter files by ex
                                                        // Show open file dialog box
            Nullable<bool> result = dlg.ShowDialog();
            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                string filename = dlg.FileName;
            }
          this.htmlKoden= File.ReadAllText(dlg.FileName);
            previewPage.Text=htmlKoden;
        }

        private void generatHtml_Click(object sender, RoutedEventArgs e)
        {
            nameOfClass = className.Text;
            messagesToClass= inputMessages.Text.Split("\n");
            kurser = inputCourses.Text.Split("\n");
            WebsiteGenerator testHemsida = new WebsiteGenerator(nameOfClass, messagesToClass, kurser);
            testHemsida.PrintPage();
            this.htmlKoden= testHemsida.readytoPrint;
            previewPage.Text = htmlKoden;
        }

        private void printToFile_Click(object sender, RoutedEventArgs e)
        {
            // Configure save file dialog box
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Document"; // Default file name
            dlg.DefaultExt = ".html"; // Default file extension
            dlg.Filter = "HTML document (.html)|*.html"; // Filter files by ex
                                                        // Show save file dialog box
            Nullable<bool> result = dlg.ShowDialog();
            // Process save file dialog box results
            if (result == true)
            {
                // Save document
                string filename = dlg.FileName;
            }
            File.AppendAllText(dlg.FileName, previewPage.Text);
        }
    }
}
