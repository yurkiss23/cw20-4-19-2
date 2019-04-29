using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
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
        public string NameAdd { get; set; }
        public DateTime BirthAdd { get; set; }
        public string ImgUrlAdd { get; set; } = @"\Images\NoImage.jpg";
        public AddUserWindow()
        {
            InitializeComponent();
            imgUser.Source = new BitmapImage(new Uri(ImgUrlAdd, UriKind.Relative));
        }

        //private void LblFhoto_Click(object sender, RoutedEventArgs e)
        //{

        //}

        //private void BtnFhoto_Click(object sender, RoutedEventArgs e)
        //{

        //}

        private void BtnImg_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == true)
            {
                MessageBox.Show("if");
                txtImg.Text = ofd.FileName;
                _imgUser = new FileInfo(txtImg.Text);
                _imgUser.CopyTo($@"C:\Users\Public\Pictures\{txtName.Text}.jpg");
                ImgUrlAdd = ConfigurationManager.AppSettings["img"] + txtName.Text + ".jpg";
            }
            imgUser.Source = new BitmapImage(new Uri(ImgUrlAdd, UriKind.RelativeOrAbsolute));
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            NameAdd = txtName.Text;
            BirthAdd = dpbirthday.DisplayDate;
            this.Close();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            NameAdd = null;

            //BirthAdd = dpbirthday.DisplayDate;
            ImgUrlAdd = null;
            this.Close();
        }

        private void inputText(object sender, RoutedEventArgs e)
        {
            dpbirthday.IsEnabled = true;
            btnImg.IsEnabled = true;
            txtImg.IsEnabled = true;
            btnAdd.IsEnabled = true;
        }
    }
}
