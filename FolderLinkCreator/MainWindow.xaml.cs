using FolderLinkCreator.ViewModels;
using System;
using System.Windows;
using Windows.UI.Xaml.Controls.Primitives;

namespace FolderLinkCreator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainViewModel ViewModel => DataContext as MainViewModel;

        public MainWindow()
        {
            DataContext = new MainViewModel();
            InitializeComponent();
        }

        private void MasterEntryControl_ChildChanged(object sender, EventArgs e)
        {
            if (MasterEntryCtrlHost.Control != null)
            {
                MasterEntryCtrlHost.Control.TargetFolderBrowseButton.SetBinding(ButtonBase.CommandProperty,
                    new Windows.UI.Xaml.Data.Binding()
                    {
                        Source = ViewModel.BrowseTargetFolderCommand
                    }
                );

                MasterEntryCtrlHost.Control.LinkLocationBrowseButton.SetBinding(ButtonBase.CommandProperty,
                    new Windows.UI.Xaml.Data.Binding()
                    {
                        Source = ViewModel.BrowseLinkLocationPathCommand
                    }
                );

                MasterEntryCtrlHost.Control.CreateLinkButton.SetBinding(ButtonBase.CommandProperty,
                    new Windows.UI.Xaml.Data.Binding()
                    {
                        Source = ViewModel.CreateLinkCommand
                    }
                );
            }
        }
    }
}
