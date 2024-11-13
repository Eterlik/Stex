using SuntoTexteditorExtensionWPF.Classes.Database;
using SuntoTexteditorExtensionWPF.Utility.ExtensionClasses;
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
    /// Interaction logic for DisplayLyricsEditor.xaml
    /// </summary>
    public partial class DisplayLyricsEditor : Window
    {
        DatabaseManager databaseManager;
        Song song;
        public DisplayLyricsEditor(DatabaseManager _databaseManager, Song _song)
        {
            Owner = App.Current.MainWindow;
            databaseManager = _databaseManager;
            song = _song;
            InitializeComponent();
            LoadLyrics();
        }

        private void LoadLyrics()
        {
            string lyrics = song.DisplayLyrics != "" ? song.DisplayLyrics : song.Lyrics;
            DisplayLyricsTextBox.Text = lyrics;
        }

        private void ReloadLyrics()
        {
            DisplayLyricsTextBox.Text = song.Lyrics;
        }

        private void ReloadLyricsButtonClicked(object sender, RoutedEventArgs e)
        {
            ReloadLyrics();
        }

        

        private void ApplyButtonClicked(object sender, RoutedEventArgs e)
        {
            if(RemoveTagsCheckBox.IsChecked ?? false)
                RemoveTags();
            if (RemoveBracketsCheckBox.IsChecked ?? false)
                RemoveBrackets();
            if (RemovePunctuationCheckBox.IsChecked ?? false)
                RemovePunktuation();
            if (LowerCaseCheckBox.IsChecked ?? false)
                LowerCase();
            if (FirstLetterCheckBox.IsChecked ?? false)
                FirstLetterBig();
        }

        private void RemoveTags()
        {
            DisplayLyricsTextBox.Text = DisplayLyricsTextBox.Text.RemoveInbetween("[", "]");
        }

        private void RemoveBrackets()
        {
            DisplayLyricsTextBox.Text = DisplayLyricsTextBox.Text.Replace("(", "").Replace(")", "");
            DisplayLyricsTextBox.Text = DisplayLyricsTextBox.Text.Replace("{", "").Replace("}", "");
        }

        private void RemovePunktuation()
        {
            DisplayLyricsTextBox.Text = DisplayLyricsTextBox.Text.Replace(".", "");
            DisplayLyricsTextBox.Text = DisplayLyricsTextBox.Text.Replace(",", "");
            DisplayLyricsTextBox.Text = DisplayLyricsTextBox.Text.Replace("!", "");
            DisplayLyricsTextBox.Text = DisplayLyricsTextBox.Text.Replace("?", "");
            DisplayLyricsTextBox.Text = DisplayLyricsTextBox.Text.Replace("¿", "");
            DisplayLyricsTextBox.Text = DisplayLyricsTextBox.Text.Replace("/", "");
        }

        private void LowerCase()
        {
            DisplayLyricsTextBox.Text = DisplayLyricsTextBox.Text.ToLower();
        }

        private void FirstLetterBig()
        {
            string text = "";
            for(int i = 0; i < DisplayLyricsTextBox.LineCount; i++)
            {
                text += DisplayLyricsTextBox.GetLineText(i).FirstCharToUpper();
            }
            DisplayLyricsTextBox.Text = text;
        }

        private void SaveButtonClicked(object sender, RoutedEventArgs e)
        {
            song.DisplayLyrics = DisplayLyricsTextBox.Text;
            databaseManager.SaveSong(song);
            DialogResult = true;
        }

        private void CancelButtonClicked(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
}
