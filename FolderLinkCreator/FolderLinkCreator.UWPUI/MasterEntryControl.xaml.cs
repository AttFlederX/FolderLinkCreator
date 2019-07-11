using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using FolderLinkCreator.UWPUI.Annotations;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace FolderLinkCreator.UWPUI
{
    public sealed partial class MasterEntryControl : UserControl
    {
        public static readonly DependencyProperty TargetFolderPathProperty =
            DependencyProperty.Register(
                "TargetFolderPath", typeof(string),
                typeof(MasterEntryControl), null
            );

        public static readonly DependencyProperty LinkLocationPathProperty =
            DependencyProperty.Register(
                "LinkLocationPath", typeof(string),
                typeof(MasterEntryControl), null
            );

        public string TargetFolderPath
        {
            get => (string)GetValue(TargetFolderPathProperty);
            set => SetValue(TargetFolderPathProperty, value);
        }

        public string LinkLocationPath
        {
            get => (string)GetValue(LinkLocationPathProperty);
            set => SetValue(LinkLocationPathProperty, value);
        }

        public Button TargetFolderBrowseButton => this.targetFolderBrowseButton;
        public Button LinkLocationBrowseButton => this.linkLocationBrowseButton;
        public Button CreateLinkButton => this.createLinkButton;


        public MasterEntryControl()
        {
            this.InitializeComponent();
            DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;


        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
