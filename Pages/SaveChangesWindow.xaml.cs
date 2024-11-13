using SuntoTexteditorExtensionWPF.Classes.Database;
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
using System.Windows.Shapes;

namespace SuntoTexteditorExtensionWPF.Pages
{
    /// <summary>
    /// Interaction logic for SaveChangesWindow.xaml
    /// </summary>
    public partial class SaveChangesWindow : Window
    {
        DatabaseManager databaseManager;
        Song song;

        public SaveChangesWindow(DatabaseManager _databaseManager, Song _song)
        {
            Owner = App.Current.MainWindow;
            databaseManager = _databaseManager;
            song = _song;
            InitializeComponent();
        }

        private void YesClicked(object sender, RoutedEventArgs e)
        {
            databaseManager.SaveSong(song);
        }

        private void NoClicked(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}
