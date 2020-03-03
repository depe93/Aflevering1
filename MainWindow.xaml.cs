using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfOpg
{
    public partial class MainWindow : Window
    {
        private string filename;
        private ObservableCollection<User> users = new ObservableCollection<User>();
        public MainWindow()
        {
            InitializeComponent();
            UserList.ItemsSource = users;
            outerGrid.DataContext = users;
        }

        private void miOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() != true)
                return;

            filename = openFileDialog.FileName;
            
            
            
            using (var file = new StreamReader(filename))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    var splitLine = line.Split(';');
                    users.Add(new User
                    {
                        Name = splitLine[0],
                        Age = int.Parse(splitLine[1]),
                        Score = int.Parse(splitLine[3]),
                        Id = int.Parse(splitLine[2])
                    });
                }
                UserList.ItemsSource = users;
            }
            userCount.Text = $"Users: {users.Count}";
            statusText.Text = $"File loaded: {DateTime.Now.ToString()}";
        }

        private void NameField_TextChanged(object sender, TextChangedEventArgs e)
        {
            UserList.Items.Refresh();
        }
    }
}
