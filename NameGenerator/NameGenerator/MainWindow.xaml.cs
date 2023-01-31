using Microsoft.Win32;
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

namespace NameGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        List<string> lastNames = new List<string>(); 
        List<string> firstNames = new List<string>();

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == true)
            {
                foreach (var nev in File.ReadAllLines(ofd.FileName))
                {
                    firstNames.Add(nev);
                }
                lbFirstnames.ItemsSource = firstNames;
            }
        }

        private void btnLoadLast_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == true)
            {
                foreach (var nev in File.ReadAllLines(ofd.FileName))
                {
                    lastNames.Add(nev);
                }
                lbLastnames.ItemsSource = lastNames;
            }
        }

        int FirstnameIndex;
        int LastnameIndex;

        private void btnGenerateNames_Click(object sender, RoutedEventArgs e)
        {
            Random r = new Random();

            FirstnameIndex = r.Next(lbFirstnames.Items.Count);
            LastnameIndex = r.Next(lbLastnames.Items.Count);

            lbFullnames.Items.Add(lbFirstnames.Items[FirstnameIndex].ToString() + " " + lbLastnames.Items[LastnameIndex].ToString());
            lbFirstnames.SelectedItem = lbFirstnames.Items[FirstnameIndex];
            lbLastnames.SelectedItem = lbLastnames.Items[LastnameIndex];
        }                
    }
}
