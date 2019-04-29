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
using System.Windows.Shapes;

namespace WpfApp2.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddUserWindow.xaml
    /// </summary>
    public partial class AddUserWindow : Window
    {
        private FileInfo _imgUser;
        public AddUserWindow()
        {
            InitializeComponent();
        }

        private void LblFhoto_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnFhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            txtImg.Text = ofd.FileName;
            _imgUser = new FileInfo(txtImg.Text).CopyTo(@"C:\Users\yurkiss\source\repos\cw20-4-19-2\WpfApp2\Images");
            //imgUser
        }
    }
}
