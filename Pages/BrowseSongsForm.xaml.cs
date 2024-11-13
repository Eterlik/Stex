using SuntoTexteditorExtensionWPF.Classes.Database;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;


namespace SuntoTexteditorExtensionWPF.Pages
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class BrowseSongsForm : Window
    {
        public string selectedSong = "";
        private DatabaseManager databaseManager;

        public BrowseSongsForm(DatabaseManager _databaseManager, string _topMassage)
        {
            Owner = App.Current.MainWindow;
            Title = _topMassage;
            databaseManager = _databaseManager;

            InitializeComponent();

            if (_topMassage == "Select a song to delete")
                ConfirmButton.Content = "Delete";

            UpdaeListView();
        }

        private void SongSelected(object sender, SelectionChangedEventArgs e)
        {
            selectedSong = ((sender as ListBox)?.SelectedItem as ListBoxItem)?.Content.ToString() ?? "";
        }

        private void UpdaeListView()
        {
            List<Song> songs;
            songsListBox.Items.Clear();

            songs = databaseManager.GetAllSongs(SearchTextBox.Text);

            foreach (Song song in songs)
            {
                ListViewItem item = new ListViewItem();
                item.Content = song.Title;
                songsListBox.Items.Add(item);
            }
        }

        private void OkButtonClicked(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void CancelButtonClicked(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void OnSearchChanged(object sender, TextChangedEventArgs e)
        {
            UpdaeListView();
        }
    }
}
