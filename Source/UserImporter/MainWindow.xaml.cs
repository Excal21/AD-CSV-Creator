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

namespace UserImporter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<string> nevek = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                //InitialDirectory = @"D:\",
                Title = "Browse Text Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "txt",
                Filter = "txt files (*.txt)|*.txt",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == true)
            {
                string filename = openFileDialog1.FileName;
                listNevek.Items.Clear();
                nevek = File.ReadAllLines(filename).ToList();
                nevek.ForEach(i => listNevek.Items.Add(i));
                
            }
        }

        private void tbDomains_GotFocus(object sender, RoutedEventArgs e)
        {
            tbDomains.Text = "";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            List<string> outstream = new List<string>();
            if (rbUser.IsChecked == true)
            {
                outstream.Add("DN,objectClass,sAMAccountName,userPrincipalName,givenName,SN,displayName");
                string firstname;
                string lastname;
                string[] domainek = tbDomains.Text.Split('.');
                string suffix = domainek.Last();
                string[] ouk = tbOU.Text.Split('<');

                foreach (var item in nevek)
                {
                    string[] splitted = item.Split(' ');
                    
                    firstname = splitted[0];
                    lastname = splitted[1];
                    
                    string bejegyzes = (char)34 + "cn=" + item;
                    foreach (var ou in ouk)
                    {
                        bejegyzes += ",ou=" + ou;
                    }
                    foreach (var domain in domainek)
                    {
                        bejegyzes += ",dc=" + domain;
                    }

                    bejegyzes += (char)34;
                    bejegyzes += ",user,";
                    bejegyzes += ConvertToASCII(firstname.ToLower()) + "." + ConvertToASCII(lastname.ToLower());
                    bejegyzes += "," + ConvertToASCII(firstname.ToLower()) + "." + ConvertToASCII(lastname.ToLower())+"@";

                    for (int i = 0; i < domainek.Length-1; i++)
                    {
                        bejegyzes += domainek[i] + ".";
                    }
                    bejegyzes += suffix;
                    bejegyzes += "," + (rbMagyar.IsChecked == true ? lastname : firstname) + "," + (rbMagyar.IsChecked == true ? firstname : lastname);
                    bejegyzes += "," + firstname + " " + lastname;
                    outstream.Add(bejegyzes);
                }
                
            }

            else
            {
                outstream.Add("DN,objectClass,sAMAccountName");
                string[] domainek = tbDomains.Text.Split('.');
                string suffix = domainek.Last();
                string[] ouk = tbOU.Text.Split('<');

                foreach (var item in nevek)
                {
                    

                    string bejegyzes = (char)34 + "cn=" + item;
                    foreach (var ou in ouk)
                    {
                        bejegyzes += ",ou=" + ou;
                    }
                    foreach (var domain in domainek)
                    {
                        bejegyzes += ",dc=" + domain;
                    }

                    bejegyzes += (char)34;
                    bejegyzes += ",computer,";
                    bejegyzes += item;

                    outstream.Add(bejegyzes);
                }
            }


            try
            {
                File.WriteAllLines("import.csv", outstream, Encoding.Unicode);
                MessageBox.Show("Fájl sikeresen létrehozva!", "Sikeres mentés", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Hiba a fájl elkészítésekor!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void TextBox_TextChanged(object sender, RoutedEventArgs e)
        {
            tbOU.Text = "";
        }

        private string ConvertToASCII(string lowered_input)
        {
            lowered_input = lowered_input.Replace('á', 'a');
            lowered_input = lowered_input.Replace('é', 'e');
            lowered_input = lowered_input.Replace('í', 'i');
            lowered_input = lowered_input.Replace('ó', 'o');
            lowered_input = lowered_input.Replace('ö', 'o');
            lowered_input = lowered_input.Replace('ő', 'o');
            lowered_input = lowered_input.Replace('ü', 'u');
            lowered_input = lowered_input.Replace('ű', 'u');
            lowered_input = lowered_input.Replace("'", "");
            return lowered_input;
        }
    }
}
