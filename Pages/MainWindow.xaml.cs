using SuntoTexteditorExtensionWPF.Classes.Database;
using SuntoTexteditorExtensionWPF.Pages;
using SuntoTexteditorExtensionWPF.Utility.ExtensionClasses;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Input;
using Style = SuntoTexteditorExtensionWPF.Classes.Database.Style;


namespace SuntoTexteditorExtensionWPF.Pages
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DatabaseManager databaseManager = new DatabaseManager();
        private bool wasArrowKeyPressed = false;
        private bool isDirty = false;

        public MainWindow()
        {
            InitializeComponent();
            isDirty = false;
        }

        

        private void titelChanged(object sender, TextChangedEventArgs e)
        {
            if(titleCharCountLabel != null)
                titleCharCountLabel.Content = titleTextBox.Text.Length.ToString() + " / 80";
            isDirty = true;
        }


        //AUTOCOMPLETE!!!!!!

        private void lyricsChanged(object sender, TextChangedEventArgs e)
        {
            if (lyricsCharCountLabel != null)
            {
                //new line counts as 2 Characters so we need to replace them for the count
                string lyricsWithoutNewLines = lyricsTextBox.GetText().Replace(Environment.NewLine, " ");
                lyricsCharCountLabel.Content = (lyricsWithoutNewLines.Length - 1).ToString() + " / 3000";
            }
            UpdateAutocomplete(lyricsTextBox);
            isDirty = true;
        }

        private void stylesChanged(object sender, TextChangedEventArgs e)
        {
            if (stylesCharCountLabel != null)
                stylesCharCountLabel.Content = stylesTextBox.GetText().Length.ToString() + " / 120";
            UpdateAutocomplete(stylesTextBox);
            isDirty = true;
        }

        private void excludedStylesChanged(object sender, TextChangedEventArgs e)
        {
            if (excludedStylesCharCountLabel != null)
                excludedStylesCharCountLabel.Content = excludedStylesTextBox.GetText().Length.ToString() + " / 120";
            UpdateAutocomplete(excludedStylesTextBox);
            isDirty = true;
        }

        private void UpdateAutocomplete(RichTextBox _richTextbox)
        {
            if (!IsLoaded)
                return;

            Popup popup;
            ListView popupListView;

            // Style
            if (_richTextbox.Name == stylesTextBox.Name)
            {
                popup = stylesPopup;
                popupListView = stylesPopupList;
            }
            //Excluded Style
            else if (_richTextbox.Name == excludedStylesTextBox.Name)
            {
                popup = excludedStylesPopup;
                popupListView = excludedStylesPopupList;
            }
            //Lyrics
            else
            {
                popup = lyricsPopup;
                popupListView = lyricsPopupList;
            }

            string wordAtCaret = _richTextbox.GetWordAtCaret();

            List<string> styleList = FilterListForPopUp(popupListView, wordAtCaret);
            UpdatePopupItems(popupListView, styleList, wordAtCaret);
            UpdatePopupPosition(_richTextbox, popup);

        }

        private List<string> FilterListForPopUp(ListView _PopupListView, string _wordAtCaret)
        {
            List<string> popupItems = new List<string>();
            if(_PopupListView.Name == stylesPopupList.Name || _PopupListView.Name == excludedStylesPopupList.Name)
            {
                List<Style> styles = databaseManager.GetAllStyles(_wordAtCaret);
                foreach (Style style in styles)
                {
                    popupItems.Add(style.Name.ToString());
                }
            }

            if (_PopupListView.Name == lyricsPopupList.Name)
            {
                List<Tag> tags = databaseManager.GetAllTags(_wordAtCaret);
                foreach (Tag tag in tags)
                {
                    popupItems.Add(tag.Name.ToString());
                }
            }
            return popupItems;
        }

        private void UpdatePopupItems(ListView _popupListView,List<string> items, string _wordAtCaret)
        {
            EmptyPopupLists();

            foreach (string item in items)
            {
                if(item != _wordAtCaret)
                    _popupListView.Items.Add(item);
            }
        }

        private void UpdatePopupPosition(RichTextBox _richTextBox ,Popup _popup)
        {

            Point point = _richTextBox.GetWordStartPosition();
            _popup.HorizontalOffset = point.X - Application.Current.MainWindow.Left - 10;
            _popup.VerticalOffset = point.Y - Application.Current.MainWindow.Top - 50;
        }

        private void AutoCompleteSelected(object sender, SelectionChangedEventArgs e)
        {
            AutocompleteSelection((ListView)sender);
        }

        private void AutocompleteSelection(ListView listView)
        {
            if(wasArrowKeyPressed)
            {
                wasArrowKeyPressed = false;
                return;
            }

            RichTextBox richTextBox;
            bool ignoreSpace = false;

            if (listView.Name == stylesPopupList.Name)
            {
                richTextBox = stylesTextBox;
                ignoreSpace = true;
            }
            else if (listView.Name == excludedStylesPopupList.Name)
            {
                richTextBox = excludedStylesTextBox;
                ignoreSpace = true;
            }
            else
            {
                richTextBox = lyricsTextBox;
            }

            if (listView.SelectedItems.Count > 0)
            {

                richTextBox.ReplaceWordAtCaret(listView.SelectedItem.ToString(), ignoreSpace);
            }
        }

        private void AutoCompleteKeyPressed(object sender, KeyEventArgs e)
        {
            ListView popupListView = null;
            if (lyricsPopupList.HasItems)
                popupListView = lyricsPopupList;
            else if (stylesPopupList.HasItems)
                popupListView = stylesPopupList;
            else if (excludedStylesPopupList.HasItems)
                popupListView = excludedStylesPopupList;

            ScrollViewer scrollViewer = ListViewExtensionMethods.GetScrollViewer(popupListView) as ScrollViewer;

            if (e.Key == Key.Down && popupListView != null)
            {
                wasArrowKeyPressed = true;
                if (popupListView.SelectedIndex +1  < popupListView.Items.Count)
                {
                    popupListView.SelectedIndex++;
                    if (scrollViewer != null && popupListView.SelectedIndex > 3)
                    {
                        scrollViewer.ScrollToVerticalOffset(popupListView.SelectedIndex - 3);
                    }
                }
                else // end reached
                {
                    popupListView.SelectedIndex = 0;
                    if (scrollViewer != null)
                    {
                        scrollViewer.ScrollToVerticalOffset(0);
                    }

                }
                e.Handled = true;
            }
            else if (e.Key == Key.Up && popupListView != null)
            {
                wasArrowKeyPressed = true;
                if (popupListView.SelectedIndex > 0)
                {
                    popupListView.SelectedIndex--;
                    if (scrollViewer != null && popupListView.SelectedIndex < popupListView.Items.Count - 4)
                    {
                        scrollViewer.ScrollToVerticalOffset(popupListView.SelectedIndex - 3);
                    }
                }
                else //top reached
                { 
                    popupListView.SelectedIndex = popupListView.Items.Count - 1;
                    if (scrollViewer != null)
                    {
                        scrollViewer.ScrollToEnd();
                    }

                }
                e.Handled = true;
            }
            else if(e.Key == Key.Return && popupListView != null)
            {
                e.Handled = true;
                //wasArrowKeyPressed = true;
                AutocompleteSelection(popupListView);
            }
        }


        //SIDE BUTTONS!!!!!

        private void BracketsClicked(object sender, RoutedEventArgs e)
        {
            if (lyricsTextBox.Selection.Text == "")
                return;

            string selectedText = lyricsTextBox.Selection.Text;
            if (selectedText.StartsWith("(") && selectedText.EndsWith(")"))  //Remove Brackets
            {
                lyricsTextBox.Selection.Text = selectedText.Replace("(", "").Replace(")","");
                return;
            }

            if(!selectedText.StartsWith("(")) //Add brackets at the beginning if missing
                selectedText = "(" + selectedText;

            if(!selectedText.EndsWith(")"))  //Add brackets at the end if missing
                selectedText = selectedText + ")";

            lyricsTextBox.Selection.Text = selectedText;
        }

        private void UpperLowerCaseClicked(object sender, RoutedEventArgs e)
        {
            string selectedText = lyricsTextBox.Selection.Text;
            if(IsAllUpper(selectedText))
                selectedText = selectedText.ToLower();
            else
                selectedText = selectedText.ToUpper();

            lyricsTextBox.Selection.Text = selectedText;
        }

        bool IsAllUpper(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsLetter(input[i]) && !Char.IsUpper(input[i]))
                    return false;
            }
            return true;
        }


        //MENU BUTTONS!!!!

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string lyrics = new TextRange(lyricsTextBox.Document.ContentStart, lyricsTextBox.Document.ContentEnd).Text;

            Song song = TextFieldsToSong();
            databaseManager.SaveSong(song);

            isDirty = false;
            Debug.WriteLine("SAVED!!");
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            Song song = TextFieldsToSong();
            bool? result = true;
            if (isDirty)
            {
                SaveChangesWindow saveChangesWindow = new SaveChangesWindow(databaseManager, song);
                result = saveChangesWindow.ShowDialog();
                isDirty = false;
            }

            string lyrics = new TextRange(lyricsTextBox.Document.ContentStart, lyricsTextBox.Document.ContentEnd).Text;

            BrowseSongsForm browseForm = new BrowseSongsForm(databaseManager, "Select a song to load");

            result = browseForm.ShowDialog();

            if (result == true)
            {

                Debug.WriteLine(browseForm.selectedSong);
                song = databaseManager.LoadSong(browseForm.selectedSong);

                //Fill Textfields
                titleTextBox.Text = song.Title;
                stylesTextBox.SetText(song.Styles);
                excludedStylesTextBox.SetText(song.ExcludedStyles);
                lyricsTextBox.SetText(song.Lyrics);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            string lyrics = new TextRange(lyricsTextBox.Document.ContentStart, lyricsTextBox.Document.ContentEnd).Text;

            BrowseSongsForm browseForm = new BrowseSongsForm(databaseManager, "Select a song to delete");

            bool? result = browseForm.ShowDialog();
            Debug.WriteLine("result: " + result);

            if (result == true)
            {

                Debug.WriteLine(browseForm.selectedSong);
                databaseManager.DeleteSong(browseForm.selectedSong);
            }
        }

        private void tagsButton_Click(object sender, RoutedEventArgs e)
        {
            TagAndStyleWindow browseForm = new TagAndStyleWindow(databaseManager, "Tags");
            bool? result = browseForm.ShowDialog();
        }

        private void stylesButton_Click(object sender, RoutedEventArgs e)
        {
            TagAndStyleWindow browseForm = new TagAndStyleWindow(databaseManager, "Styles");
            bool? result = browseForm.ShowDialog();
        }

        private void displyLyricsButton_Click(object sender, RoutedEventArgs e)
        {
            Song song = TextFieldsToSong();
            bool? result;
            if (isDirty)
            {
                SaveChangesWindow saveChangesWindow = new SaveChangesWindow(databaseManager, song);
                result = saveChangesWindow.ShowDialog();
                isDirty = false;
            }

            song = databaseManager.LoadSong(titleTextBox.Text);
            DisplayLyricsEditor displayLyricsEditor = new DisplayLyricsEditor(databaseManager, song);
            result = displayLyricsEditor.ShowDialog();
        }

        private void synchronizedLyricsButton_Click(object sender, RoutedEventArgs e)
        {

        }

        

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            //AutoCompleteKeyPressed(sender, e);

            if (e.Key == Key.S && Keyboard.Modifiers == ModifierKeys.Control)
            {
                SaveButton_Click(sender, e);
            }
        }

        private Song TextFieldsToSong()
        {
            Song song = new Song()
            {
                Title = titleTextBox.Text.Trim(),
                Styles = stylesTextBox.GetText().Trim(),
                ExcludedStyles = excludedStylesTextBox.GetText().Trim(),
                Lyrics = lyricsTextBox.GetText().Trim()
            };

            return song;
        }

        private void EmptyPopupLists()
        {
            stylesPopupList.Items.Clear();
            excludedStylesPopupList.Items.Clear();
            lyricsPopupList.Items.Clear();
        }

        private void OnRichTextboxMouseDown(object sender, MouseButtonEventArgs e)
        {
            EmptyPopupLists();
        }

        private void OpenSunoButtonClicked(object sender, RoutedEventArgs e)
        {

        }

        private void SupportDevButton_Click(object sender, RoutedEventArgs e)
        {
            SupportDevWindow supportDevWindow = new SupportDevWindow();
            supportDevWindow.ShowDialog();
        }

        private void OptionsButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}