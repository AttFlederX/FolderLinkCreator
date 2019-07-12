using System;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace FolderLinkCreator.UWPUI
{
    public sealed partial class MasterEntryControl : UserControl
    {

        public TextBox TargetFolderTextBox => this.targetFolderTextBox;
        public TextBox LinkLocationTextBox => this.linkLocationTextBox;
        public Button TargetFolderBrowseButton => this.targetFolderBrowseButton;
        public Button LinkLocationBrowseButton => this.linkLocationBrowseButton;
        public Button CreateLinkButton => this.createLinkButton;

        public event EventHandler<TextChangedEventArgs> TextBoxTextChanged;

        public MasterEntryControl()
        {
            this.InitializeComponent();
            
            TargetFolderTextBox.TextChanged += TextBoxOnTextChanged;
            LinkLocationTextBox.TextChanged += TextBoxOnTextChanged;
        }

        private void TextBoxOnTextChanged(object sender, TextChangedEventArgs e)
        {
            TextBoxTextChanged?.Invoke(sender, e);
        }
    }
}
