using SuntoTexteditorExtensionWPF.Classes.Database;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using Style = SuntoTexteditorExtensionWPF.Classes.Database.Style;

namespace SuntoTexteditorExtensionWPF.Pages
{
    /// <summary>
    /// Interaction logic for TagAndStyleWindow.xaml
    /// </summary>
    public partial class TagAndStyleWindow : Window
    {
        private DatabaseManager databaseManager;
        private string content;
        private List<Autocompleteable> items = new List<Autocompleteable>();
        //private List<Style> styles = new List<Style>();

        public TagAndStyleWindow(DatabaseManager _databaseManager, string _content)
        {
            Owner = App.Current.MainWindow;
            content = _content;
            databaseManager = _databaseManager;
            if (_content == "Tags")
            {
                Title = "Tag Manager";
            }
            else
            {
                Title = "Style Manager";
            }

            InitializeComponent();
            UpdateListView();
        }

        private void UpdateListView()
        {
            items.Clear();
            ItemListBox.Items.Clear();
            if (content == "Tags")
            {
                if (SearchTextBox.Text != "")
                    items.AddRange(databaseManager.GetAllTags(SearchTextBox.Text));
                else 
                    items.AddRange(databaseManager.GetAllTags());
            }
            else
            {
                if (SearchTextBox.Text != "")
                    items.AddRange(databaseManager.GetAllStyles(SearchTextBox.Text));
                else
                    items.AddRange(databaseManager.GetAllStyles());
            }
            
            foreach (Autocompleteable item in items)
            {
                //Debug.WriteLine(item.Name);
                ItemListBox.Items.Add(item.Name);
            }

        }

        private void ListBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectionTextBox.Text = (sender as ListBox)?.SelectedItem as string;
        }

        private void AddButtonClicked(object sender, RoutedEventArgs e)
        {
            string item = SelectionTextBox.Text;
            item = item.Trim();

            if (content == "Tags")
            {
                if (!item.StartsWith("["))
                    item = "[" + item;

                if (!item.EndsWith("]"))
                    item = "]" + item;
                databaseManager.AddTag(item);
            }
            else
                databaseManager.AddStyle(item);

            UpdateListView();
        }

        private void DeleteButtonClicked(object sender, RoutedEventArgs e)
        {
            if (ItemListBox.SelectedItem == null)
                return;
            
            if (content == "Tags")
                databaseManager.DeleteTag(ItemListBox.SelectedItem as string);
            else
                databaseManager.DeleteStyle(ItemListBox.SelectedItem as string);
            UpdateListView();
        }

        private void OnSearchChanged(object sender, TextChangedEventArgs e)
        {
            if(IsLoaded)
                UpdateListView();
        }
        private void CloseButtonClicked(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

    }
}
