using FolderLinkCreator.ViewModels;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Windows.UI.Xaml.Controls.Primitives;
using FolderLinkCreator.Controls;
using FolderLinkCreator.UWPUI;
using BindingMode = Windows.UI.Xaml.Data.BindingMode;

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
