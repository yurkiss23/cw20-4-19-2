using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using WpfApp2.Entities;
using WpfApp2.Windows;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private EFContext _context;
        public List<User> userList = null;
        public MainWindow()
        {
            InitializeComponent();
            _context = new EFContext();
            DG_Load();
        }
        public void DG_Load()
        {
            userList = new List<User>(_context.Users.Select(u => new User()
            {
                Id = u.Id,
                Name = u.Name,
                Birthday = u.Birthday,
                ImageUrl = u.ImageUrl
            }));

            DG.ItemsSource = userList;
        }

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            AddUserWindow adduser = new AddUserWindow();
            adduser.ShowDialog();
            _context.Users.Add(new EFUser()
            {
                Name = adduser.NameAdd,
                Birthday = adduser.BirthAdd,
                ImageUrl = adduser.ImgUrlAdd
            });
            _context.SaveChanges();
            DG_Load();
        }

        private void btnChangeUser_Click(object sender, RoutedEventArgs e)
        {
            EFUser cng = null;
            if (DG.SelectedItem != null)
            {
                EFUser select = DG.SelectedItem as User;
                AddUserWindow cnguser = new AddUserWindow();
                cnguser.txtName.Text = select.Name;
                cnguser.dpbirthday.SelectedDate = select.Birthday;
                cnguser.txtImg.Text = select.ImageUrl;
                cnguser.ShowDialog();
                cng = _context.Users.Where(u => u.Id == select.Id).First();
                cng.Name = cnguser.NameAdd;
                cng.Birthday = cnguser.BirthAdd;
                cng.ImageUrl = cnguser.ImgUrlAdd;
                _context.SaveChanges();
                DG_Load();
            }
        }

        private void btnDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            if (DG.SelectedItem != null)
            {
                EFUser select = DG.SelectedItem as User;
                _context.Users.Remove(_context.Users.Where(u => u.Id == select.Id).First());
                _context.SaveChanges();
                DG_Load();
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DG_Select(object sender, SelectionChangedEventArgs e)
        {
            btnChangeUser.IsEnabled = true;
            btnDeleteUser.IsEnabled = true;
        }
    }

    public class User : INotifyPropertyChanged
    {
        public int Id { get; set; }

        private string name;
        public string Name
        {
            get { return this.name; }
            set
            {
                if (this.name != value)
                {
                    this.name = value;
                    this.NotifyPropertyChanged("Name");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        private DateTime birthday;
        public DateTime Birthday
        {
            get { return this.birthday; }
            set
            {
                if (this.birthday != value)
                {
                    this.birthday = value;
                    this.NotifyPropertyChanged("Birthday");
                }
            }
        }

        public string ImageUrl { get; set; }
    }
}
