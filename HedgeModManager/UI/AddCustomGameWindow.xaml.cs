using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Interop;
using static HedgeModManager.Lang;

namespace HedgeModManager.UI
{
    public partial class AddCustomGameWindow : Window, INotifyPropertyChanged
    {
        public string DisplayName { get; set; }
        public string GamePath { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public AddCustomGameWindow()
        {
            DataContext = this;
            InitializeComponent();

            Title = HeaderText.Text = Localise("CustomGameUIAddTitle", "Add Custom Game");
            DisplayNameLabel.Text = Localise("CustomGameUIDisplayName", "Display Name");
            PathLabel.Text = Localise("CustomGameUIPath", "Game Path");
            BrowseButton.Content = Localise("CommonUIBrowse", "Browse...");
            HintText.Text = Localise("CustomGameUIPathHint", "Select either a game executable (.exe) or an installation folder for a supported game.");
        }

        private void UI_OK_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(DisplayName))
            {
                HedgeApp.CreateOKMessageBox(Localise("CommonUIError"), Localise("CustomGameUINameRequired", "A display name is required.")).ShowDialog();
                return;
            }

            if (string.IsNullOrWhiteSpace(GamePath))
            {
                HedgeApp.CreateOKMessageBox(Localise("CommonUIError"), Localise("CustomGameUIInvalidPath", "The selected game path is invalid.")).ShowDialog();
                return;
            }

            var normalized = GamePath.Trim().Trim('"');
            if (!File.Exists(normalized) && !Directory.Exists(normalized))
            {
                HedgeApp.CreateOKMessageBox(Localise("CommonUIError"), Localise("CustomGameUIPathNotFound", "The selected game path does not exist.")).ShowDialog();
                return;
            }

            GamePath = normalized;
            DialogResult = true;
            Close();
        }

        private void UI_Browse_Click(object sender, RoutedEventArgs e)
        {
            var choice = new OptionsWindow(Localise("CustomGameUIBrowseTitle", "Select Game Path"),
                Localise("CustomGameUIBrowseExecutable", "Choose executable"),
                Localise("CustomGameUIBrowseFolder", "Choose installation folder")).Ask();

            if (choice == 0)
            {
                var dialog = new FileOpenDialog();
                var filters = new COMDLG_FILTERSPEC[2];
                filters[0] = new COMDLG_FILTERSPEC() { pszName = "Executable", pszSpec = "*.exe" };
                filters[1] = new COMDLG_FILTERSPEC() { pszName = "All files", pszSpec = "*.*" };
                dialog.SetFileTypes((uint)filters.Length, filters);
                if (dialog.Show(new WindowInteropHelper(this).Handle) == 0)
                {
                    dialog.GetResult(out var item);
                    item.GetDisplayName(SIGDN.SIGDN_FILESYSPATH, out var path);
                    GamePath = path;
                    PathTextBox.Text = path;
                }
            }
            else if (choice == 1)
            {
                var folderDialog = new FolderBrowserDialog
                {
                    Title = Localise("CustomGameUIBrowseFolder", "Choose installation folder")
                };
                if (folderDialog.ShowDialog())
                {
                    GamePath = folderDialog.SelectedFolder;
                    PathTextBox.Text = folderDialog.SelectedFolder;
                }
            }
        }
    }
}
