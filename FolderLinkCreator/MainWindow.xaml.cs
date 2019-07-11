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
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        private void MasterEntryControl_ChildChanged(object sender, EventArgs e)
        {
            if (MasterEntryControlHost.Child is MasterEntryControl msentryctrl)
            {
                msentryctrl.SetBinding(MasterEntryControl.TargetFolderPathProperty,
                    new Windows.UI.Xaml.Data.Binding()
                    {
                        Source = ViewModel.TargetFolderPath,
                        Mode = BindingMode.TwoWay
                    }
                );

                msentryctrl.SetBinding(MasterEntryControl.LinkLocationPathProperty,
                    new Windows.UI.Xaml.Data.Binding()
                    {
                        Source = ViewModel.LinkLocationPath,
                        Mode = BindingMode.TwoWay
                    }
                );

                msentryctrl.TargetFolderBrowseButton.SetBinding(ButtonBase.CommandProperty,
                    new Windows.UI.Xaml.Data.Binding()
                    {
                        Source = ViewModel.BrowseTargetFolderCommand
                    }
                );

                msentryctrl.LinkLocationBrowseButton.SetBinding(ButtonBase.CommandProperty,
                    new Windows.UI.Xaml.Data.Binding()
                    {
                        Source = ViewModel.BrowseLinkLocationPathCommand
                    }
                );

                msentryctrl.CreateLinkButton.SetBinding(ButtonBase.CommandProperty,
                    new Windows.UI.Xaml.Data.Binding()
                    {
                        Source = ViewModel.CreateLinkCommand
                    }
                );
            }
        }
    }
}
