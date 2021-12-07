using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
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
using FindAnnouncements.Models;
using FindAnnouncements.Stores;
using FindAnnouncements.ViewModel;

namespace FindAnnouncements
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AnnouncementService.GetAnnouncements("true", "PublishDate");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }
    }
}
