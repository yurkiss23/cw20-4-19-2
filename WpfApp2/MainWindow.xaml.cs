﻿using System;
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
            //userList = new List<User>(_context.Users.Select(u => new User()
            //{
            //    Id = u.Id,
            //    Name = u.Name,
            //    Birthday = u.Birthday,
            //    ImageUrl = u.ImageUrl
            //}));
            //userList.Add(new User() { Id = 1, Name = "John Doe", Birthday = new DateTime(1971, 7, 23) });
            //userList.Add(new User() { Id = 2, Name = "Jane Doe", Birthday = new DateTime(1974, 1, 17),
            //    ImageUrl = "https://vasuluna2x.files.wordpress.com/2012/04/yak-zminiti-oval-oblichchya1.jpg" });
            //userList.Add(new User() { Id = 3, Name = "Sammy Doe", Birthday = new DateTime(1991, 9, 2) });

            //DG.ItemsSource = userList;
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

        }

        private void btnChangeUser_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDeleteUser_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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
